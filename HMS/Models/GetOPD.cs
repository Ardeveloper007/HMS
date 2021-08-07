using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMS.Models
{
   public  class GetOPD
    {
        public int Id { get; set; }
        public int? DrId { get; set; }
        public int? CustomerId { get; set; }
        public int? TokenNumber { get; set; }
        public string DoctorName { get; set; }
        public string CustomerName { get; set; }
        public double? Fees { get; set; }
        public DateTime? DateTime { get; set; }
    }
}
