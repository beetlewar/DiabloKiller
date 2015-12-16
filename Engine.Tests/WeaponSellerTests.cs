﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using Rhino.Mocks;

namespace Engine.Tests
{
    [TestFixture]
    public class WeaponSellerTests
    {
        [Test]
        public void Ctor_NullHero_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WeaponSeller(null, MockRepository.GenerateStub<IStaticValues>()));
        }

        [Test]
        public void Ctor_NullStaticValues_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new WeaponSeller(MockRepository.GenerateStub<IHero>(), null));
        }

        [Test]
        public void Ctor_NonNullHero_SetsHero()
        {
            var h = MockRepository.GenerateStub<IHero>();
            var s = new WeaponSeller(h, MockRepository.GenerateStub<IRandomizer>(), MockRepository.GenerateStub<IStaticValues>(), MockRepository.GenerateStub<IHeroModifierFactory>());

            Assert.AreSame(h, s.Hero);
        }

        [Test]
        public void Execute_MockHero_TakesExpectedCoins()
        {
            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.TakeCoins(22));

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.WeaponPrice).Return(22);

            new WeaponSeller(hero, MockRepository.GenerateStub<IRandomizer>(), staticVal, MockRepository.GenerateStub<IHeroModifierFactory>()).Execute();

            hero.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockRandomizer_CallsRandomizeWithinExpectedRange()
        {
            var rnd = MockRepository.GenerateMock<IRandomizer>();
            rnd.Expect(r => r.RandomizeInt(3, 15)).Return(4);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.WeaponMinPower).Return(3);
            staticVal.Stub(s => s.WeaponMaxPower).Return(15);

            new WeaponSeller(MockRepository.GenerateStub<IHero>(), rnd, staticVal, MockRepository.GenerateStub<IHeroModifierFactory>()).Execute();

            rnd.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockModifierFactory_CreatesWeaponWithRandomizedValue()
        {
            var fac = MockRepository.GenerateMock<IHeroModifierFactory>();
            fac.Expect(f => f.CreateWeapon(13));

            var rnd = MockRepository.GenerateStub<IRandomizer>();
            rnd.Stub(r => r.RandomizeInt(0, 0)).IgnoreArguments().Return(13);

            new WeaponSeller(MockRepository.GenerateStub<IHero>(), rnd, MockRepository.GenerateStub<IStaticValues>(), fac).Execute();

            fac.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockHero_AddsExpectedModifier()
        {
            var mod = MockRepository.GenerateStub<IHeroModifier>();

            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.AddModifier(mod));

            var fac = MockRepository.GenerateStub<IHeroModifierFactory>();
            fac.Stub(f => f.CreateWeapon(0)).IgnoreArguments().Return(mod);

            new WeaponSeller(hero, MockRepository.GenerateStub<IRandomizer>(), MockRepository.GenerateStub<IStaticValues>(), fac).Execute();

            hero.VerifyAllExpectations();
        }
    }
}
