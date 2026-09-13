    using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Domain.Exceptions
{
    public class DomainRuleException : Exception
    {
        public DomainRuleException(string message) : base(message)
        {
        }       
    }
}
