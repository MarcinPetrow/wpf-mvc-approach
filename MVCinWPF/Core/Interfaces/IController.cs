﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVCinWPF.Core.Interfaces
{
    public interface IController
    {
        void Initialize();
        void Cleanup();
    }
}
