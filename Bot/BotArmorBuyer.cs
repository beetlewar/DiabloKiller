using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public class BotArmorBuyer :
        ABotCommand
    {        
        public BotArmorBuyer(
            IHero hero,
            IStaticValues staticValues) :
            this(hero, staticValues, new ArmorSeller(hero, staticValues))
        {
        }

        internal BotArmorBuyer(
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
                return
                    this.Hero.Coins >= this.StaticValues.ArmorPrice ?
                    BotCommandAvailability.NotRecommended :
                    BotCommandAvailability.Forbidden;
            }
        }

        public override int Order
        {
            get { return 2; }
        }
    }
}
