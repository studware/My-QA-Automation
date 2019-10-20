using System;
using System.Collections.Generic;
using System.Text;

namespace Homework.Utilities
{
    public class EmailClass
    {
        public Guid AccountId { get; set; }
        public IEnumerable<string> EmailAddresses { get; set; }
    }
}
