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
    public class ArmorSellerTests
    {
        [Test]
        public void Execute_MockHero_TakesExpectedCoins()
        {
            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.TakeCoins(18));

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.ArmorPrice).Return(18);

            new ArmorSeller(hero, MockRepository.GenerateStub<IRandomizer>(), staticVal, MockRepository.GenerateStub<IHeroModifierFactory>()).Execute();

            hero.VerifyAllExpectations();
        }
        [Test]
        public void Execute_MockRandomizer_CallsRandomizeWithinExpectedRange()
        {
            var rnd = MockRepository.GenerateMock<IRandomizer>();
            rnd.Expect(r => r.RandomizeInt(9, 109)).Return(33);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.ArmorMinHealth).Return(9);
            staticVal.Stub(s => s.ArmorMaxHealth).Return(109);

            new ArmorSeller(MockRepository.GenerateStub<IHero>(), rnd, staticVal, MockRepository.GenerateStub<IHeroModifierFactory>()).Execute();

            rnd.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockModifierFactory_CreatesWeaponWithRandomizedValue()
        {
            var fac = MockRepository.GenerateMock<IHeroModifierFactory>();
            fac.Expect(f => f.CreateArmor(221));

            var rnd = MockRepository.GenerateStub<IRandomizer>();
            rnd.Stub(r => r.RandomizeInt(0, 0)).IgnoreArguments().Return(221);

            new ArmorSeller(MockRepository.GenerateStub<IHero>(), rnd, MockRepository.GenerateStub<IStaticValues>(), fac).Execute();

            fac.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockHero_AddsExpectedModifier()
        {
            var mod = MockRepository.GenerateStub<IHeroModifier>();

            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.AddModifier(mod));

            var fac = MockRepository.GenerateStub<IHeroModifierFactory>();
            fac.Stub(f => f.CreateArmor(0)).IgnoreArguments().Return(mod);

            new ArmorSeller(hero, MockRepository.GenerateStub<IRandomizer>(), MockRepository.GenerateStub<IStaticValues>(), fac).Execute();

            hero.VerifyAllExpectations();
        }
    }
}
