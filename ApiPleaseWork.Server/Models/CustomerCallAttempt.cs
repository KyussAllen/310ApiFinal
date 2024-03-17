using System;
using System.ComponentModel.DataAnnotations;
namespace ApiPleaseWork.Models
{
    public class CustCallAttempts
    {
        [Key]
        public int CallAttemptId { get; set; }
        public DateTime TimeOfAttempt { get; set; }
        public string? notes { get; set; }

        public int CustomerId { get; set; }
    }
}