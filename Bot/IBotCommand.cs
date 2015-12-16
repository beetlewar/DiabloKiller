using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Engine;

namespace Bot
{
    public interface IBotCommand : ICommand
    {
        /// <summary>
        /// Возвращает доступность исполнения команды
        /// </summary>
        BotCommandAvailability Availability { get; }

        /// <summary>
        /// Порядок выполнения команды
        /// </summary>
        int Order { get; }
    }
}
