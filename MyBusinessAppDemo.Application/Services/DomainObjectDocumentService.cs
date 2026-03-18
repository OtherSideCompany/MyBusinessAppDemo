using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Application.Factories;
using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Application.Relations;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.DomainObjects;

namespace BusinessAppFramework.Application.Services
{
   public class DomainObjectDocumentService<T> : IDomainObjectDocumentService<T> where T : DomainObject
   {
      #region Fields

      private IDomainObjectServiceFactory _domainObjectServiceFactory;
      private IRelationService _relationService;
      private IDocumentStorageService _documentStorageService;
      IRelationResolver _relationResolver;

      #endregion

      #region Constructor

      public DomainObjectDocumentService(
         IDomainObjectServiceFactory domainObjectServiceFactory,
         IRelationService relationService,
         IRelationResolver relationResolver,
         IDocumentStorageService documentStorageService)
      {
         _domainObjectServiceFactory = domainObjectServiceFactory;
         _relationService = relationService;
         _relationResolver = relationResolver;
         _documentStorageService = documentStorageService;
      }

      #endregion

      #region Public Methods

      public async Task<int> AttachAsync(int parentId, string relationKey, string fileName, string contentType, long size, Stream content, CancellationToken ct = default)
      {
         var documentService = _domainObjectServiceFactory.CreateDomainObjectService<Document>();

         var document = new Document() { FileName = fileName, ContentType = contentType, ByteSize = size };
         await documentService.CreateAsync(document);

         if (_relationResolver.TryGetParentChildRelationEntry(StringKey.From(relationKey), out var parentChildRelation))
         {
            await _relationService.SetParentAsync(parentId, document.Id, parentChildRelation.RelationKey.Key);
         }

         await _documentStorageService.StoreAsync(document.StorageKey, content, contentType);     
         
         return document.Id;
      }

      public async Task DeleteAsync(int documentId, CancellationToken ct = default)
      {
         var documentService = _domainObjectServiceFactory.CreateDomainObjectService<Document>();
         var document = await documentService.GetAsync(documentId);

         if (document == null)
            return;

         await _documentStorageService.DeleteAsync(document.StorageKey);         
         await documentService.DeleteAsync(documentId);
      }

      public async Task<(Stream stream, string contentType, string fileName)?> OpenReadAsync(int documentId, CancellationToken ct = default)
      {
         var documentService = _domainObjectServiceFactory.CreateDomainObjectService<Document>();
         var document = await documentService.GetAsync(documentId);

         if (document == null)
            return null;

         return (await _documentStorageService.OpenReadAsync(document.StorageKey, ct), document.ContentType, document.FileName);
      }

      public async Task<bool> ExistsAsync(int documentId, CancellationToken ct = default)
      {
         var documentService = _domainObjectServiceFactory.CreateDomainObjectService<Document>();
         var document = await documentService.GetAsync(documentId);

         if (document == null)
            return false;

         return await _documentStorageService.ExistsAsync(document.StorageKey);
      }

      #endregion
   }
}
