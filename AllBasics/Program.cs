using StringsAnd2DArrays;

AllMethods allMethods =new AllMethods();
// 1. Parcel Tracking
string[,] parcelTrackingArray = {
            {"123456", "Parcel in transit"},
            {"789012", "Parcel out for delivery"},
            {"345678", "Parcel delivered"}
        };

Console.Write("Enter parcel tracking number: ");
string trackingNumber = Console.ReadLine();
allMethods.TrackParcelStatus(parcelTrackingArray, trackingNumber);

// 2. Customer Data Validation
allMethods.ValidateCustomerInformation("John Doe", "123 Main St", "555-1234");

// 3. Address Formatting
string formattedAddress = allMethods.FormatAddress("123 elm street", "cityville", "state", "12345");
Console.WriteLine($"Formatted Address: {formattedAddress}");

// 4. Order Confirmation Email
allMethods.GenerateOrderConfirmationEmail("John Doe", "Order123", "456 Main St", "Expected Date: 2023-01-01");

// 5. Calculate Shipping Costs
double shippingCost = allMethods.CalculateShippingCost("SourceAddress", "DestinationAddress", 5.0);
Console.WriteLine($"Shipping Cost: ${shippingCost}");

// 6. Password Generator
string generatedPassword = allMethods.GeneratePassword();
Console.WriteLine($"Generated Password: {generatedPassword}");

// 7. Find Similar Addresses
allMethods.FindSimilarAddresses(new List<string> { "123 Main St", "456 Elm St", "789 Oak St", "123 Main St" });

