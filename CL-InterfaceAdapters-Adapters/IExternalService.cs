using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CL_InterfaceAdapters_Adapters
{
    public interface IExternalService<T>
    {
        public Task<IEnumerable<T>> GetContentAsync();
    }
}
