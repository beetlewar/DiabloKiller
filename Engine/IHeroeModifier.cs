﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine
{
    public interface IHeroeModifier
    {
        /// <summary>
        /// Модифицирует характериситики игрока
        /// </summary>
        void Modify(IHeroe heroe);
    }
}
