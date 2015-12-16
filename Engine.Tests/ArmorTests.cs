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
    public class ArmorTests
    {
        [Test]
        public void Ctor_SpecifyHealth_SetsHealth()
        {
            Assert.AreEqual(2, new Armor(2).Health);
        }

        [Test]
        public void Modify_NullHero_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Armor(44).Modify(null));
        }

        [Test]
        public void Modify_MockHero_IncreasesHoeroesPower()
        {
            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.IncreaseMaxHealth(22));

            new Armor(22).Modify(hero);

            hero.VerifyAllExpectations();
        }
    }
}
