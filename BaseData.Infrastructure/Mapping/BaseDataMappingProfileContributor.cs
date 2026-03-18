using BusinessAppFramework.Application.Mapping;
using AutoMapper;
using BusinessAppFramework.Infrastructure.Mapping;

namespace BaseData.Infrastructure.Mapping
{
   public class BaseDataMappingProfileContributor : IMappingProfileContributor
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BaseDataMappingProfileContributor() : base()
      {

      }

      #endregion

      #region Public Methods

      public void ConfigureMap(Profile profile)
      {
         profile.CreateMap<Entities.Adress, Domain.DomainObjects.Adress>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.Company, Domain.DomainObjects.Company>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.Country, Domain.DomainObjects.Country>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.Document, Domain.DomainObjects.Document>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.Note, Domain.DomainObjects.Note>().MapHisytoryInfo().ReverseMap();
         profile.CreateMap<Entities.PostalCode, Domain.DomainObjects.PostalCode>().MapHisytoryInfo().ReverseMap();
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
