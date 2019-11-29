using Safari.Entities;
using Safari.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Safari.Services.Contracts
{
    public interface IListResponse<T> where T : IEntity
    {
        List<T> Result { get; set; }
    }
}
