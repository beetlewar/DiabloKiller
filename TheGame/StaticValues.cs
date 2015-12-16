using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace TheGame
{
    public class StaticValues : 
        ConfigurationSection,
        IStaticValues
    {
        [ConfigurationProperty("maxChanceToWin", DefaultValue = 0.7f)]
        public float MaxChanceToWin
        {
            get { return (float)this["maxChanceToWin"]; }
            set { this["maxChanceToWin"] = value; }
        }

        [ConfigurationProperty("baseChanceToWin", DefaultValue = 0.4f)]
        public float BaseChanceToWin
        {
            get { return (float)this["baseChanceToWin"]; }
            set { this["baseChanceToWin"] = value; }
        }

        [ConfigurationProperty("powerEffectToWin", DefaultValue = 0.05f)]
        public float PowerEffectToWin
        {
            get { return (float)this["powerEffectToWin"]; }
            set { this["powerEffectToWin"] = value; }
        }

        [ConfigurationProperty("healthLostAfterDefeat", DefaultValue = 40.0f)]
        public float HealthLostAfterDefeat
        {
            get { return (float)this["healthLostAfterDefeat"]; }
            set { this["healthLostAfterDefeat"] = value; }
        }

        [ConfigurationProperty("healthLostAfterWinRel", DefaultValue = 0.1f)]
        public float HealthLostAfterWinRel
        {
            get { return (float)this["healthLostAfterWinRel"]; }
            set { this["healthLostAfterWinRel"] = value; }
        }

        [ConfigurationProperty("coinsPerWin", DefaultValue = 5)]
        public int CoinsGainedAfterWin
        {
            get { return (int)this["coinsPerWin"]; }
            set { this["coinsPerWin"] = value; }
        }

        [ConfigurationProperty("defaultHealth", DefaultValue = 100.0f)]
        public float DefaultHeroeHealth
        {
            get { return (float)this["defaultHealth"]; }
            set { this["defaultHealth"] = value; }
        }

        [ConfigurationProperty("defaultMaxHealth", DefaultValue = 100.0f)]
        public float DefaultHeroeMaxHealth
        {
            get { return (float)this["defaultMaxHealth"]; }
            set { this["defaultMaxHealth"] = value; }
        }

        [ConfigurationProperty("defaultPower", DefaultValue = 1)]
        public int DefaultHeroePower
        {
            get { return (int)this["defaultPower"]; }
            set { this["defaultPower"] = value; }
        }

        [ConfigurationProperty("defaultCoins", DefaultValue = 2)]
        public int DefaultHeroeCoins
        {
            get { return (int)this["defaultCoins"]; }
            set { this["defaultCoins"] = value; }
        }

        [ConfigurationProperty("weaponPrice", DefaultValue = 10)]
        public int WeaponPrice
        {
            get { return (int)this["weaponPrice"]; }
            set { this["weaponPrice"] = value; }
        }

        [ConfigurationProperty("weaponMinPower", DefaultValue = 1)]
        public int WeaponMinPower
        {
            get { return (int)this["weaponMinPower"]; }
            set { this["weaponMinPower"] = value; }
        }

        [ConfigurationProperty("weaponMaxPower", DefaultValue = 2)]
        public int WeaponMaxPower
        {
            get { return (int)this["weaponMaxPower"]; }
            set { this["weaponMaxPower"] = value; }
        }
    }
}
