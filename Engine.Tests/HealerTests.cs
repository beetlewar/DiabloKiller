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
    public class HealerTests
    {
        [Test]
        public void Execute_MockHero_TakesExpectedCoins()
        {
            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h=>h.TakeCoins(3));

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.HealPrice).Return(3);

            new Healer(hero, MockRepository.GenerateStub<IRandomizer>(), staticVal).Execute();

            hero.VerifyAllExpectations();
        }

        [Test]
        public void Execute_MockHero_AddsExpectedHealth()
        {
            var hero = MockRepository.GenerateMock<IHero>();
            hero.Expect(h => h.AddHealth(999.2f));

            var staticVal = MockRepository.GenerateStub<IStaticValues>();
            staticVal.Stub(s => s.HealEffect).Return(999.2f);

            new Healer(hero, MockRepository.GenerateStub<IRandomizer>(), staticVal).Execute();

            hero.VerifyAllExpectations();
        }
    }
}
