using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Entities
{
    internal class Couriers
    {
        public int CourierID {  get; set; }
        public string? SenderName {  get; set; }
        public string? SenderAddress { get; set; }
        public string? ReceiverName { get; set; }
        public string? ReceiverAddress { get; set; }
        public double Weight { get; set; }
        public string? Status { get; set; }
        public string? TrackingNumber { get; set; }
        public DateTime DeliveryDate { get; set; }
        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        public int ServiceID { get; set; }
        public Couriers() { }
        public override string ToString()
        {
            return $"CourierID:{CourierID},SenderName:{SenderName},SenderAddress:{SenderAddress},ReceiverName:{ReceiverName},ReceiverAddress:{ReceiverAddress},Weight:{Weight},Status:{Status},TrackingNumber:{TrackingNumber},DeliveryDate:{DeliveryDate}";
        }
    }
}
