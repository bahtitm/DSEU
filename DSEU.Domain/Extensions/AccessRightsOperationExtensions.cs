using System.Collections.Generic;
using DSEU.Domain.Entities.CoreEntities;

namespace DSEU.Domain.Extensions
{
    public static class AccessRightsOperationExtensions
    {
        public static bool CanUpdate(this AccessRightsOperation value)
        {
            if (value == AccessRightsOperation.Edit || value == AccessRightsOperation.FullAccess)
            {
                return true;
            }
            return false;
        }

        public static bool CanRead(this AccessRightsOperation value)
        {
            if (value == AccessRightsOperation.FullAccess || value == AccessRightsOperation.Edit || value == AccessRightsOperation.Read)
            {
                return true;
            }
            return false;
        }

        public static bool HasFullAccess(this AccessRightsOperation value)
        {
            return value == AccessRightsOperation.FullAccess;
        }

        public static bool CanRegister(this AccessRightsOperation value)
        {
            return value == AccessRightsOperation.Registration;
        }

        public static IEnumerable<AccessRightsOperation> GetAvailableDocumentOperations(this AccessRightsOperation value)
        {
            switch (value)
            {
                case AccessRightsOperation.Read:
                    yield return AccessRightsOperation.Read;
                    break;
                case AccessRightsOperation.Edit:
                    yield return AccessRightsOperation.Read;
                    yield return AccessRightsOperation.Edit;
                    break;
                case AccessRightsOperation.FullAccess:
                    yield return AccessRightsOperation.Read;
                    yield return AccessRightsOperation.Edit;
                    yield return AccessRightsOperation.FullAccess;
                    yield return AccessRightsOperation.AccessDenied;
                    break;
                default:
                    break;
            }
        }
    }

}
