using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace TheGame
{
    public class Game
    {
        public IHeroe Heroe { get; private set; }
        public IStaticValues StaticValues { get; private set; }

        private readonly Dictionary<ConsoleKey, ICommand> _commands;

        public Game()
        {
            this.StaticValues = (StaticValues)System.Configuration.ConfigurationManager.GetSection("staticValues");
            this.Heroe = new Heroe(this.StaticValues);

            this._commands = new Dictionary<ConsoleKey, ICommand>()
            {
                {ConsoleKey.W, (ICommand)new Battle(this.Heroe, this.StaticValues)},
                {ConsoleKey.A, (ICommand)new WeaponSeller(this.Heroe, this.StaticValues)},
            };
        }

        public void ProcessKey(ConsoleKey key)
        {
            ICommand cmd;
            if (this._commands.TryGetValue(key, out cmd))
            {
                Console.WriteLine("Выполняется команда: {0}", cmd);
                cmd.Execute();
            }
            else
            {
                Console.WriteLine("Данная команда не поддерживается");
            }
        }
    }
}
