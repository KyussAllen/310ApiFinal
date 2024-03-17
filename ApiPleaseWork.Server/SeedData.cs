using System;
using System.Linq;
using ApiPleaseWork.Models;
using ApiPleaseWork.Server.Data;
using ApiPleaseWork;

namespace ApiPleaseWork.Data
{
    public static class SeedData
    {
        public static void Initialize(ApiPleaseWorkServerContext context)
        {
            if (context.CustomerInformation.Any())
                return;

            context.CustomerInformation.AddRange(
                new CustomerInformation { CustomerFirstName = "John", CustomerLastName = "Doe", CustomerEmail = "john.doe@gmail.com", CustomerCity = "Centralia", CustomerState = "Wa", CustomerZipCode = "98531" }
            );

            context.CustomerContact.AddRange(
                new CustomerContact { CustomerPhoneNumber = "123-456-7890", CustomerPhoneType = "Cell", CustomerID = 1 }
            );

            context.CustCallAttempts.AddRange(
                new CustCallAttempts { TimeOfAttempt = DateTime.Now, notes = "Was on vacation", CustomerId = 1 }
            );

            context.SaveChanges();
        }
    }
}