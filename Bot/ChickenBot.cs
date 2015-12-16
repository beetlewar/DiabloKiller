using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    /// <summary>
    /// Трусливый бот, который предпочитает драться лишь в крайнем случае
    /// </summary>
    public class ChickenBot : ACommand
    {
        public ChickenBot(
            IHero hero, 
            IStaticValues staticValues) :
            base(hero, null, staticValues, null)
        {
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
                "у бота нет доступных команд на исполнение" :
                string.Format("бот выбрал {0}", cmd);
        }

        private ICommand GetCurrentCommand()
        {
            bool bMaxPowerExceeded = 
                Battle.GetChanceToWin(this.StaticValues, this.Hero) >= this.StaticValues.MaxChanceToWin;

            if((this.Hero.Health + this.StaticValues.HealEffect) < this.Hero.MaxHealth &&
                this.Hero.Coins >= this.StaticValues.HealPrice)
            {
                // если неполное здоровье и есть деньги, то идем лечиться
                return new Healer(this.Hero, this.StaticValues);
            }
            else if (!bMaxPowerExceeded &&
                this.Hero.Coins >= this.StaticValues.WeaponPrice)
            {
                // если достаточно денег на покупку оружия и она даст эффект, то покупаем
                return new WeaponSeller(this.Hero, this.StaticValues);
            }
            else if(bMaxPowerExceeded &&
                this.Hero.Coins >= this.StaticValues.ArmorPrice)
            {
                // если у нас хорошее здоровье и мы полны сил, то начинаем закупать шмотки
                return new ArmorSeller(this.Hero, this.StaticValues);
            }
            else
            {
                return new Battle(this.Hero, this.StaticValues);
            }
        }
    }
}
