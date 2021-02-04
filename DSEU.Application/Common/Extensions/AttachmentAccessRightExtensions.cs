using System;
using DSEU.Application.Common.Enums;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Application.Common.Extensions
{
    public static class AttachmentAccessRightExtensions
    {
        public static AccessRightsOperation MapToAccessRightOperation(this AttachmentAccessRight accessRight)
        {
            return accessRight switch
            {
                AttachmentAccessRight.FullAccess => AccessRightsOperation.FullAccess,
                AttachmentAccessRight.Read => AccessRightsOperation.Read,
                AttachmentAccessRight.Edit => AccessRightsOperation.Edit,
                _ => throw new Exception("unknown type mapping")
            };
        }
        
        public static AttachmentAccessRight MapToAttachmentAccessRight(this AccessRightsOperation operation)
        {
            return operation switch
            {
                AccessRightsOperation.FullAccess => AttachmentAccessRight.FullAccess,
                AccessRightsOperation.Read => AttachmentAccessRight.Read,
                AccessRightsOperation.Edit => AttachmentAccessRight.Edit,
                _ => throw new Exception("Unknown type mapping")
            };
        }
    }
}