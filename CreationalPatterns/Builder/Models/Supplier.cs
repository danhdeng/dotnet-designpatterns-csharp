using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreationalPatterns.Builder.Models
{
    public class Supplier
    {
        public Supplier() { }
        public Supplier(string name, string email, string contactName)=>(Name, Email, ContactName)=(name,email, contactName);

        public string Name { get; set; }

        public string Email { get; set; }

        public string ContactName { get; set; }
    }
}
