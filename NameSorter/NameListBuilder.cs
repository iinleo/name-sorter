using NameSorter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter {
    public class NameListBuilder : INameListBuilder{
        private IDataSubstringList NameList = new DataSubstringList();

        #region Constructor
        public NameListBuilder(string path) {
            ExportFrom(path);
        }


        public NameListBuilder(List<string> list) {
            NameList = new DataSubstringList(list);
        }
        #endregion

        public IDataSubstringList GetList() {
            return NameList;
        }

        public void ExportFrom(string path) {
            path = System.IO.Path.GetFullPath(path);
            Console.WriteLine("Trying to open " + path);
            if (File.Exists(path)) {
                ReadFile(path);
            }
        }

        private void ReadFile(string path) {
            var result = new List<string>();
            using (var reader = new StreamReader(path)) {
                while (!reader.EndOfStream) {
                    var data = reader.ReadLine();
                    result.Add(data);
                }
            }
            NameList = new DataSubstringList(result);
        }

        public void WriteFileTo(string path) {
            path = System.IO.Path.GetFullPath(path);
            using (var writer = new StreamWriter(path)) {
                foreach (var name in NameList.GetName()) {
                    writer.WriteLine(name);
                }
            }
        }

        public void PrintList() {
            Console.WriteLine("The list contains: ");
            foreach (var data in NameList.GetName()) {
                Console.WriteLine(data);
            }
        }
        

        public void Order() {
            var lastName = BreakLine(NameList.GetName(), false);
            
            lastName.ReorderByAscending();
            NameList.ReorderByAscending();

            var newList = new DataSubstringList();
            var newIndex = 0;

            foreach (var data in lastName.GetList()){
                string newValue = null;
                var dataValue = lastName.GetList().Where(e => e.Value == data.Value).ToList();
                //if has same last name
                if (dataValue.Count > 1) {
                    newValue = NameList.GetList().Where(e => dataValue.Select(y => y.Order).Contains(e.Order) 
                        && !newList.GetList().Select(y => y.Value).Contains(e.Value))
                        .FirstOrDefault().Value;
                } else {
                    newValue = NameList.GetNameAtIndex(data.Order);
                }
                if (newValue != null) newList.Add(new DataSubstring(newIndex, newValue));
                newIndex++;
            }
            NameList = newList;
        }
        
        private IDataSubstringList BreakLine(List<string> line, bool getFirstName) {
            var result = new DataSubstringList();
            var index = 0;
            if (!getFirstName) {
                index = 1;
            }
            for (int i = 0; i < line.Count; i++) {
                var shards = BreakString(line[i]);
                result.Add(new DataSubstring(i, shards[index]));
            }
            return result;
        }

        private List<string> BreakString(string data) {
            var list = data.Split(null).Select(val => val.Trim()).ToList();
            var result = new List<string>();
            if (list.Count > 0) {
                result.Add(list[0]);
                result.Add(list[list.Count() - 1] == list[0] ? "" : list[list.Count() - 1]);
            }
            return result;
        }
    }
}
