﻿using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts.Request
{
    public class ClienteRequest : IRequest<Cliente>
    {
        public Cliente Request { get; set; }
    }
}
