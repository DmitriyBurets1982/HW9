using System.Collections.Concurrent;
using StockService.Dtos;

namespace HW9.Storage;

internal static class OrderStorage
{
    private static readonly ConcurrentDictionary<(int, Guid), OrderItem> _items = new ();

    public static OrderItem? Get((int, Guid) userIdempotencyKey)
    {
        _items.TryGetValue(userIdempotencyKey, out var item);
        return item;
    }

    public static void Store((int, Guid) userIdempotencyKey, int orderId)
    {
        var item = new OrderItem { UserId = userIdempotencyKey.Item1, UserIdempotencyKey = userIdempotencyKey.Item2, OrderId = orderId };
        _items.AddOrUpdate(userIdempotencyKey, item, (key, value) => item);
    }
}
