﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreVideo.Services
{
    public class HardCodedMessageService : IMessageService
    {
        public string GetMessage()
        {
            return "Hardcoded message from a service";
        }
    }
}
