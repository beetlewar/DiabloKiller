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
    public class BattleTests
    {
        [Test]
        public void Ctor_NullHeroe_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Battle(null, MockRepository.GenerateStub<IStaticValues>()));
        }

        [Test]
        public void Ctor_NullStaticValues_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new Battle(MockRepository.GenerateStub<IHeroe>(), null));
        }

        [Test]
        public void Execute_HeroesChanceToWinLessThanMaxChance_CallsRandomizeBasedOnHeroesChance()
        {
            var random = MockRepository.GenerateMock<IRandomizer>();
            random.Expect(r => r.RandomizeBool(0.3f)).Return(false);

            var heroe = MockRepository.GenerateStub<IHeroe>();
            heroe.Stub(h => h.Power).Return(2);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.MaxChanceToWin).Return(0.5f);
            staticVal.Stub(s => s.BaseChanceToWin).Return(0.2f);
            staticVal.Stub(s => s.PowerEffectToWin).Return(0.05f);

            new Battle(heroe, random, staticVal).Execute();

            random.VerifyAllExpectations();
        }

        [Test]
        public void Execute_HeroesChanceToWinGreaterThanMaxChance_CallsRandomizeBasedOnMaxChance()
        {
            var random = MockRepository.GenerateMock<IRandomizer>();
            random.Expect(r => r.RandomizeBool(0.5f)).Return(false);

            var heroe = MockRepository.GenerateStub<IHeroe>();
            heroe.Stub(h => h.Power).Return(10);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.MaxChanceToWin).Return(0.5f);
            staticVal.Stub(s => s.BaseChanceToWin).Return(0.2f);
            staticVal.Stub(s => s.PowerEffectToWin).Return(0.05f);

            new Battle(heroe, random, staticVal).Execute();

            random.VerifyAllExpectations();
        }

        [Test]
        public void Execute_LosesTheBattle_DecreasesHealthBySpecifiedValue()
        {
            var heroe = MockRepository.GenerateMock<IHeroe>();
            heroe.Expect(h => h.DecreaseHealth(20.0f));

            var random = MockRepository.GenerateStub<IRandomizer>();
            random.Stub(r => r.RandomizeBool(default(float))).IgnoreArguments().Return(false);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.HealthLostAfterDefeat).Return(20.0f);

            new Battle(heroe, random, staticVal).Execute();

            heroe.VerifyAllExpectations();
        }

        [Test]
        public void Execute_WinsTheBattle_DecreasesHealthRelBySpecifiedValue()
        {
            var heroe = MockRepository.GenerateMock<IHeroe>();
            heroe.Expect(h => h.DecreaseHealthRel(0.2f));

            var random = MockRepository.GenerateStub<IRandomizer>();
            random.Stub(r => r.RandomizeBool(default(float))).IgnoreArguments().Return(true);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.HealthLostAfterWinRel).Return(0.2f);

            new Battle(heroe, random, staticVal).Execute();

            heroe.VerifyAllExpectations();
        }

        [Test]
        public void Execute_WinsTheBattle_IncreasesCoinsBySpecifiedValue()
        {
            var heroe = MockRepository.GenerateMock<IHeroe>();
            heroe.Expect(h => h.AddCoins(3));

            var random = MockRepository.GenerateStub<IRandomizer>();
            random.Stub(r => r.RandomizeBool(default(float))).IgnoreArguments().Return(true);

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.CoinsGainedAfterWin).Return(3);

            new Battle(heroe, random, staticVal).Execute();

            heroe.VerifyAllExpectations();
        }
    }
}
