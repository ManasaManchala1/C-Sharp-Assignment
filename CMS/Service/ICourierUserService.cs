using CMS.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Service
{
    internal interface ICourierUserService
    {
        void PlaceOrder();
        void GetOrderStatus();
        void CancelOrder();
        void MarkOrderDelivered();
        void AssignCourier();
        void GetAssignedOrders();
    }
}
