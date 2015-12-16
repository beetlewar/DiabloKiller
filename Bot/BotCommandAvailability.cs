using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bot
{
    /// <summary>
    /// Определяет доступность исполнения команды
    /// </summary>
    public enum BotCommandAvailability
    {
        /// <summary>
        /// Исполнение запрещено
        /// </summary>
        Forbidden       = 0,

        /// <summary>
        /// Исполнение разрешено, но не рекомендовано
        /// </summary>
        NotRecommended  = 1,

        /// <summary>
        /// Исполнение разрешено
        /// </summary>
        Allowed         = 2,
    }
}
