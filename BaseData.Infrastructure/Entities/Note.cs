using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseData.Infrastructure.Entities
{
   public class Note : IEntity
   {
      #region Fields



      #endregion

      #region Properties

      [Key]
      [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
      public int Id { get; set; }

      public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

      [StringLength(2000)]
      public string Text { get; set; }

      public int? BusinessPartnerId { get; set; }
      public int? ContactId { get; set; }

      #endregion

      #region Commands



      #endregion

      #region Constructor

      public Note()
      {

      }

      #endregion

      #region Public Methods


      #endregion

      #region Private Methods



      #endregion
   }
}
