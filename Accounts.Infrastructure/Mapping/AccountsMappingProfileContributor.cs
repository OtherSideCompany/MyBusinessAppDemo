using BusinessAppFramework.Application.Mapping;
using AutoMapper;
using BusinessAppFramework.Infrastructure.Mapping;

namespace Accounts.Infrastructure.Mapping
{
   public class AccountsMappingProfileContributor : IMappingProfileContributor
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public AccountsMappingProfileContributor()
      {

      }

      #endregion

      #region Public Methods

      public void ConfigureMap(Profile profile)
      {
         profile.CreateMap<Entities.BusinessPartner, Domain.DomainObjects.BusinessPartner>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.BusinessPartnerType, Domain.DomainObjects.BusinessPartnerType>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.Contact, Domain.DomainObjects.Contact>().MapHisytoryInfo().ReverseMap();
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
