using System.ComponentModel.DataAnnotations;

namespace ApiPleaseWork.Models
{
    public class CustomerContact
    {
        [Key]
        public int CustomerContactId { get; set; }
        public required string CustomerPhoneNumber { get; set; }
        public string? CustomerPhoneType { get; set; }

        public int CustomerID { get; set; }
    }
}
