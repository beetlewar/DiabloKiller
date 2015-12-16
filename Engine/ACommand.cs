using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class ACommand : ICommand
    {
        public IHero Hero { get; private set; }
        internal IRandomizer Randimozer { get; private set; }
        internal IStaticValues StaticValues { get; private set; }
        internal IHeroModifierFactory ModifierFactory { get; private set; }

        protected ACommand(
            IHero hero, 
            IRandomizer randomizer,
            IStaticValues staticValues,
            IHeroModifierFactory modifierFactory)
        {
            if(hero == null)
            {
                throw new ArgumentNullException("hero");
            }
            if(staticValues == null)
            {
                throw new ArgumentNullException("staticValues");
            }

            this.Hero = hero;
            this.StaticValues = staticValues;

            this.Randimozer = randomizer ?? new SimpleRandomizer();
            this.ModifierFactory = modifierFactory ?? new HeroModifierFactory();
        }

        public abstract void Execute();
    }
}
