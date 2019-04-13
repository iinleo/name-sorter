using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Interfaces {
    public interface IDataSubstringList {
        void Add(DataSubstring name);
        List<string> GetName();
        List<DataSubstring> GetList();
        string GetNameAtIndex(int index);
        void ReorderByAscending();
    }
}
