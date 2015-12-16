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

            new ArmorSeller(hero, MockRepository.GenerateStub<IRandomizer>(), staticVal).Execute();

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

            new ArmorSeller(MockRepository.GenerateStub<IHero>(), rnd, staticVal).Execute();

            rnd.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockHero_IncreasesHoeroesMaxHealth()
        {
            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.IncreaseMaxHealth(22));

            var randomizer = MockRepository.GenerateStub<IRandomizer>();
            randomizer.Stub(r => r.RandomizeInt(0, 0)).IgnoreArguments().Return(22);

            new ArmorSeller(hero, randomizer, MockRepository.GenerateStub<IStaticValues>()).Execute();

            hero.VerifyAllExpectations();
        }
    }
}
