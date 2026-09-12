using Ecommerce.Domain.Common;

namespace Ecommerce.Domain.Entities;

public sealed class OrderAddress : BaseEntity
{
    public Guid OrderId { get; private set; }
    public AddressType AddressType { get; private set; }
    public string FirstName { get; private set; } = null!;
    public string LastName { get; private set; } = null!;
    public string Phone { get; private set; } = null!;
    public string Country { get; private set; } = null!;
    public string City { get; private set; } = null!;
    public string Area { get; private set; } = null!;
    public string Street { get; private set; } = null!;
    public string? Building { get; private set; }
    public string? Floor { get; private set; }
    public string? Apartment { get; private set; }
    public string? PostalCode { get; private set; }
}