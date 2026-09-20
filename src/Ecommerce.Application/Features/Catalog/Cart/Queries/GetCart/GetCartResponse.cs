public sealed record GetCartResponse(
    Guid Id,
    IReadOnlyList<GetCartItemResponse> Items,
    decimal Total);

public sealed record GetCartItemResponse(
    Guid Id,
    Guid ProductVariantId,
    string ProductName,
    int Quantity,
    decimal UnitPrice,
    decimal Total,
    IReadOnlyList<CartItemAttributeResponse> Attributes);

public sealed record CartItemAttributeResponse(
    string AttributeName,
    string AttributeValue);