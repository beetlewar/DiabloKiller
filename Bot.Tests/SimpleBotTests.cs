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
    public class SimpleBotTests
    {
        [Test]
        public void Execute_ProvideAllowedCommands_CallsWithBetterOrder()
        {
            var e1 = MockRepository.GenerateMock<IBotCommand>();
            e1.Expect(e => e.Execute()).Return(null);
            e1.Stub(e => e.Order).Return(1);
            e1.Stub(e => e.Availability).Return(BotCommandAvailability.Allowed);

            var e2 = MockRepository.GenerateStub<IBotCommand>();
            e2.Stub(e => e.Order).Return(2);
            e2.Stub(e => e.Availability).Return(BotCommandAvailability.Allowed);

            new SimpleBot(
                MockRepository.GenerateStub<IHero>(),
                MockRepository.GenerateStub<IStaticValues>(),
                new[] { e1, e2 }).Execute();

            e1.VerifyAllExpectations();
        }

        [Test]
        public void Execute_CommandWithBetterOrderNotRecommended_CallsWithWorseOrder()
        {
            var e1 = MockRepository.GenerateMock<IBotCommand>();
            e1.Expect(e => e.Execute()).Return(null);
            e1.Stub(e => e.Order).Return(10);
            e1.Stub(e => e.Availability).Return(BotCommandAvailability.Allowed);

            var e2 = MockRepository.GenerateStub<IBotCommand>();
            e2.Stub(e => e.Order).Return(2);
            e2.Stub(e => e.Availability).Return(BotCommandAvailability.NotRecommended);

            new SimpleBot(
                MockRepository.GenerateStub<IHero>(),
                MockRepository.GenerateStub<IStaticValues>(),
                new[] { e1, e2 }).Execute();

            e1.VerifyAllExpectations();
        }

        [Test]
        public void Execute_OnlyNotRecommendedCommands_CallsWithBetterOrder()
        {
            var e1 = MockRepository.GenerateMock<IBotCommand>();
            e1.Expect(e => e.Execute()).Return(null);
            e1.Stub(e => e.Order).Return(1);
            e1.Stub(e => e.Availability).Return(BotCommandAvailability.NotRecommended);

            var e2 = MockRepository.GenerateStub<IBotCommand>();
            e2.Stub(e => e.Order).Return(2);
            e2.Stub(e => e.Availability).Return(BotCommandAvailability.NotRecommended);

            new SimpleBot(
                MockRepository.GenerateStub<IHero>(),
                MockRepository.GenerateStub<IStaticValues>(),
                new[] { e2, e1 }).Execute();

            e1.VerifyAllExpectations();
        }

        [Test]
        public void Execute_CommandWithBetterOrderForbidden_CallsWithWorseOrder()
        {
            var e1 = MockRepository.GenerateMock<IBotCommand>();
            e1.Expect(e => e.Execute()).Return(null);
            e1.Stub(e => e.Order).Return(12);
            e1.Stub(e => e.Availability).Return(BotCommandAvailability.NotRecommended);

            var e2 = MockRepository.GenerateStub<IBotCommand>();
            e2.Stub(e => e.Order).Return(1);
            e2.Stub(e => e.Availability).Return(BotCommandAvailability.Forbidden);

            new SimpleBot(
                MockRepository.GenerateStub<IHero>(),
                MockRepository.GenerateStub<IStaticValues>(),
                new[] { e1, e2 }).Execute();

            e1.VerifyAllExpectations();
        }

        [Test]
        public void Execute_OnlyForbiddenCommands_ThrowsEngineException()
        {
            var e1 = MockRepository.GenerateStub<IBotCommand>();
            e1.Stub(e => e.Order).Return(1);
            e1.Stub(e => e.Availability).Return(BotCommandAvailability.Forbidden);

            var e2 = MockRepository.GenerateStub<IBotCommand>();
            e2.Stub(e => e.Order).Return(2);
            e2.Stub(e => e.Availability).Return(BotCommandAvailability.Forbidden);

            Assert.Throws<EngineException>(() => new SimpleBot(
                MockRepository.GenerateStub<IHero>(),
                MockRepository.GenerateStub<IStaticValues>(),
                new[] { e1, e2 }).Execute());
        }
    }
}
