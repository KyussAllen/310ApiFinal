using ApiPleaseWork.Models;
using System.ComponentModel.DataAnnotations;
using System.Composition;



namespace ApiPleaseWork.Models
{
    public class CustomerInformation
    {
        [Key]
        public int CustomerId { get; set; }
        public  string? CustomerFirstName { get; set; }
        public  string? CustomerLastName { get; set; }
        public  string? CustomerEmail { get; set; }
        public string? CustomerCity { get; set; }
        public string? CustomerState { get; set; }
        public string? CustomerZipCode { get; set; }

        public List<CustomerContact>? CustPhoneNumber { get; set; }
        public List<CustCallAttempts>? CustomerCallAttempts { get; set; }


    }
}
