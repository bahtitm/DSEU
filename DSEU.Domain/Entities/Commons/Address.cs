using System.Collections.Generic;
using System.Text;

namespace DSEU.Domain.Entities.Commons
{
    /// <summary>
    /// Адресс недвижимости
    /// </summary>
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
            stringBuilder.Append(additionalInfo.ToString());
            return stringBuilder.ToString();
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
                stringBuilder.AppendFormat("{0} {1}", unit.Name, unit.TypeName);

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
        public string[] House { get; set; }
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
        /// <summary>
        /// Комплекс
        /// </summary>
        public string Complex { get; set; }
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append(CalculateHousingString());
            stringBuilder.Append(CalculcateBlockString());
            stringBuilder.Append(CalculateHouseString());
            stringBuilder.Append(CalculateAppartmentString());
            return stringBuilder.ToString();
        }
        private string CalculateHouseString()
        {
            if (House == null)
                return string.Empty;
            if (House.Length > 1)
            {
                var house = string.Join('-', House);
                return string.Format(", {0} jaýlary", house);
            }
            if (House.Length == 1)
            {
                var house = House[0].Trim();
                if (ValidString(house))
                {
                    return string.Format(", {0}-belgili jaýy", house);
                }
            }
            return string.Empty;
        }
        private string CalculateAppartmentString()
        {
            if (House == null)
                return string.Empty;
            if (House.Length == 1)
            {
                if (ValidString(Appartment))
                {
                    var appartment = Appartment.Trim();

                    return string.Format(", {0}-belgili öýi", appartment);
                }
            }
            return string.Empty;
        }
        private string CalculcateBlockString()
        {
            if (ValidString(Block))
            {
                var block = Block.Trim();
                return string.Format(", {0}-belgili blogynyň", block);
            }
            return string.Empty;
        }
        private string CalculateHousingString()
        {
            if (ValidString(Housing))
            {
                var housing = Housing.Trim();
                return string.Format(", {0}-belgili korpusynyň", housing);
            }
            return string.Empty;
        }
        private bool ValidString(string value)
        {
            return !string.IsNullOrEmpty(value) && !string.IsNullOrWhiteSpace(value.Trim());
        }
    }
}
