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
    public class HeroeTests
    {
        [Test]
        public void Ctor_StubStaticValues_InitializesParametersFromStaticValues()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeCoins).Return(3);
            staticVal.Stub(s => s.DefaultHeroeHealth).Return(33.2f);
            staticVal.Stub(s => s.DefaultHeroeMaxHealth).Return(55.5f);
            staticVal.Stub(s => s.DefaultHeroePower).Return(129);

            var h = new Heroe(staticVal);

            Assert.AreEqual(3, h.Coins);
            Assert.AreEqual(33.2f, h.Health);
            Assert.AreEqual(55, 5f, h.MaxHealth);
            Assert.AreEqual(129, h.Power);
        }

        [Test]
        public void DecreaseHealthRel_SetsExpectedHealth()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeHealth).Return(50);

            var h = new Heroe(staticVal);
            h.DecreaseHealthRel(0.5f);

            Assert.AreEqual(25.0f, h.Health);
        }

        [Test]
        public void DecreaseHealth_SetsExpectedHealth()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeHealth).Return(77);

            var h = new Heroe(staticVal);
            h.DecreaseHealth(10);

            Assert.AreEqual(67, h.Health);
        }

        [Test]
        public void DecreaseHealth_NotEnoghHealth_SetsHealthToZero()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeHealth).Return(30);

            var h = new Heroe(staticVal);
            h.DecreaseHealth(40);

            Assert.AreEqual(0, h.Health);
        }

        [Test]
        public void DecreaseHealth_NotEnoghHealth_RaisesDeathEvent()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeHealth).Return(40);

            var h = new Heroe(staticVal);

            h.Died += (s, ea) => Assert.Pass();

            h.DecreaseHealth(40);

            Assert.Fail();
        }

        [Test]
        public void AddCoins_SetsExpectedCoinsCount()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeCoins).Return(33);

            var h = new Heroe(staticVal);
            h.AddCoins(22);

            Assert.AreEqual(55, h.Coins);
        }
    }
}
