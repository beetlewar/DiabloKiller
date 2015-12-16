using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IHero
    {
        /// <summary>
        /// Событие, возникаемое в результате смерти игрока
        /// </summary>
        event EventHandler Died;

        /// <summary>
        /// Возвращает текущую мощь игрока
        /// </summary>
        int Power { get; }

        /// <summary>
        /// Возвращает текущее количество монет игрока
        /// </summary>
        int Coins { get; }

        /// <summary>
        /// Возвращает текущее здоровье игрока
        /// </summary>
        float Health { get; }

        /// <summary>
        /// Возвращает максимально возможное здоровье игрока
        /// </summary>
        float MaxHealth { get; }

        /// <summary>
        /// Добавляет здоровье, при этом текущее здоровье не превышает максимальное
        /// </summary>
        /// <param name="health">Размер добавляемого здоровья</param>
        void AddHealth(float health);

        /// <summary>
        /// Уменьшает здоровье на заданный процент
        /// </summary>
        /// <param name="percent">Процент от 0 до 1, на который будет уменьшено здоровье</param>
        void TakeHealthRel(float percent);

        /// <summary>
        /// Уменьшает здоровье на заданную величину
        /// </summary>
        /// <param name="health">Размер отнимаемого здоровья</param>
        void TakeHealth(float health);

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
        /// Увеличивает здоровьем на заданнуч величину
        /// </summary>
        /// <param name="health">Величина, на которую увеличивется здоровье игрока</param>
        void IncreaseMaxHealth(float health);
    }
}
