using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Battle : ACommand
    {
        public Battle(IHeroe heroe) :
            this(heroe, null, null)
        {
        }

        internal Battle(
            IHeroe heroe, 
            IRandomizer randomizer,
            IStaticValues staticValues) :
            base(heroe, randomizer, staticValues)
        {
        }

        public void Execute()
        {
            var chanceToWin = Math.Min(
                    this.StaticValues.BaseChanceToWin + this.Heroe.Power * this.StaticValues.PowerEffectToWin,
                    this.StaticValues.MaxChanceToWin);

            if(!this.Randimozer.RandomizeBool(chanceToWin))
            {
                // игрок проиграл, отнимаем здоровье
                this.Heroe.DecreaseHealth(this.StaticValues.HealthLostAfterDefeat);
            }
            else
            {
                // игрок выиграл, отнимаем процент здоровья и прибавляем монет
                this.Heroe.DecreaseHealthRel(this.StaticValues.HealthLostAfterWinRel);
                this.Heroe.AddCoins(this.StaticValues.CoinsGainedAfterWin);
            }
        }
    }
}
