﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Aapartment.Business.Constants
{
    public class Roles
    {
        public static string Admin { get; } = nameof(Admin).ToUpper();
        public static string Guest { get; } = nameof(Guest).ToUpper();
    }
}
