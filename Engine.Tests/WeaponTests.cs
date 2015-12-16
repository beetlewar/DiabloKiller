using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Engine.Tests
{
    [TestFixture]
    public class WeaponTests
    {
        [Test]
        public void Ctor_SpecifyPower_SetsPower()
        {
            Assert.AreEqual(3, new Weapon(3).Power);
        }

        [Test]
        public void Modify_NullHeroe_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Weapon(2).Modify(null));
        }

        [Test]
        public void Modify_MockHeroe_IncreasesHoeroesPower()
        {
            var heroe = MockRepository.GenerateMock<IHeroe>();
            heroe.Expect(h => h.IncreasePower(77));

            new Weapon(77).Modify(heroe);

            heroe.VerifyAllExpectations();
        }
    }
}
