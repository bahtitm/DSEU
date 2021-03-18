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
        public void TestAddress()
        {

            
            TerritorialUnit mary = new TerritorialUnit("Mary")
            {
                Id = 1
            };

            var maryEtrap = new TerritorialUnit("Mary")
            {
                Id = 2
            };

            var maryEtrapGenesh = new TerritorialUnit("Kopetdag")
            {
                Id = 3
            };
            var maryEtrapGeneshStreet = new TerritorialUnit("Magtymguly")
            {
                Id = 4
            };

            var myetrap1 = new TerritorialUnit("Mary")
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