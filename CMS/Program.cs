using CMS.Entities;
using CMS.Repository;
using CMS.Service;

ICourierUserService courierUserService=new CouriersService();
//Placing a new Order
Console.WriteLine("Placing a new Order");
courierUserService.PlaceOrder();

//Get the status by tracking number
Console.WriteLine("Get the status by tracking number");
courierUserService.GetOrderStatus();

//Order cancellation by tracking number
Console.WriteLine("Order cancellation by tracking number");
courierUserService.CancelOrder();

//Mark order delivered by tracking number
Console.WriteLine("Mark order delivered by tracking number");
courierUserService.MarkOrderDelivered();

//AssignCourier
Console.WriteLine("AssignCourier");
courierUserService.AssignCourier();

//GetAssignedOrders
Console.WriteLine("Get assigned order by id");
courierUserService.GetAssignedOrders();