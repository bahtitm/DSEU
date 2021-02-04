using System;

namespace DSEU.Domain.Entities.Content
{
    public class BinaryData
    {
        protected BinaryData() { }
        /// <summary>
        /// ID бинарных данных
        /// </summary>
        /// <param name="BodyId"></param>
        public BinaryData(long size)
        {
            Size = size;
            BodyId = Guid.NewGuid().ToString();
        }
        /// <summary>
        /// Размер в байтах
        /// </summary>
        public long Size { get; set; }
        /// <summary>
        /// идентификатор бинарных данных;
        /// </summary>
        public string BodyId { get; set; }
    }
}
