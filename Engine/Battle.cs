using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Battle : ACommand
    {
        public Battle(IHero hero, IStaticValues staticValues) :
            this(hero, null, staticValues)
        {
        }

        internal Battle(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues) :
            base(hero, randomizer, staticValues, null)
        {
        }

        public override void Execute()
        {
            var chanceToWin = Math.Min(
                    this.StaticValues.BaseChanceToWin + this.Hero.Power * this.StaticValues.PowerEffectToWin,
                    this.StaticValues.MaxChanceToWin);

            if(!this.Randimozer.RandomizeBool(chanceToWin))
            {
                // игрок проиграл, отнимаем здоровье
                this.Hero.DecreaseHealth(this.StaticValues.HealthLostAfterDefeat);
            }
            else
            {
                // игрок выиграл, отнимаем процент здоровья и прибавляем монет
                this.Hero.DecreaseHealthRel(this.StaticValues.HealthLostAfterWinRel);
                this.Hero.AddCoins(this.StaticValues.CoinsGainedAfterWin);
            }
        }

        public override string ToString()
        {
            return "Сражение с монстром";
        }
    }
}
