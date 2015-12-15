using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Возвращает случайные значения в зависимости от вероятности возникновения события
    /// </summary>
    public interface IRandomizer
    {
        /// <summary>
        /// Возвращает true, если событие должно произойти, иначе - false.
        /// </summary>
        /// <param name="chance">Вероятность возникновения события от 0 до 1, где 0 - не возможно, 1 обязательно сбудется</param>
        bool RandomizeBool(float chance);
    }
}
