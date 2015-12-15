using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    /// <summary>
    /// Статические параметры игры
    /// </summary>
    public interface IStaticValues
    {
        /// <summary>
        /// Максимальная вероятность победы
        /// </summary>
        float MaxChanceToWin { get; }

        /// <summary>
        /// Возвращает базовую вероятность победы
        /// </summary>
        float BaseChanceToWin { get; }

        /// <summary>
        /// Возвращает влияние мощи игрока на победу
        /// </summary>
        float PowerEffectToWin { get; }

        /// <summary>
        /// Возвращает величину здоровья, отнимаемую при поражении в бою
        /// </summary>
        float HealthLostAfterDefeat { get; }

        /// <summary>
        /// Возвращает процент здоровья, отнимаемый при победе в бою, от 0 до 1
        /// </summary>
        float HealthLostAfterWinRel { get; }

        /// <summary>
        /// Число монет, получаемое игроком при победе в бою
        /// </summary>
        int CoinsGainedAfterWin { get; }

        /// <summary>
        /// Возвращает здоровье, назначаемое игроку по умолчанию
        /// </summary>
        float DefaultHeroeHealth { get; }

        /// <summary>
        /// Возвращает максимальное здоровье, назначаемое игроку по умолчанию
        /// </summary>
        float DefaultHeroeMaxHealth { get; }

        /// <summary>
        /// Возвращает мощь, назначаемую игроку по умолчанию
        /// </summary>
        int DefaultHeroePower { get; }

        /// <summary>
        /// Возвращает количество монет, назначаемое игроку по умолчанию
        /// </summary>
        int DefaultHeroeCoins { get; }
    }
}
