using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IHeroe
    {
        /// <summary>
        /// Возвращает текущую мощь игрока
        /// </summary>
        int Power { get; }

        /// <summary>
        /// Уменьшает здоровье на заданный процент
        /// </summary>
        /// <param name="percent">Процент от 0 до 1, на который будет уменьшено здоровье</param>
        void DecreaseHealthRel(float percent);

        /// <summary>
        /// Уменьшает здоровье на заданную величину
        /// </summary>
        /// <param name="health">Размер отнимаемого здоровья</param>
        void DecreaseHealth(float health);

        /// <summary>
        /// Добавляет игроку монет
        /// </summary>
        /// <param name="count"></param>
        void AddCoins(int count);
    }
}
