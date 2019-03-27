﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XanhShop.Common
{
    public static class OptionSets
    {
        public enum OrderStatusCode
        {
            Processing = 1,
            Ordered,
            AwaitingReceive,
            Validating,
            Finished,
            Cancel,
            Broken
        }
    }
}
