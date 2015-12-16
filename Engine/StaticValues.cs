using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class StaticValues : IStaticValues
    {
        public float MaxChanceToWin { get; set; }

        public float BaseChanceToWin { get; set; }

        public float PowerEffectToWin { get; set; }

        public float HealthLostAfterDefeat { get; set; }

        public float HealthLostAfterWinRel { get; set; }

        public int CoinsGainedAfterWin { get; set; }

        public float DefaultHeroeHealth { get; set; }

        public float DefaultHeroeMaxHealth { get; set; }

        public int DefaultHeroePower { get; set; }

        public int DefaultHeroeCoins { get; set; }

        public int WeaponPrice { get; set; }

        public int WeaponMinPower { get; set; }

        public int WeaponMaxPower { get; set; }
    }
}
