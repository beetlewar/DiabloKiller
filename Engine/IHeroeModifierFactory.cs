using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IHeroeModifierFactory
    {
        /// <summary>
        /// Создает оружие с заданной мощностью
        /// </summary>
        IHeroeModifier CreateWeapon(int power);
    }
}
