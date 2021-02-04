using Newtonsoft.Json;
using System.Collections.Generic;
using DSEU.Domain.Entities;
using DSEU.Domain.Entities.Company;
using DSEU.Domain.Entities.CoreEntities;
//todo history link 
//using DSEU.Domain.Entities.Docflow;

namespace DSEU.Infrastructure.Permissions.Models
{
    public abstract class RecipientAccessRightItem
    {
        [JsonIgnore]
        public static Dictionary<int, RecipientAccessRightItem> All = new Dictionary<int, RecipientAccessRightItem>();
        public static RecipientAccessRightItem Create(Recipient recipient)
        {
            if (All.ContainsKey(recipient.Id))
            {
                return All[recipient.Id];
            }

            RecipientAccessRightItem obj = recipient switch
            {
                SystemUser systemUser => new SystemUserAccessRightItem(systemUser),
                Employee employee => new EmployeeAccessRightItem(employee),
                Role role => new RoleAccessRightItem(role),
                BusinessUnit businessUnit => new BusinessUnitAccessRightItem(businessUnit),
                Department department => new DepartmentAccessRightItem(department),
                ////todo history link
                //RegistrationGroup registrationGroup => new RegistrationGroupAccessRightItem(registrationGroup),
                _ => throw new System.Exception("Unknow recipient type"),
            };

            All.Add(recipient.Id, obj);
            return obj;
        }

        protected RecipientAccessRightItem() { }
        public RecipientAccessRightItem(Recipient recipient)
        {
            IncludeInGroups = new HashSet<GroupAccessRightItem>();
            SubordinatedEmployees = new List<EmployeeAccessRightItem>();
            AccessRights = new List<(EntityTypeGuid entityType, AccessRightsOperation operation)>();
            Id = recipient.Id;
            Name = recipient.Name;
            Uid = recipient.Uid;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Uid { get; set; }

        /// <summary>
        /// Нахожусь в группах
        /// </summary>
        public HashSet<GroupAccessRightItem> IncludeInGroups { get; set; }
        /// <summary>
        /// Подчиненные сотрудники
        /// </summary>
        public List<EmployeeAccessRightItem> SubordinatedEmployees { get; set; }
        public List<(EntityTypeGuid entityType, AccessRightsOperation operation)> AccessRights { get; set; }
        
        public void AddDependenGroups(IEnumerable<GroupAccessRightItem> groups)
        {
            foreach (var group in groups)
            {
                if (!IncludeInGroups.Contains(group))
                {
                    IncludeInGroups.Add(group);
                }
            }
        }
        
        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}