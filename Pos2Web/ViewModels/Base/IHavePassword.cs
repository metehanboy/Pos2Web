﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Pos2Web
{



    public interface IHavePassword
    {

        SecureString SecurePassword { get; }

    }
}
