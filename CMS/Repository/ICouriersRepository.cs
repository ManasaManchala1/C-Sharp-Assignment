using CMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository
{
    internal interface ICouriersRepository
    {
        string PlaceOrder(Couriers courier);
        string GetOrderStatus(string trackingNumber);
        bool CancelOrder(string trackingNumber);
        bool MarkOrderDelivered(string trackingNumber);
        bool AssignCourier(string trackingNumber, int courierStaffId);
        List<string> GetAssignedOrders(int courierStaffId);

    }
}
