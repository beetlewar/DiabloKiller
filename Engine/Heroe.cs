using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class Heroe : IHeroe
    {
        public event EventHandler Died;

        private float _health;

        internal IStaticValues StaticValues { get; private set; }

        public float Health
        {
            get { return this._health; }
            private set
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

        public float MaxHealth { get; private set; }

        public int Power { get; private set; }

        public int Coins { get; private set; }

        public Heroe() : this(null) { }

        internal Heroe(IStaticValues staticValues)
        {
            this.StaticValues = staticValues ?? new StaticValues();

            this.Health = this.StaticValues.DefaultHeroeHealth;
            this.MaxHealth = this.StaticValues.DefaultHeroeMaxHealth;
            this.Power = this.StaticValues.DefaultHeroePower;
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
    }
}
