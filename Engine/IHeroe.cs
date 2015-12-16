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
        /// <param name="count">Количество добавляемых монет</param>
        void AddCoins(int count);

        /// <summary>
        /// Забирает у игрока заданное количество монет. Если монет не хватает, кидает EngineException
        /// </summary>
        /// <param name="count">Количество забираемых монет</param>
        void TakeCoins(int count);

        /// <summary>
        /// Увеличивает мощь на заданное значение
        /// </summary>
        /// <param name="power">Величина, на которую увеличивается мощь игрока</param>
        void IncreasePower(int power);

        /// <summary>
        /// Добавляет модификатор в список модификаторов игрока и применяет его, меняя тем самым свое состояние
        /// </summary>
        void AddModifier(IHeroeModifier modifier);
    }
}
