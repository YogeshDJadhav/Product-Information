using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductInformationCore.Data.Container
{
    public class ContextFactory : IContextFactory
    {
        string _ConString = String.Empty;
        public ProductInfoDbContext GetContaxt()
        {
            if (String.IsNullOrEmpty(_ConString))
            {
                _ConString = Common.GetConnetionString();
            }
            return new ProductInfoDbContext(_ConString);
        }
    }
}
