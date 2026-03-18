using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseData.Infrastructure.Entities
{
   public class Company : IEntity
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

      [StringLength(20)]
      public string VatNumber { get; set; }

      [StringLength(1000)]
      public string WebsiteUrl { get; set; }

      [StringLength(50)]
      public string Phone { get; set; } 

      public byte[]? Logo { get; set; }

      public string? LogoContentType { get; set; }

      public virtual ICollection<Adress> Adresses { get; set; } = new List<Adress>();

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Company()
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
