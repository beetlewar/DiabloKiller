using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;
using NUnit.Framework;
using Rhino.Mocks;

namespace Bot.Tests
{
    [TestFixture]
    public class BotWeaponBuyerTests
    {
        [Test]
        public void Availability_NotEnoghMoney_ReturnsForbidden()
        {
            var hero = MockRepository.GenerateStub<IHero>();
            hero.Stub(h => h.Coins).Return(2);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.WeaponPrice).Return(3);

            Assert.AreEqual(BotCommandAvailability.Forbidden, new BotWeaponBuyer(hero, staticVal, MockRepository.GenerateStub<ICommand>()).Availability);
        }

        [Test]
        public void Availability_EnoghMoney_ReturnsAllowed()
        {
            var hero = MockRepository.GenerateStub<IHero>();
            hero.Stub(h => h.Coins).Return(3);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.WeaponPrice).Return(3);

            Assert.AreEqual(BotCommandAvailability.Allowed, new BotWeaponBuyer(hero, staticVal, MockRepository.GenerateStub<ICommand>()).Availability);
        }
    }
}
