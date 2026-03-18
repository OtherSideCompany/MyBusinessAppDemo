using Accounts.Infrastructure.Mapping;
using AutoMapper;
using BaseData.Infrastructure.Mapping;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Infrastructure.Mapping;

namespace MyBusinessApp.Infrastructure.Mapping
{
   public class InfrastructureMappingProfile : Profile
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public InfrastructureMappingProfile() : base()
      {
         CreateMap<string, StringKey>().ConvertUsing(src => StringKey.From(src));
         CreateMap<StringKey, string>().ConvertUsing(src => src.Key);

         var baseDataMappingProfileContributor = new BaseDataMappingProfileContributor();
         var accountsMappingProfileContributor = new AccountsMappingProfileContributor();

         baseDataMappingProfileContributor.ConfigureMap(this);
         accountsMappingProfileContributor.ConfigureMap(this);
      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
