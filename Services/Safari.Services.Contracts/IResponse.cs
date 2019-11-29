using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IResponse<T> where T : IEntity
    {
        T Result { get; set; }
    }
}
