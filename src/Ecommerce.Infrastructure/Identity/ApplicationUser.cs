using Microsoft.AspNetCore.Identity;

namespace Ecommerce.Infrastructure.Identity;

public sealed class ApplicationUser : IdentityUser
{
    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
}
