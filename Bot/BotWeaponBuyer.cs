using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public class BotWeaponBuyer :
        ABotCommand,
        IBotCommand
    {
        public BotWeaponBuyer(
            IHero hero,
            IStaticValues staticValues) :
            this(hero, staticValues, new WeaponSeller(hero, staticValues))
        {
        }

        internal BotWeaponBuyer(
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
#warning здесь надо сделать проверку того, что мы не достигли максимального значения, если достигли то покупать нельзя (или не рекомендуется)
                return
                    this.Hero.Coins >= this.StaticValues.WeaponPrice ?
                    BotCommandAvailability.Allowed :
                    BotCommandAvailability.Forbidden;
            }
        }

        public override int Order
        {
            get { return 1; }
        }
    }
}
