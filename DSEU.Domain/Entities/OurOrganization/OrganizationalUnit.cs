using DSEU.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.OurOrganization
{
    /// <summary>
    /// Unit-ы в рег. службе 
    /// </summary>
    /// todo надо еще подумать
    public class OrganizationalUnit : DatabookEntry
    {
        protected OrganizationalUnit() { }

        public OrganizationalUnit(string name)
        {
            Name = name;
        }
        public virtual ICollection<User> Users { get; set; }
        public virtual OrganizationalUnit Parent { get; set; }
        public virtual ICollection<OrganizationalUnit> Childs { get; set; } = new List<OrganizationalUnit>();
        public int? ParentId { get; set; }
        /// <summary>
        /// Добавить дочерний организцион. юнит
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(OrganizationalUnit child)
        {
            ThrowIfCircularReference(child);
            child.Parent = this;
            Childs.Add(child);

        }
        /// <summary>
        /// добавление родителя
        /// </summary>
        /// <param name="parent"></param>
        public void AddParent(OrganizationalUnit parent)
        {
            this.Parent = parent;
            this.ParentId = parent.Id;
        }
        /// <summary>
        /// Пометить как закрытый
        /// </summary>
        public void MarkAsClosed()
        {
            Status = Status.Closed;
        }
        void ThrowIfCircularReference(OrganizationalUnit child)
        {
            if (child == null)
            {
                throw new ArgumentNullException();
            }
            var curentParent = Parent;
            while (curentParent != null)
            {
                if (curentParent.Id == child.Id)
                {
                    throw new Exception();
                }
                curentParent = curentParent.Parent;
            }
        }
    }
}