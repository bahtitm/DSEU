using DSEU.Domain.Entities.Content;

namespace DSEU.Application.Dtos
{
    public class BinaryDataDto
    {
        public BinaryDataDto(byte[] data, AssociatedApplication binaryDataAssociatedApplication)
        {
            Data = data;
            ContentType = binaryDataAssociatedApplication.ContentType;
            Extension = binaryDataAssociatedApplication.Extension;
        }

        public byte[] Data { get; set; }
        public string ContentType { get; set; }
        public string Extension { get; set; }
    }
}
