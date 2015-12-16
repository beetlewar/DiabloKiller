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

        [Test]
        public void AddModifier_NullModifier_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Heroe(MockRepository.GenerateStub<IStaticValues>()).AddModifier(null));
        }

        [Test]
        public void AddModifier_AddsModifierToTheCollection()
        {
            var modifier = MockRepository.GenerateStub<IHeroeModifier>();

            var h = new Heroe(MockRepository.GenerateStub<IStaticValues>());
            h.AddModifier(modifier);

            Assert.AreEqual(1, h.Modifiers.Length);
            Assert.AreSame(modifier, h.Modifiers.Single());
        }

        [Test]
        public void AddModifier_MockModifier_CallsModifyToModifier()
        {
            var h = new Heroe(MockRepository.GenerateStub<IStaticValues>());

            var modifier = MockRepository.GenerateMock<IHeroeModifier>();
            modifier.Expect(m => m.Modify(h));

            h.AddModifier(modifier);

            modifier.VerifyAllExpectations();
        }

        [Test]
        public void TakeCoins_EnoughCoins_SubstructsCoins()
        {
            var h = new Heroe(MockRepository.GenerateStub<IStaticValues>());
            h.Coins = 5;
            h.TakeCoins(3);
            Assert.AreEqual(2, h.Coins);
        }

        [Test]
        public void TakeCoins_NotEnoughCoins_ThrowsEngineException()
        {
            var h = new Heroe(MockRepository.GenerateStub<IStaticValues>());
            h.Coins = 3;
            Assert.Throws<EngineException>(() => h.TakeCoins(4));
        }

        [Test]
        public void IncreasePower_IncreasesPowerBySpecifiedValue()
        {
            var h = new Heroe(MockRepository.GenerateStub<IStaticValues>());
            h.Power = 3;
            h.IncreasePower(4);
            Assert.AreEqual(7, h.Power);
        }
    }
}
