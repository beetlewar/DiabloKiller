using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Battle : ACommand
    {
        public static float GetChanceToWin(
            IStaticValues staticValues,
            IHero hero)
        {
            return Math.Min(
                staticValues.BaseChanceToWin + hero.Power * staticValues.PowerEffectToWin,
                staticValues.MaxChanceToWin);
        }

        public Battle(IHero hero, IStaticValues staticValues) :
            this(hero, null, staticValues)
        {
        }

        internal Battle(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues) :
            base(hero, randomizer, staticValues)
        {
        }

        public override string Execute()
        {
            var chanceToWin = GetChanceToWin(this.StaticValues, this.Hero);

            if(!this.Randimozer.RandomizeBool(chanceToWin))
            {
                // игрок проиграл, отнимаем здоровье
                this.Hero.TakeHealth(this.StaticValues.HealthLostAfterDefeat);

                return string.Format(
                    "Поражение:( Игрок потерял {0} здоровья при {1:p0} шансе на победу", 
                    this.StaticValues.HealthLostAfterDefeat,
                    chanceToWin);
            }
            else
            {
                // игрок выиграл, отнимаем процент здоровья и прибавляем монет
                var prevHealth = this.Hero.Health;
                this.Hero.TakeHealthRel(this.StaticValues.HealthLostAfterWinRel);
                this.Hero.AddCoins(this.StaticValues.CoinsGainedAfterWin);

                return string.Format(
                    "Победа! Игрок потерял {0} здоровья, но заработал {1} монет при {2:p0} шансе на победу",
                    Math.Round(prevHealth - this.Hero.Health, 2),
                    this.StaticValues.CoinsGainedAfterWin,
                    chanceToWin);
            }
        }

        public override string ToString()
        {
            return "Сражение с монстром";
        }
    }
}
