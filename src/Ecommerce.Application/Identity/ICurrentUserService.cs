using System;
using System.Collections.Generic;
using System.Text;

namespace Ecommerce.Application.Identity
{
    public interface ICurrentUserService
    {
        string? UserId { get; }

    }
}
