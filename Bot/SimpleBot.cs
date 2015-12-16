using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public class SimpleBot : ACommand
    {
        private readonly List<IBotCommand> _commands;

        public SimpleBot(
            IHero hero, 
            IStaticValues staticValues, 
            IEnumerable<IBotCommand> commands) :
            base(hero, null, staticValues, null)
        {
            this._commands = new List<IBotCommand>(commands);
            this._commands.Sort((x, y) => x.Order.CompareTo(y.Order));
        }

        public override string Execute()
        {
            var cmd = this.GetCurrentCommand();

            if(cmd == null)
            {
                throw new EngineException("Нет доступных действий");
            }

            return cmd.Execute();
        }

        public override string ToString()
        {
            var cmd = this.GetCurrentCommand();
            return 
                cmd == null ?
                "у бота нет доступных команда на исполнение" :
                string.Format("бот выбрал {0}", cmd);
        }

        private ICommand GetCurrentCommand()
        {
            var cmd = this._commands.FirstOrDefault(c => c.Availability == BotCommandAvailability.Allowed);
            if (cmd == null)
            {
                cmd = this._commands.FirstOrDefault(c => c.Availability == BotCommandAvailability.NotRecommended);
            }
            return cmd;
        }
    }
}
