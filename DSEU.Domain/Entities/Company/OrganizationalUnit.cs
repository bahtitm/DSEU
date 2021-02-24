using DSEU.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Company
{
    /// <summary>
    /// Unit-ы в рег. службе 
    /// </summary>
    public class OrganizationalUnit:DatabookEntry 
    {
        protected OrganizationalUnit() { }
        
        public OrganizationalUnit(string name, OrganizationalUnitType type)
        {
            Name = name;
            Type = type;
        }        
        public int TypeId { get; set; }
        public virtual OrganizationalUnit Parent { get; set; }
        public virtual ICollection<OrganizationalUnit> Childs { get; set; } = new List<OrganizationalUnit>();
        public int? ParentId { get; set; }
        public virtual OrganizationalUnitType Type { get; set; }
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
        /// Пометить как закрытый
        /// </summary>
        public void MarkAsClosed()
        {
            Status = Status.Closed;
        }
        /// <summary>
        /// Объединение организационных единиц
        /// </summary>
        /// <param name="target"></param>
        /// <param name="distinationName"></param>
        /// <returns></returns>
        public OrganizationalUnit Merge(OrganizationalUnit target, string distinationName)
        {
            //TODO: Реализовать логику
            //MarkAsClosed(reason);
            //target.MarkAsClosed(reason);
            OrganizationalUnit newUnit = new(distinationName, this.Type);
            return newUnit;
        }
        /// <summary>
        /// Объединение организационных единиц
        /// </summary>
        /// <param name="target"></param>
        /// <param name="distinationName"></param>
        /// <returns></returns>
        public IEnumerable<OrganizationalUnit> Split()
        {
            //TODO: Реализовать логику
            throw new NotImplementedException();
        }
        /// <summary>
        /// Сменить наименование
        /// </summary>
        /// <param name="newName">Новое имя</param>
        /// <param name="reason">Причина</param>
        public void ChangeName(string newName)
        {
            Name = newName;
        }
        /// <summary>
        /// Сменить наименование
        /// </summary>
        /// <param name="newName"></param>
        public void ChangeType(OrganizationalUnitType target)
        {
            Type = target;
        }
        /// <summary>
        /// Переместить административную единицу
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void Move(OrganizationalUnit source, OrganizationalUnit target)
        {
            //TODO:Реализовать (parent,child)
            target.AddChild(source);
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