using CMS.Entities;
using CMS.Utility;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMS.Repository
{
    internal class CouriersRepository : ICouriersRepository
    {
        string connectionstring;
        SqlCommand command;
        public CouriersRepository()
        {
            connectionstring = DbConnUtil.GetConnectionString();
            command = new SqlCommand();
        }
        public string PlaceOrder(Couriers courier)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    command.CommandText = "insert into Couriers values(@cid,@sname,@saddress,@rname,@raddress,@wgt,@sts,@tnum,@dd,@uid,@eid,@sid)";
                    command.Parameters.AddWithValue("@cid", courier.CourierID);
                    command.Parameters.AddWithValue("@sname", courier.SenderName);
                    command.Parameters.AddWithValue("@saddress", courier.SenderAddress);
                    command.Parameters.AddWithValue("@rname", courier.ReceiverName);
                    command.Parameters.AddWithValue("@raddress", courier.ReceiverAddress);
                    command.Parameters.AddWithValue("@wgt", courier.Weight);
                    command.Parameters.AddWithValue("@sts", courier.Status);
                    command.Parameters.AddWithValue("@tnum", courier.TrackingNumber);
                    command.Parameters.AddWithValue("@dd", courier.DeliveryDate);
                    command.Parameters.AddWithValue("@uid", courier.UserID);
                    command.Parameters.AddWithValue("@eid", courier.EmployeeID);
                    command.Parameters.AddWithValue("@sid", courier.ServiceID);
                    command.Connection = conn;
                    conn.Open();
                    int status = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (status == 1) return courier.TrackingNumber!;

                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return "Order not Placed";
        }
        public string GetOrderStatus(string trackingNumber)
        {
            string? orderstatus = null;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    command.CommandText = "select Status from Couriers where TrackingNumber=@tnum1";
                    command.Parameters.AddWithValue("@tnum1", trackingNumber);
                    command.Connection = conn;
                    conn.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    bool data = reader.Read();
                    if (data) orderstatus = (string)reader["Status"];
                    command.Parameters.Clear();

                }
                command.Parameters.Clear();
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return orderstatus!;
        }
        public bool CancelOrder(string trackingNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    command.CommandText = "delete from Couriers where TrackingNumber=@tnum2";
                    command.Parameters.AddWithValue("@tnum2", trackingNumber);
                    command.Connection = conn;
                    conn.Open();
                    int cancelstatus = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (cancelstatus == 1) return true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;
        }
        public bool MarkOrderDelivered(string trackingNumber)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionstring))
                {
                    command.CommandText = "update Couriers set Status=@sts where TrackingNumber=@tnum3";
                    command.Parameters.AddWithValue("@tnum3", trackingNumber);
                    command.Parameters.AddWithValue("@sts", "Delivered");
                    command.Connection = conn;
                    conn.Open();
                    int cancelstatus = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                    if (cancelstatus == 1) return true;
                }
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return false;

        }
        public bool AssignCourier(string trackingNumber, int courierStaffId)
        {
            int rowsAffected = 0;
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    command.CommandText = "update Couriers set EmployeeID = @CourierStaffId, Status = 'Assigned' where TrackingNumber = @TrackingNumber";
                    command.Parameters.AddWithValue("@CourierStaffId", courierStaffId);
                    command.Parameters.AddWithValue("@TrackingNumber", trackingNumber);
                    command.Connection = connection;
                    connection.Open();
                    rowsAffected = command.ExecuteNonQuery();
                    command.Parameters.Clear();
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return rowsAffected > 0;
        }
        public List<string> GetAssignedOrders(int courierStaffId)
        {
            List<string> assignedOrders = new List<string>();
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionstring))
                {
                    command.CommandText = "select TrackingNumber from Couriers where EmployeeID = @CourierStaffId";
                    command.Parameters.AddWithValue("@CourierStaffId", courierStaffId);
                    command.Connection = connection;
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        assignedOrders.Add(reader["TrackingNumber"].ToString()!);
                    }
                    command.Parameters.Clear();
                }

            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }
            return assignedOrders;
        }

        public int AddCourierStaff(Employee employee)
        {
            using (var connection = new SqlConnection(connectionstring))
            {
                command.CommandText = "insert into Employee values (@EmployeeID,@EmployeeName, @Email, @ContactNumber, @Role, @Salary)";
                command.Parameters.AddWithValue("@EmployeeID", employee.EmployeeID);
                command.Parameters.AddWithValue("@EmployeeName", employee.Name);
                command.Parameters.AddWithValue("@Email", employee.Email);
                command.Parameters.AddWithValue("@ContactNumber", employee.ContactNumber);
                command.Parameters.AddWithValue("@Role", employee.Role);
                command.Parameters.AddWithValue("@Salary", employee.Salary);
                var employeeId = command.ExecuteScalar();
                return Convert.ToInt32(employeeId);
            }
        }
    }
}
}

