using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public class BotFighter :
        ABotCommand
  {    
        public BotFighter(
            IHero hero,
            IStaticValues staticValues) :
            this(hero, staticValues, new Battle(hero, staticValues))
        {
        }

        internal BotFighter(
            IHero hero,
            IStaticValues staticValues,
            ICommand command) :
            base(hero, staticValues, command)
        {
        }

        public override BotCommandAvailability Availability
        {
            get 
            {
                // лучше вообще никогда не драться!
                return BotCommandAvailability.NotRecommended;
            }
        }

        public override int Order
        {
            get { return 4; }
        }
    }
}
