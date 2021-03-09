using DSEU.Domain.Entities;

namespace DSEU.Application.Dtos
{
    public abstract class DatabookEntryDto
    {
        /// <summary>
        /// Идентификатор записи
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Статус
        /// </summary>
        public Status Status { get; set; }
    }
}
