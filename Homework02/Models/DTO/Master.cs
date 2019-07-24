using System;
using System.Collections.Generic;

namespace Homework02.Models
{
    public partial class Master
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string Value1 { get; set; }
        public string Value2 { get; set; }
    }
}
