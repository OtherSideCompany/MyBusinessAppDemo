using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseData.Infrastructure.Entities
{
   public class PostalCode : IEntity
   {
      #region Fields



      #endregion

      #region Properties

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

      [Required]
      [StringLength(20)]
      public string Code { get; set; }

      [Required]
      [StringLength(255)]
      public string City { get; set; }

      public int? CountryId { get; set; }
      public virtual Country? Country { get; set; }


      #endregion

      #region Commands



      #endregion

      #region Constructor

      public PostalCode()
      {

      }

      #endregion

      #region Public Methods

      public override string ToString()
      {
         return Code + " " + City;
      }

      #endregion

      #region Private Methods



      #endregion
   }
}
