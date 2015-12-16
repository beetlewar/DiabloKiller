using System;
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
        private readonly List<IHeroModifier> _modifiers = new List<IHeroModifier>();

        internal IStaticValues StaticValues { get; private set; }
        internal IHeroModifier[] Modifiers
        {
            get { return this._modifiers.ToArray(); }
        }

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
            this.Coins = this.StaticValues.DefaultHeroeCoins;
        }

        public void DecreaseHealthRel(float percent)
        {
            this.Health -= (percent * this.Health);
        }

        public void DecreaseHealth(float health)
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

        public void AddModifier(IHeroModifier modifier)
        {
            if(modifier == null)
            {
                throw new ArgumentNullException("modifier");
            }
            this._modifiers.Add(modifier);
            modifier.Modify(this);
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
