using DSEU.Domain.Entities.Commons;
using NUnit.Framework;

namespace DSEU.Application.Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }


        [Test]
        public void CloseMary()
        {

            TerritorialUnitType welayat = new TerritorialUnitType("Welayat", "welaýatynyň");
            TerritorialUnitType etrap = new TerritorialUnitType("Etrap", "etrabynyň");
            TerritorialUnitType genes = new TerritorialUnitType("Genes", "geneşiniň");
            TerritorialUnitType street = new TerritorialUnitType("Street", "köçesiniň");

            TerritorialUnit mary = new TerritorialUnit("Mary", welayat);

            var maryEtrap = new TerritorialUnit("Mary", etrap);

            var maryEtrapGenesh = new TerritorialUnit("Kopetdag", genes);
            var maryEtrapGeneshStreet = new TerritorialUnit("Magtymguly", street);
            maryEtrapGenesh.AddChild(maryEtrapGeneshStreet);
            maryEtrap.AddChild(maryEtrapGenesh);
            mary.AddChild(maryEtrap);

            AddressAdditionalInfo additionalInfo = new();
            additionalInfo.House = "7/4";
            additionalInfo.Appartment = "29";

            Address address = new Address(maryEtrapGeneshStreet, additionalInfo);

            var result = address.Compute();

            Assert.AreEqual("Mary welaýatynyň,Mary etrabynyň,Kopetdag geneşiniň,Magtymguly köçesiniň", result);
        }
    }
}