using System.ComponentModel.DataAnnotations;
using System;

namespace CodeChallenge.Models
{
    public class CompensationInput
    {

        public string employeeId { get; set; }

        public double salary { get; set; }

        public DateTime effectiveDate { get; set; }
       
    }
}
