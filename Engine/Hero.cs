﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Hero : IHero
    {
        public event EventHandler Died;

        private float _health;

        public IStaticValues StaticValues { get; private set; }

        public float Health
        {
            get { return this._health; }
            internal set
            {
                this._health = value;
                if(this._health <= 0)
                {
                    var h = this.Died;
                    if( h != null)
                    {
                        h(this, EventArgs.Empty);
                    }
                }
            }
        }

        public float MaxHealth { get; internal set; }

        public int Power { get; internal set; }

        public int Coins { get; internal set; }

        public Hero(IStaticValues staticValues)
        {
            this.StaticValues = staticValues;

            this.Health = this.StaticValues.DefaultHeroHealth;
            this.MaxHealth = this.StaticValues.DefaultHeroMaxHealth;
            this.Power = this.StaticValues.DefaultHeroPower;
            this.Coins = this.StaticValues.DefaultHeroCoins;
        }

        public void AddHealth(float health)
        {
            var currentHealth = this.Health + health;
            this.Health = Math.Min(this.MaxHealth, currentHealth);
        }

        public void TakeHealthRel(float percent)
        {
            this.Health -= (percent * this.Health);
        }

        public void TakeHealth(float health)
        {
            this.Health = Math.Max(0, this.Health - health);
        }

        public void AddCoins(int count)
        {
            this.Coins += count;
        }

        public void TakeCoins(int count)
        {
            if(count > this.Coins)
            {
                throw new EngineException("Недостаточно монет");
            }
            this.Coins -= count;
        }

        public void IncreasePower(int power)
        {
            this.Power += power;
        }

        public void IncreaseMaxHealth(float health)
        {
            this.MaxHealth += health;
        }

        public override string ToString()
        {
            return string.Join(
                "\n", 
                string.Format("Здоровье = {0}", this.Health),
                string.Format("Макс. здоровье = {0}", this.MaxHealth),
                string.Format("Мощь = {0}", this.Power),
                string.Format("Монеты = {0}", this.Coins));
        }
    }
}
