using Microsoft.VisualBasic;
using System.Collections.Generic;

namespace CodeChallenge.Models
{
    public class ReportingStructure
    {
        public ReportingStructure(Employee currEmployee) {
            employee = currEmployee;
        }

        public Employee employee { get; set; }

        public int NumberOfReports
        {
            get
            {
                int total = 0;
               
                if( employee.DirectReports != null)
                {
                    employee.DirectReports.ForEach(report =>
                    {                       
                        total += 1;
                        total += new ReportingStructure(report).NumberOfReports;
                    });
                }

                return total;
            }
        }
    }
}
