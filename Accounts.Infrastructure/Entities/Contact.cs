using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Accounts.Infrastructure.Entities
{
   public class Contact : IEntity
   {
      #region Fields



      #endregion

      #region Properties

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

      [StringLength(200)]
      public string Name { get; set; }

      [StringLength(100)]
      public string Phone { get; set; }

      [StringLength(300)]
      public string Mail { get; set; }

      public bool IsActive { get; set; }

      public int? BusinessPartnerId { get; set; }
      public virtual BusinessPartner? BusinessPartner { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Contact()
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
