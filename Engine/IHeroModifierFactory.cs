using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IHeroModifierFactory
    {
        /// <summary>
        /// Создает оружие с заданным модификатором мощности
        /// </summary>
        IHeroModifier CreateWeapon(int power);

        /// <summary>
        /// Создает броню с заданным модификатором здоровья
        /// </summary>
        IHeroModifier CreateArmor(int health);
    }
}
