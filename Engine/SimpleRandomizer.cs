using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public class SimpleRandomizer : IRandomizer
    {
        private readonly Random _rnd = new Random();

        public bool RandomizeBool(float chance)
        {
            if(chance < 0 || chance > 1)
            {
                throw new EngineException("Вероятность должна находиться в диапазоне от 0 до 1");
            }

            // создадим массив bool значений, где сначала идут false, потом true и выберем случайным образом i-й элемент.
            var numOfFalse = (int)((1 - chance) * 100);
            var range = new bool[100];
            for (int i = 0; i < range.Length; ++i )
            {
                range[i] = i >= numOfFalse;
            }

            // случайным образом определим индекс в последовательности
            var rndIndex = this._rnd.Next(0, 100);
            return range[rndIndex];
        }

        public int RandomizeInt(int start, int end)
        {
            return this._rnd.Next(start, end + 1);
        }
    }
}
