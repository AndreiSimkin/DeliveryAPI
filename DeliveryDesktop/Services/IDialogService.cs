using DeliveryDesktop.Models;

namespace DeliveryDesktop.Services
{
    public interface IDialogService
    {
        CourierModel? ShowCourierRegistrationDialog();

        OrderModel? ShowCreateOrderDialog();

        OrderModel? ShowEditOrderDialog(OrderModel order);

        string? ShowCancelOrderDialog();
    }
}