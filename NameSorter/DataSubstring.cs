using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter {
    public class DataSubstring : Data {
        public DataSubstring(int order, string value) : base(value) {
            Order = order;
        }
        public int Order { get; set; }
    }
}
