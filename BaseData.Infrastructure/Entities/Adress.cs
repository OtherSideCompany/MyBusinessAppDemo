using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseData.Infrastructure.Entities
{
   public class Adress : IEntity
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
      public string Label { get; set; }

      [Required]
      [StringLength(200)]
      public string AdressDescription { get; set; }

      public int? PostalCodeId { get; set; }
      public virtual PostalCode? PostalCode { get; set; }

      public int? BusinessPartnerId { get; set; }
      public int? CompanyId { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Adress()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return (AdressDescription + ", " + PostalCode?.Code + " " + PostalCode?.City + " " + PostalCode?.Country?.Alpha2Code).Trim();
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
