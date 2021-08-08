using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInformationCore.Data.Container
{
    public interface IContextFactory
    {
        ProductInfoDbContext GetContaxt();
    }
}
