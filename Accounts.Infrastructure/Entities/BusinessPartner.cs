using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Infrastructure.Entities
{
   public class BusinessPartner : IEntity
   {
      #region Fields



      #endregion

      #region Properties

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

      [Required]
      [StringLength(200)]
      public string Name { get; set; }

      [Required]
      [StringLength(20)]
      public string VatNumber { get; set; }

      public int? ClientNumber { get; set; }

      public int? ProviderNumber { get; set; }

      public virtual ICollection<BusinessPartnerType> BusinessPartnerTypes { get; set; } = new List<BusinessPartnerType>();

      public virtual ICollection<Contact> Contacts { get; set; } = new List<Contact>();

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BusinessPartner()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return Name;
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
