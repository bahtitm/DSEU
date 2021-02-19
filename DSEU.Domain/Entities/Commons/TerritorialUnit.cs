using DSEU.Domain.Entities.CoreEntities;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons
{
    public class TerritorialUnit : DatabookEntry
    {
        protected TerritorialUnit() { }
        public TerritorialUnit(string name, TerritorialUnitType type)
        {
            Name = name;
            Type = type;
        }

        public virtual TerritorialUnitType Type { get; set; }
        public int TypeId { get; set; }
        public virtual TerritorialUnit Parent { get; set; }
        public virtual ICollection<TerritorialUnit> Childs { get; set; } = new List<TerritorialUnit>();
        public int? ParentId { get; set; }

        /// <summary>
        /// Добавить дочерний терр. юнит
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(TerritorialUnit child)
        {
            child.Parent = this;
            Childs.Add(child);
        }

        /// <summary>
        /// Пометить как закрытый
        /// </summary>
        public void MarkAsClosed(Reason reason)
        {
            Status = Status.Closed;
        }

        /// <summary>
        /// Объединение территориальных единиц
        /// </summary>
        /// <param name="target"></param>
        /// <param name="distinationName"></param>
        /// <returns></returns>
        public TerritorialUnit Merge(TerritorialUnit target, string distinationName, Reason reason)
        {
            //TODO: Реализовать логику
            MarkAsClosed(reason);
            target.MarkAsClosed(reason);
            TerritorialUnit newUnit = new(distinationName, this.Type);
            return newUnit;
        }

        /// <summary>
        /// Объединение территориальных единиц
        /// </summary>
        /// <param name="target"></param>
        /// <param name="distinationName"></param>
        /// <returns></returns>
        public IEnumerable<TerritorialUnit> Split(IEnumerable<SplitSettings> settings)
        {
            //TODO: Реализовать логику
            throw new NotImplementedException();
        }

        /// <summary>
        /// Сменить наименование
        /// </summary>
        /// <param name="newName">Новое имя</param>
        /// <param name="reason">Причина</param>
        public void ChangeName(string newName, Reason reason)
        {
            Name = newName;
        }

        /// <summary>
        /// Сменить наименование
        /// </summary>
        /// <param name="newName"></param>
        public void ChangeType(TerritorialUnitType target)
        {
            Type = target;
        }

        /// <summary>
        /// Переместить административную единицу
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void Move(TerritorialUnit source, TerritorialUnit target)
        {
            //TODO:Реализовать (parent,child)
            target.AddChild(source);
        }
    }
}
