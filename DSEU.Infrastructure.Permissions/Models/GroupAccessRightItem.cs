using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using DSEU.Application.Common.Extensions;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;
//todo 
//using DSEU.Domain.Entities.Docflow;

namespace DSEU.Infrastructure.Permissions.Models
{
    public class GroupAccessRightItem : RecipientAccessRightItem
    {
        protected GroupAccessRightItem() { }
        public GroupAccessRightItem(Group recipient) : base(recipient)
        {
            Members = new List<int>();
            if (recipient.ParentId.HasValue)
            {
                CreateParent(recipient.Parent, this.Id);
            }
            Members.AddRange(recipient.RecipientLinks.Select(p => p.MemberId));
        }

        /// <summary>
        /// Содержу группы
        /// </summary>
        [JsonIgnore]
        public List<int> Members { get; set; }

        private void PullDownAccessRights(IEnumerable<GroupAccessRightItem> parentHierarhchyGroups)
        {
            AddDependenGroups(parentHierarhchyGroups);
            IEnumerable<GroupAccessRightItem> groups = new[] { this }.Concat(parentHierarhchyGroups);
            foreach (var member in All.Join(Members, p => p.Key, m => m, (s, d) => s.Value).Except(groups))
            {
                member.AccessRights.TryAddRangeWithPriority(AccessRights);
                if (member is GroupAccessRightItem groupAccessRightItem)
                {
                    groupAccessRightItem.PullDownAccessRights(groups);
                }
                else
                {
                    member.AddDependenGroups(groups);
                }
            }
        }

        public void PullDownAccessRights()
        {
            IEnumerable<GroupAccessRightItem> groups = new[] { this };
            foreach (var member in All.Join(Members, p => p.Key, m => m, (s, d) => s.Value).Except(groups))
            {
                member.AccessRights.TryAddRangeWithPriority(AccessRights);
                if (member is GroupAccessRightItem groupAccessRightItem)
                {
                    groupAccessRightItem.PullDownAccessRights(groups);
                }
                else
                {
                    member.AddDependenGroups(groups);
                }
            }
        }

        private static void CreateParent(Group parent, int childId)
        {
            if (All.ContainsKey(parent.Id))
            {
                var item = (GroupAccessRightItem)All[parent.Id];
                item.Members.Add(childId);
                return;
            }

            GroupAccessRightItem obj = parent switch
            {
                Role role => new RoleAccessRightItem(role),
                BusinessUnit businessUnit => new BusinessUnitAccessRightItem(businessUnit),
                Department department => new DepartmentAccessRightItem(department),
                //todo
                //RegistrationGroup registrationGroup => new RegistrationGroupAccessRightItem(registrationGroup),
                _ => throw new System.Exception("Unknow recipient type"),
            };

            obj.Members.Add(childId);
            All.Add(obj.Id, obj);
        }
    }
}