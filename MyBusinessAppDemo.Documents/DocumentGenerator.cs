using BaseData.Application.DomainObjectServices;
using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Relations;
using BusinessAppFramework.DocumentRendering;
using BusinessAppFramework.Domain;
using MyBusinessApp.Contracts;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace MyBusinessApp.Documents
{
    public class DocumentGenerator : IDocumentGenerator
    {
        #region Fields

        private IHtmlDocumentRenderer _htmlDocumentRenderer;
        private IHtmlDocumentTemplateRegistry _htmlDocumentTemplateRegistry;
        private IDocumentModelLoaderFactory _documentModelLoaderFactory;
        private IDocumentModelLoaderTypeRegistry _documentModelLoaderTypeRegistry;
        private IDomainObjectServiceFactory _domainObjectServiceFactory;
        private IRelationService _relationService;

        private Assembly _assembly => Assembly.GetExecutingAssembly();

        private const string _defaultCultureInfo = "fr";

        #endregion

        #region Properties



        #endregion

        #region Events



        #endregion

        #region Constructor

        public DocumentGenerator(
         IHtmlDocumentRenderer htmlDocumentRenderer,
         IHtmlDocumentTemplateRegistry htmlDocumentTemplateRegistry,
         IDocumentModelLoaderFactory documentModelLoaderFactory,
         IDocumentModelLoaderTypeRegistry documentModelLoaderTypeRegistry,
         IDomainObjectServiceFactory domainObjectServiceFactory,
         IRelationService relationService)
        {
            _htmlDocumentRenderer = htmlDocumentRenderer;
            _htmlDocumentTemplateRegistry = htmlDocumentTemplateRegistry;
            _documentModelLoaderFactory = documentModelLoaderFactory;
            _documentModelLoaderTypeRegistry = documentModelLoaderTypeRegistry;
            _domainObjectServiceFactory = domainObjectServiceFactory;
            _relationService = relationService;
        }

        #endregion

        #region Public Methods

        public async Task<string> GetHtmlDocumentAsync(StringKey key, int objectId)
        {
            var htmlDocumentTemplate = _htmlDocumentTemplateRegistry.GetTemplate(key);

            var layoutTemplate = LoadFromResource(htmlDocumentTemplate.LayoutResourceName);
            layoutTemplate = PlaceCssInTemplate(layoutTemplate);

            var contentTemplate = LoadFromResource(htmlDocumentTemplate.ContentResourceName);

            var template = layoutTemplate.Replace("{Content}", contentTemplate);

            var companyModel = await GetCompanyModelAsync();
            var documentModelLoaderType = _documentModelLoaderTypeRegistry.GetDocumentModelLoaderType(key);
            var model = await _documentModelLoaderFactory.CreateDocumentModelLoader(documentModelLoaderType).LoadAsync(objectId, _defaultCultureInfo);

            return _htmlDocumentRenderer.RenderDocument(template, new List<object>() { companyModel, model! });
        }

        public async Task<byte[]> GetPdfDocumentAsync(StringKey key, int objectId)
        {
            var htmlDocument = await GetHtmlDocumentAsync(key, objectId);
            return await _htmlDocumentRenderer.RenderPdfDocumentAsync(htmlDocument);
        }

        #endregion

        #region Private Methods               

        private string LoadFromResource(string templateName)
        {
            var resources = _assembly.GetManifestResourceNames();

            var resourceName = resources.Where(r => r.EndsWith("." + templateName, StringComparison.OrdinalIgnoreCase)).FirstOrDefault();

            if (resourceName == null)
            {
                throw new InvalidOperationException($"Resource not found : {resourceName}");
            }

            using var stream = _assembly.GetManifestResourceStream(resourceName);

            if (stream == null)
                return "";

            using var reader = new StreamReader(stream, Encoding.UTF8);
            return reader.ReadToEnd();
        }

        private string PlaceCssInTemplate(string template)
        {
            var matches = Regex.Matches(template, @"\{Css:(.+?)\}");

            foreach (Match match in matches)
            {
                var cssFile = match.Groups[1].Value;
                var cssContent = LoadFromResource(cssFile);
                var inlineStyle = $"<style>{cssContent}</style>";
                template = template.Replace(match.Value, inlineStyle);
            }

            return template;
        }

        private async Task<object> GetCompanyModelAsync()
        {
            var companyService = (CompanyService)_domainObjectServiceFactory.CreateDomainObjectService<Company>();
            var adressService = _domainObjectServiceFactory.CreateDomainObjectService<Adress>();
            var postalCodeService = _domainObjectServiceFactory.CreateDomainObjectService<PostalCode>();

            var company = (await companyService.GetAllAsync()).FirstOrDefault();

            var addressId = company != null ?
                            (await _relationService.GetChildrenIdsAsync(company.Id, ParentChildRelationKeys.CompanyAdressRelationKey)).FirstOrDefault() :
                            (int?)null;
            var address = addressId != null ? await adressService.GetAsync(addressId.Value) : null;

            var postalCode = address != null && address.PostalCodeReference.DomainObjectId != null ?
                             await postalCodeService.GetAsync(address.PostalCodeReference.DomainObjectId.Value) :
                             null;

            var model = new
            {
                company_name = company != null ? company.Name : GlobalVariables.DefaultString,
                company_address = address != null ? address.AdressDescription : GlobalVariables.DefaultString,
                company_postal_code = postalCode != null ? postalCode.Code : GlobalVariables.DefaultString,
                company_city = postalCode != null ? postalCode.City : GlobalVariables.DefaultString,
                company_vat = company != null ? company.VatNumber : GlobalVariables.DefaultString,
                company_web = company != null ? company.WebsiteUrl : GlobalVariables.DefaultString,
                company_phone = company != null ? company.Phone : GlobalVariables.DefaultString,
            };

            return model;
        }
    }

        #endregion
}

