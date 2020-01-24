using System;
using System.Collections.Generic;
using System.Text;

namespace GeneralFunctions.XUnitTests.Models
{
    [Serializable]
    public class CloneModel
    {
        public CloneModel()
        {
            _someTimeAgo = null;
        }

        public CloneModel(DateTime dte)
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
