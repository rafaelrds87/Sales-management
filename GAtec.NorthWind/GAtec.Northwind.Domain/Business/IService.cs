using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAtec.Northwind.Domain.Business
{
    public interface IService
    {
        IReadOnlyDictionary<string, string> Validation { get, set; }
    }
}
