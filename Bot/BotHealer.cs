using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public class BotHealer :
        ABotCommand
    {    
        public BotHealer(
            IHero hero,
            IStaticValues staticValues) :
            this(hero, staticValues, new Healer(hero, staticValues))
        {
        }

        internal BotHealer(
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
                if (this.Hero.Coins >= this.StaticValues.HealPrice)
                {
                    return
                        this.Hero.Health < this.Hero.Health ?
                        BotCommandAvailability.Allowed :
                        BotCommandAvailability.NotRecommended;
                }
                else
                {
                    return BotCommandAvailability.Forbidden;
                }
            }
        }

        public override int Order
        {
            get { return 3; }
        }
    }
}
