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
        private readonly List<IHeroeModifier> _modifiers = new List<IHeroeModifier>();

        internal IStaticValues StaticValues { get; private set; }
        internal IHeroeModifier[] Modifiers
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

        public void TakeCoins(int count)
        {
            if(count > this.Coins)
            {
                throw new EngineException("Недостаточно монет");
            }
            this.Coins -= count;
        }

        public void AddModifier(IHeroeModifier modifier)
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
    }
}
