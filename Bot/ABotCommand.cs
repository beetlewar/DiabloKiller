using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public abstract class ABotCommand :
        ACommand,
        IBotCommand
    {
        public ICommand Command { get; private set; }

        protected ABotCommand(
            IHero hero,
            IStaticValues staticValues,
            ICommand command) :
            base(hero, null, staticValues, null)
        {
            this.Command = command;
        }

        public abstract BotCommandAvailability Availability { get; }

        public abstract int Order { get; }

        public override string Execute()
        {
            return this.Command.Execute();
        }

        public override string ToString()
        {
            return this.Command.ToString();
        }
    }
}
