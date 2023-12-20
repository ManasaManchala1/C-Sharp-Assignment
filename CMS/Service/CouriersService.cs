using CMS.Entities;
using CMS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Service
{
    internal class CouriersService:ICourierUserService
    {
        ICouriersRepository couriersRepository=new CouriersRepository();
        public void PlaceOrder()
        {
            Couriers couriers = new Couriers()
            {
                CourierID = 3,
                SenderName = "Rachel",
                SenderAddress = "abd",
                ReceiverName = "Phoebe",
                ReceiverAddress = "hgg",
                Weight = 60,
                Status = "Placed",
                TrackingNumber = "TN87625",
                DeliveryDate = DateTime.Now,
                UserID = 1,
                EmployeeID = 1,
                ServiceID = 1
            };
            string trackingnum = couriersRepository.PlaceOrder(couriers);
            Console.WriteLine(trackingnum);
        }
        public void CancelOrder()
        {
            Console.WriteLine("Enter tracking number");
            string? trackingnumber=Console.ReadLine();
            if (couriersRepository.CancelOrder(trackingnumber!)) { Console.WriteLine("Order Cancelled Successfully"); }
            else Console.WriteLine("Courier not found.");
        }

        public void GetOrderStatus()
        {
            Console.WriteLine("Enter tracking number");
            string? trackingnumber = Console.ReadLine();
            String orderstatus = couriersRepository.GetOrderStatus(trackingnumber!);
            if (orderstatus != null) Console.WriteLine(orderstatus);
            else Console.WriteLine("Courier not found.");
        }

        public void MarkOrderDelivered()
        {
            Console.WriteLine("Enter tracking number");
            string? trackingnumber = Console.ReadLine();
            if (couriersRepository.MarkOrderDelivered(trackingnumber!)) { Console.WriteLine("Order marked as Delivered Successfully"); }
            else { Console.WriteLine("Courier not found."); }
        }

        public void AssignCourier()
        {
            Console.WriteLine("Enter tracking number");
            string? trackingnumber = Console.ReadLine();
            Console.WriteLine("EmpoyeeID");
            int employeeID=int.Parse(Console.ReadLine());
            if (couriersRepository.AssignCourier(trackingnumber!, employeeID)) { Console.WriteLine($"{employeeID} assigned successfully"); }
            else { Console.WriteLine("Courier not found."); }
        }
        public void GetAssignedOrders()
        {
            Console.WriteLine("EmployeeID");
            int employeeid=int.Parse(Console.ReadLine());
            List<string> orders = couriersRepository.GetAssignedOrders(employeeid);
            foreach (string order in orders) Console.WriteLine($"TrakingNumber::{order}");
            if (orders.Count == 0) Console.WriteLine("No orders are assigned");
        }

    }
}
