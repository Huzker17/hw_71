using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace hh.Interfaces
{
    public interface IBaseService<T>
    {
        IEnumerable<T> GetAll();

        T Get(string id);

    }
}
