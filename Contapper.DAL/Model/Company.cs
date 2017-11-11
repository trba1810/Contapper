using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contapper.DAL.Model
{
    public class Company
    {
        public string Id { get; set; }

        public string CompanyName { get; set; }

        public string City { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public Status Status { get; set; }

        public DateTime Date { get; set; }

        public string Details { get; set; }
    }
}
