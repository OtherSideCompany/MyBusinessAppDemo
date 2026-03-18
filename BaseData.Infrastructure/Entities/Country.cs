using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseData.Infrastructure.Entities
{
   public class Country : IEntity
   {
      #region Fields



      #endregion

      #region Properties

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

      [StringLength(50)]
      public string Name { get; set; }

      [StringLength(2)]
      public string Alpha2Code { get; set; }

      [StringLength(3)]
      public string Alpha3Code { get; set; }

      [StringLength(3)]
      public string NumericCode { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Country()
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
