namespace StockService.Dtos
{
    internal class OrderItem
    {
        public int UserId { get; set; }
        public Guid UserIdempotencyKey { get; set; }
        public int OrderId { get; set; }
    }
}
