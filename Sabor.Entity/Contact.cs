using System;
using System.Collections.Generic;
using System.Text;

namespace Sabor.Entity
{
    public class Contact
    {
        public int ContactId { get; set; }
        public string NameSurname { get; set; }
        public string EMail { get; set; }
        public string Subject { get; set; }
        public string PhoneNumber { get; set; }
        public string Content { get; set; }
    }
}
