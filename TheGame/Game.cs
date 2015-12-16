using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bot;
using Engine;

namespace TheGame
{
    public class Game
    {
        public IHero Hero { get; private set; }
        public IStaticValues StaticValues { get; private set; }

        private readonly Dictionary<ConsoleKey, ICommand> _commands;

        public Game(IStaticValues staticValues)
        {
            this.StaticValues = staticValues;
            this.Hero = new Hero(this.StaticValues);

            this._commands = new Dictionary<ConsoleKey, ICommand>()
            {
                {ConsoleKey.W, (ICommand)new Battle(this.Hero, this.StaticValues)},
                {ConsoleKey.A, (ICommand)new WeaponSeller(this.Hero, this.StaticValues)},
                {ConsoleKey.D, (ICommand)new ArmorSeller(this.Hero, this.StaticValues)},
                {ConsoleKey.S, (ICommand)new Healer(this.Hero, this.StaticValues)},
                {ConsoleKey.E, (ICommand)new ChickenBot(this.Hero, this.StaticValues)}
            };
        }

        public void ProcessKey(ConsoleKey key)
        {
            ICommand cmd;
            if (this._commands.TryGetValue(key, out cmd))
            {
                Console.WriteLine("Выполняется команда: {0}", cmd);
                var result = cmd.Execute();
                Console.WriteLine("выполнено: {0}", result);
            }
            else
            {
                Console.WriteLine("Данная команда не поддерживается");
            }
        }
    }
}
