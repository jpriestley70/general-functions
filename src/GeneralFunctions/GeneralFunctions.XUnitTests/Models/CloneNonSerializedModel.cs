using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFunctions.XUnitTests.Models
{
    public class CloneNonSerializedModel
    {
        public CloneNonSerializedModel()
        {
            _someTimeAgo = null;
        }

        public CloneNonSerializedModel(DateTime dte)
        {
            _someTimeAgo = dte;
        }

        public Guid Id { get; set; }
        public string Description { get; set; }
        public int IntValue { get; set; }
        public float FltValue { get; set; }
        public List<string> Lines { get; set; }

        private DateTime? _someTimeAgo;
        public DateTime? SomeTimeAgo { get { return _someTimeAgo; } }
    }
}
