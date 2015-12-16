using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public abstract class ACommand
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
            this.Heroe = heroe;
            this.Randimozer = randomizer ?? new SimpleRandomizer();
            this.StaticValues = staticValues ?? new StaticValues();
        }
    }
}
