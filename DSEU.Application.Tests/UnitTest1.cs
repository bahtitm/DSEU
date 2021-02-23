using DSEU.Domain.Entities.Commons;
using DSEU.Domain.Entities.Company;
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
        public void TestAddress()
        {

            TerritorialUnitType welayat = new TerritorialUnitType("Welayat", "welaýatynyň");
            TerritorialUnitType etrap = new TerritorialUnitType("Etrap", "etrabynyň");
            TerritorialUnitType genes = new TerritorialUnitType("Genes", "geneşiniň");
            TerritorialUnitType street = new TerritorialUnitType("Street", "köçesiniň");
            TerritorialUnitType etrap1 = new TerritorialUnitType("Etrap", "etrabynyň");
            TerritorialUnit mary = new TerritorialUnit("Mary", welayat)
            {
                Id = 1
            };

            var maryEtrap = new TerritorialUnit("Mary", etrap)
            {
                Id = 2
            };

            var maryEtrapGenesh = new TerritorialUnit("Kopetdag", genes)
            {
                Id = 3
            };
            var maryEtrapGeneshStreet = new TerritorialUnit("Magtymguly", street)
            {
                Id = 4
            };

            var myetrap1 = new TerritorialUnit("Mary", etrap)
            {
                Id = 5
            };
            

            maryEtrapGenesh.AddChild(maryEtrapGeneshStreet);
            maryEtrap.AddChild(maryEtrapGenesh);
            mary.AddChild(maryEtrap);
            maryEtrapGenesh.AddChild(mary);


            AddressAdditionalInfo additionalInfo = new();
            additionalInfo.Appartment = "29";
            additionalInfo.House = new[] { "7/4", "7/5", "7/6" };
            additionalInfo.Housing = "1";
            additionalInfo.Block = "5";

            Address address = new Address(maryEtrapGeneshStreet, additionalInfo);

            var result = address.Compute();

            //Assert.AreEqual("Mary welaýatynyň,Mary etrabynyň,Kopetdag geneşiniň,Magtymguly köçesiniň, 1-belgili korpusynyň, 5-belgili blogynyň, 7/4-7/5-7/6 jaýlary", result);
        }
    }
}