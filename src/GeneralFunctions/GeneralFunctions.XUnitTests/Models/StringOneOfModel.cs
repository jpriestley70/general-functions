using System;
using System.Collections.Generic;
using System.Text;

#nullable enable

namespace GeneralFunctions.XUnitTests.Models
{
    public class StringOneOfModel
    {
        public string? Actual { get; set; }
        public string[]? Values { get; set; }
        public bool Expected { get; set; }
    }
}
