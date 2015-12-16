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
    public class HeroTests
    {
        [Test]
        public void Ctor_StubStaticValues_InitializesParametersFromStaticValues()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeCoins).Return(3);
            staticVal.Stub(s => s.DefaultHeroHealth).Return(33.2f);
            staticVal.Stub(s => s.DefaultHeroMaxHealth).Return(55.5f);
            staticVal.Stub(s => s.DefaultHeroPower).Return(129);

            var h = new Hero(staticVal);

            Assert.AreEqual(3, h.Coins);
            Assert.AreEqual(33.2f, h.Health);
            Assert.AreEqual(55, 5f, h.MaxHealth);
            Assert.AreEqual(129, h.Power);
        }

        [Test]
        public void DecreaseHealthRel_SetsExpectedHealth()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroHealth).Return(50);

            var h = new Hero(staticVal);
            h.TakeHealthRel(0.5f);

            Assert.AreEqual(25.0f, h.Health);
        }

        [Test]
        public void DecreaseHealth_SetsExpectedHealth()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroHealth).Return(77);

            var h = new Hero(staticVal);
            h.TakeHealth(10);

            Assert.AreEqual(67, h.Health);
        }

        [Test]
        public void DecreaseHealth_NotEnoghHealth_SetsHealthToZero()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroHealth).Return(30);

            var h = new Hero(staticVal);
            h.TakeHealth(40);

            Assert.AreEqual(0, h.Health);
        }

        [Test]
        public void DecreaseHealth_NotEnoghHealth_RaisesDeathEvent()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroHealth).Return(40);

            var h = new Hero(staticVal);

            h.Died += (s, ea) => Assert.Pass();

            h.TakeHealth(40);

            Assert.Fail();
        }

        [Test]
        public void AddCoins_SetsExpectedCoinsCount()
        {
            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.DefaultHeroeCoins).Return(33);

            var h = new Hero(staticVal);
            h.AddCoins(22);

            Assert.AreEqual(55, h.Coins);
        }

        [Test]
        public void TakeCoins_EnoughCoins_SubstructsCoins()
        {
            var h = new Hero(MockRepository.GenerateStub<IStaticValues>());
            h.Coins = 5;
            h.TakeCoins(3);
            Assert.AreEqual(2, h.Coins);
        }

        [Test]
        public void TakeCoins_NotEnoughCoins_ThrowsEngineException()
        {
            var h = new Hero(MockRepository.GenerateStub<IStaticValues>());
            h.Coins = 3;
            Assert.Throws<EngineException>(() => h.TakeCoins(4));
        }

        [Test]
        public void IncreasePower_IncreasesPowerBySpecifiedValue()
        {
            var h = new Hero(MockRepository.GenerateStub<IStaticValues>());
            h.Power = 3;
            h.IncreasePower(4);
            Assert.AreEqual(7, h.Power);
        }

        [Test]
        public void IncreaseMaxHealth_IncreasesMaxHealthBySpecifiedValue()
        {
            var h = new Hero(MockRepository.GenerateStub<IStaticValues>());
            h.MaxHealth = 5;
            h.IncreaseMaxHealth(10);
            Assert.AreEqual(15, h.MaxHealth);
        }

        [Test]
        public void AddHealth_AddsSpecifiedHealth()
        {
            var h = new Hero(MockRepository.GenerateStub<IStaticValues>());
            h.MaxHealth = 100;
            h.Health = 33;
            h.AddHealth(12.5f);
            Assert.AreEqual(45.5f, h.Health);
        }

        [Test]
        public void AddHealth_TooMuchHealth_HealthEqualMaxHealth()
        {
            var h = new Hero(MockRepository.GenerateStub<IStaticValues>());
            h.MaxHealth = 100;
            h.Health = 90;
            h.AddHealth(20);
            Assert.AreEqual(100, h.Health);
        }
    }
}
