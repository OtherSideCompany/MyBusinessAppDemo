using Accounts.Contracts;
using Accounts.Domain.DomainObjects;
using BaseData.Contracts;
using BaseData.Domain.DomainObjects;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Infrastructure.Entities;
using MyBusinessApp.Contracts;

namespace MyBusinessApp.Infrastructure.Entities
{
    public class MyBusinessAppRelationResolver : RelationResolver
    {
        #region Fields



        #endregion

        #region Properties



        #endregion

        #region Commands



        #endregion

        #region Constructor

        public MyBusinessAppRelationResolver()
        {
            #region Reference Relations

            RegisterReferenceRelationEntry<Adress, PostalCode, BaseData.Infrastructure.Entities.Adress, BaseData.Infrastructure.Entities.PostalCode>(
               StringKey.From(BaseDataContracts.AdressPostalCodeReference),
               a => a.PostalCodeReference,
               e => e.PostalCodeId);

            RegisterReferenceListRelationEntry<BusinessPartner, BusinessPartnerType, Accounts.Infrastructure.Entities.BusinessPartner, Accounts.Infrastructure.Entities.BusinessPartnerType>(
               StringKey.From(AccountsContracts.BusinessPartnerBusinessPartnerTypeReference),
               u => u.BusinessPartnerTypesReferences,
               e => e.BusinessPartnerTypes);

            RegisterReferenceRelationEntry<Contact, BusinessPartner, Accounts.Infrastructure.Entities.Contact, Accounts.Infrastructure.Entities.BusinessPartner>(
               StringKey.From(AccountsContracts.ContactBusinessPartnerReference),
               u => u.BusinessPartnerReference,
               e => e.BusinessPartnerId);            

            RegisterReferenceRelationEntry<PostalCode, Country, BaseData.Infrastructure.Entities.PostalCode, BaseData.Infrastructure.Entities.Country>(
               StringKey.From(BaseDataContracts.PostalCodeCountryReference),
               pc => pc.CountryReference,
               e => e.CountryId);

            #endregion

            #region Reference List Relations           


            #endregion

            #region Parent Child Relations

            RegisterParentChildRelationEntry<Accounts.Infrastructure.Entities.BusinessPartner, Accounts.Infrastructure.Entities.Contact>(
                StringKey.From(ParentChildRelationKeys.BusinessPartnerContactRelationKey),
                e => e.BusinessPartnerId,
                (context, parentId) => context.Set<Accounts.Infrastructure.Entities.Contact>().Where(c => c.BusinessPartnerId == parentId).Select(e => e.Id));

            RegisterParentChildRelationEntry<Accounts.Infrastructure.Entities.BusinessPartner, BaseData.Infrastructure.Entities.Adress>(
               StringKey.From(ParentChildRelationKeys.BusinessPartnerAdressRelationKey),
               e => e.BusinessPartnerId,
               (context, parentId) => context.Set<BaseData.Infrastructure.Entities.Adress>().Where(c => c.BusinessPartnerId == parentId).Select(e => e.Id));

            RegisterParentChildRelationEntry<Accounts.Infrastructure.Entities.BusinessPartner, BaseData.Infrastructure.Entities.Note>(
               StringKey.From(ParentChildRelationKeys.BusinessPartnerNoteRelationKey),
               e => e.BusinessPartnerId,
               (context, parentId) => context.Set<BaseData.Infrastructure.Entities.Note>().Where(c => c.BusinessPartnerId == parentId).Select(e => e.Id));

            RegisterParentChildRelationEntry<BaseData.Infrastructure.Entities.Company, BaseData.Infrastructure.Entities.Adress>(
               StringKey.From(ParentChildRelationKeys.CompanyAdressRelationKey),
               e => e.CompanyId,
               (context, parentId) => context.Set<BaseData.Infrastructure.Entities.Adress>().Where(c => c.CompanyId == parentId).Select(e => e.Id));

            RegisterParentChildRelationEntry<Accounts.Infrastructure.Entities.Contact, BaseData.Infrastructure.Entities.Note>(
               StringKey.From(ParentChildRelationKeys.ContactNoteRelationKey),
               e => e.ContactId,
               (context, parentId) => context.Set<BaseData.Infrastructure.Entities.Note>().Where(c => c.ContactId == parentId).Select(e => e.Id));

            #endregion
        }

        #endregion

        #region Public Methods



        #endregion

        #region Private Methods



        #endregion
    }
}
