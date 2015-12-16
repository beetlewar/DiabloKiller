using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class ACommand : ICommand
    {
        public IHeroe Heroe { get; private set; }
        internal IRandomizer Randimozer { get; private set; }
        internal IStaticValues StaticValues { get; private set; }

        protected ACommand(
            IHeroe heroe, 
            IRandomizer randomizer,
            IStaticValues staticValues)
        {
            if(heroe == null)
            {
                throw new ArgumentNullException("heroe");
            }
            if(staticValues == null)
            {
                throw new ArgumentNullException("staticValues");
            }

            this.Heroe = heroe;
            this.StaticValues = staticValues;
            this.Randimozer = randomizer ?? new SimpleRandomizer();
        }

        public abstract void Execute();
    }
}
