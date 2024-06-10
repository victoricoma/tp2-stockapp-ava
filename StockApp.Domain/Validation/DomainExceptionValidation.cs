using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockApp.Domain.Validation
{
    public class DomainExceptionValidation : Exception
    {
        public DomainExceptionValidation(string error) : base(error)
        {}

        public static void When(bool hasError, string error)
        {
            if(hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
