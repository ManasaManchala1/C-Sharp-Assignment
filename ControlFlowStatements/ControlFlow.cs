using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlFlowStatements
{
    internal class ControlFlow
    {
        //1.Delivery Status
        public void CheckOrderDeliveryStatus()
        {
            string orderStatus = "Delivered";

            if (orderStatus.Equals("Delivered"))
            {
                Console.WriteLine("The order has been delivered.");
            }
            else if (orderStatus.Equals("Processing"))
            {
                Console.WriteLine("The order is still being processed.");
            }
            else if (orderStatus.Equals("Cancelled"))
            {
                Console.WriteLine("The order has been cancelled.");
            }
            else
            {
                Console.WriteLine("Invalid order status.");
            }

            Console.WriteLine();
        }
        // 2. Categorize Parcels based on Weight
        public void CategorizeParcels()
        {
            double parcelweight = 15.0;
            switch (parcelweight)
            {
                case double weight when weight < 5.0:
                    Console.WriteLine("light parcel");
                    break;
                case double weight when weight >= 5.0 && weight < 15.0:
                    Console.WriteLine("medium parcel");
                    break;
                case double weight when weight >= 15.0:
                    Console.WriteLine("heavy parcel");
                    break;
                default:
                    Console.WriteLine("invalid parcel weight");
                    break;
            }
        }
        // 3. User Authentication
        public void UserAuthentication()
        {
            Console.WriteLine("Enter username: ");
            string? username = Console.ReadLine();
            Console.WriteLine("Enter password: ");
            string? password = Console.ReadLine();

            if (username=="Manasa" && password=="1234")
            {
                Console.WriteLine("Login successful.");
            }
            else
            {
                Console.WriteLine("Invalid username or password.");
            }

            Console.WriteLine();
        }
        // 4. Courier Assignment Logic
        public void CourierAssignmentLogic()
        {
            int totalCouriers = 5; 
            int shipmentsToAssign = 10; 

            for (int shipment = 1; shipment <= shipmentsToAssign; shipment++)
            {
                Console.WriteLine($"Assigning courier for shipment {shipment}");

                int assignedCourierId = AssignCourier(totalCouriers);

                if (assignedCourierId != -1)
                {
                    Console.WriteLine($"Courier {assignedCourierId} assigned for shipment {shipment}");
                }
                else
                {
                    Console.WriteLine("No available couriers. Shipment delayed.");
                }

                Console.WriteLine();
            }
        }
        public int AssignCourier(int totalCouriers)
        {
            Random random = new Random();
            return random.Next(1, totalCouriers + 1);
        }
    }
}
