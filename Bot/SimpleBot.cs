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
        public SimpleBot(IHero hero, IStaticValues staticValues) :
            this(hero, null, staticValues)
        {
        }

        internal SimpleBot(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues) :
            base(hero, randomizer, staticValues, null)
        {
        }

        public override string Execute()
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return "бот определяет, что делать";
        }
    }
}
