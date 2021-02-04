using System.Collections.Generic;
using System.Linq;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Extensions;

namespace DSEU.Application.Common.Extensions
{
    public static class DictionaryExtensions
    {
        public static void TryAddWithPriority(this List<(EntityTypeGuid entityType, AccessRightsOperation operation)> list, EntityTypeGuid entityTypeGuid, AccessRightsOperation operation)
        {
            if (operation >= AccessRightsOperation.Read && operation <= AccessRightsOperation.AccessDenied)
            {
                if (list.Any(p => p.entityType == entityTypeGuid))
                {
                    var item = list.FirstOrDefault(p => p.entityType == entityTypeGuid && p.operation != AccessRightsOperation.Registration && p.operation != AccessRightsOperation.Approval);

                    if (item == default)
                    {
                        list.Add((entityTypeGuid, operation));
                        return;
                    }

                    var index = list.IndexOf(item);

                    if (list[index].operation < operation)
                    {
                        list[index] = (entityTypeGuid, operation);
                    }
                }
                else
                {
                    list.Add((entityTypeGuid, operation));
                }
                return;
            }

            //Обработка регистрации, утверждения, удаления документа
            //if (operation < AccessRightsOperation.Read)
            //{
            //    var fullHierarchy = entityTypeGuid.GetFullTypeHierarchy();
            //    var items = list.Where(p => fullHierarchy.Contains(p.entityType));
            //    if (items.Any())
            //    {
            //        if (!list.Any(p => p.entityType == entityTypeGuid && p.operation == operation))
            //        {
            //            list.Add((entityTypeGuid, operation));
            //        }
            //    }
            //    else
            //    {
            //        list.Add((entityTypeGuid, operation));
            //    }
            //}
        }

        public static void TryAddRangeWithPriority(this List<(EntityTypeGuid entityType, AccessRightsOperation operation)> distination, List<(EntityTypeGuid entityType, AccessRightsOperation operation)> source)
        {
            foreach (var (entityType, operation) in source)
            {
                distination.TryAddWithPriority(entityType, operation);
            }
        }
    }
}
