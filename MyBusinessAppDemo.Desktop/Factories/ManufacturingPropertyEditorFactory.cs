using BaseData.Domain.DomainObjects;
using OtherSideCore.Wpf.Factories;
using Search.Contracts.SearchResults;

namespace Manufacturing.Desktop.Factories
{
   public class ManufacturingPropertyEditorFactory : PropertyEditorFactory
   {
      #region Fields



      #endregion

      #region Properties



      #endregion

      #region Commands



      #endregion

      #region Constructor

      public ManufacturingPropertyEditorFactory() : base()
      {
         RegisterSelectorPropertyEditor<Adress>();         
         RegisterSelectorPropertyEditor<Country>();
         RegisterSelectorPropertyEditor<TeamMember>();

         RegisterSelectorPropertyEditor<BusinessPartnerSearchResult>();
         RegisterSelectorPropertyEditor<ContactSearchResult>();
      }

      #endregion

      #region Public Methods



      #endregion

      #region Private Methods



      #endregion
   }
}
