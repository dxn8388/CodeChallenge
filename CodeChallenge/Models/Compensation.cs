using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CodeChallenge.Models
{
    public class Compensation
    {
        [Key]
        public string CompensationId { get; set; }
    
        public Employee employee { get; set; }
       
        public string employeeId { get; set; }

        public double salary { get; set; }

        public DateTime effectiveDate { get; set; }
       


    }
}
