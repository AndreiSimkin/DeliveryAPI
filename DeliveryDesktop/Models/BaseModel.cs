namespace DeliveryDesktop.Models
{
    public abstract class BaseModel<TId>
    {
        public TId? Id { get; set; }
    }
}
