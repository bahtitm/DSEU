using System.Collections.Generic;
using System.Text;

namespace DSEU.Domain.Entities.Commons
{
    public class Address
    {
        private readonly TerritorialUnit territorialUnit;
        private readonly AddressAdditionalInfo additionalInfo;

        public Address(TerritorialUnit territorialUnit, AddressAdditionalInfo additionalInfo)
        {
            this.territorialUnit = territorialUnit;
            this.additionalInfo = additionalInfo;
        }

        public string Compute()
        {
            //TODO:Реализовать логику
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(ComputeMainAddressPart());
            stringBuilder.Append(ComputeAdditionalAddressPart());
            return stringBuilder.ToString();
        }

        private string ComputeAdditionalAddressPart()
        {
            return string.Empty;
        }

        private string ComputeMainAddressPart()
        {
            StringBuilder stringBuilder = new StringBuilder();
            Stack<TerritorialUnit> units = new(new[] { territorialUnit });
            var current = territorialUnit.Parent;
            while (current != null)
            {
                units.Push(current);
                current = current.Parent;
            }


            while (units.Count > 0)
            {
                var unit = units.Pop();
                stringBuilder.AppendFormat("{0} {1}", unit.Name, unit.Type.PostFix);

                if (units.Count > 0)
                {
                    stringBuilder.Append(',');
                }
            }

            return stringBuilder.ToString();
        }
    }

    public class AddressAdditionalInfo
    {
        /// <summary>
        /// Номер дома
        /// </summary>
        public string House { get; set; }
        /// <summary>
        /// Корпус
        /// </summary>
        public string Housing { get; set; }
        /// <summary>
        /// Блок
        /// </summary>
        public string Block { get; set; }
        /// <summary>
        /// Квартира
        /// </summary>
        public string Appartment { get; set; }
    }
}
