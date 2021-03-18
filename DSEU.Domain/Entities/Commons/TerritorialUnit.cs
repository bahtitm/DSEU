using DSEU.Domain.Entities.CoreEntities;
using DSEU.Domain.Exceptions.Commons;
using System;
using System.Collections.Generic;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// определенная територия 
    /// </summary>
    public class TerritorialUnit : DatabookEntry
    {
        protected TerritorialUnit() { }
        public TerritorialUnit(string name)
        {
            Name = name;            
        }
        /// <summary>
        /// Имя типа населеного пункта (welayat oba şäher)
        /// </summary>
        public string TypeName { get; set; }

        public virtual TerritorialUnit Parent { get; set; }
        public virtual ICollection<TerritorialUnit> Childs { get; set; } = new List<TerritorialUnit>();
        public int? ParentId { get; set; }

        /// <summary>
        /// Добавить дочерний терр. юнит
        /// </summary>
        /// <param name="child"></param>
        public void AddChild(TerritorialUnit child)
        {
            ThrowIfCircularReference(child);
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
            TerritorialUnit newUnit = new(distinationName);
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
        /// Переместить административную единицу
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        public void Move(TerritorialUnit source, TerritorialUnit target)
        {
            //TODO:Реализовать (parent,child)
            target.AddChild(source);
        }
        void ThrowIfCircularReference(TerritorialUnit child)
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
                    throw new TerritorialUnitException();
                }
                curentParent = curentParent.Parent;
            }
        }
    }
}