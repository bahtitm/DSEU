using DSEU.Domain.Entities;

namespace DSEU.Application.Dtos
{
    /// <summary>
    /// Справочник
    /// </summary>
    public class DatabookEntryDto : BaseEntityDto
    {
        /// <summary>
        /// Наименование
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Состояние
        /// </summary>
        public Status Status { get; set; }
    }
}
