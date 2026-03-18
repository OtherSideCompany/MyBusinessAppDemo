using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Infrastructure.Entities
{
   public class BusinessPartnerType : IEntity, ISystemObject
   {
      #region Fields



      #endregion

      #region Properties

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

      [StringLength(100)]
      public string Name { get; set; }

      [StringLength(1)]
      public string? SystemCode { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public BusinessPartnerType()
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
