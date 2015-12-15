using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SimpleRandomizer : IRandomizer
    {
        /// <summary>
        /// Возвращает true, если вероятность >= 0.5
        /// </summary>
        /// <param name="chance">Вероятность возникновения события</param>
        public bool RandomizeBool(float chance)
        {
            return chance >= 0.5f;
        }
    }
}
