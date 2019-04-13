using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter.Interfaces {
    public interface INameListBuilder {
        IDataSubstringList GetList();
        void ExportFrom(string path);
        void WriteFileTo(string path);
        void PrintList();
        void Order();
    }
}
