using Accounts.Domain.DomainObjects;
using BaseData.Domain.DomainObjects;
using Purchases.Domain.DomainObjects;
using System.Windows;
using System.Windows.Controls;

namespace Manufacturing.Desktop.General
{
   public class ReferenceTypeTemplateSelector : DataTemplateSelector
   {
      public DataTemplate? BusinessPartnerTemplate { get; set; }
      public DataTemplate? ContactTemplate { get; set; }
      public DataTemplate? ProviderOrderTemplate { get; set; }
      public DataTemplate? TeamMemberTemplate { get; set; }

      public override DataTemplate? SelectTemplate(object item, DependencyObject container)
      {
         if (item is Type type)
         {
            if (type == typeof(BusinessPartner))
            {
               return BusinessPartnerTemplate;
            }
            else if (type == typeof(Contact))
            {
               return ContactTemplate;
            }
            else if (type == typeof(ProviderOrder))
            {
               return ProviderOrderTemplate;
            }
            else if (type == typeof(TeamMember))
            {
               return TeamMemberTemplate;
            }
         }
         return base.SelectTemplate(item, container);
      }
   }
}
