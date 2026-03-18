using BusinessAppFramework.Application.Interfaces;
using BusinessAppFramework.Domain;
using BusinessAppFramework.Domain.DomainObjects;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseData.Infrastructure.Entities
{
    public class Document : IEntity
    {
        #region Fields



        #endregion

        #region Properties

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public HistoryInfo HistoryInfo { get; set; } = new HistoryInfo();

        public string FileName { get; set; } = GlobalVariables.DefaultString;

        public string ContentType { get; set; } = GlobalVariables.DefaultString;

        public long ByteSize { get; set; }

        public Guid StorageKey { get; set; }

        #endregion

        #region Commands



        #endregion

        #region Constructor

        public Document()
        {

        }

        #endregion

        #region Public Methods

        public override string ToString()
        {
            return FileName;
        }

        #endregion

        #region Private Methods



        #endregion
    }
}
