using NameSorter.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NameSorter {
    public class DataSubstringList : IDataSubstringList{

        private List<DataSubstring> List { get; set; }

        public DataSubstringList() {
            List = new List<DataSubstring>();
        }
        public DataSubstringList(List<DataSubstring> param) {
            List = new List<DataSubstring>();
            List.AddRange(param);
        }

        public DataSubstringList(List<string> param) {
            List = new List<DataSubstring>();
            for (int i = 0; i < param.Count; i++) {
                List.Add(new DataSubstring(i, param[i]));
            }
        }


        public void Add(DataSubstring name) {
            List.Add(name);
        }

        public List<string> GetName() {
            return List.Select(e => e.Value).ToList();
        }

        public List<DataSubstring> GetList() {
            return List;
        }

        public string GetNameAtIndex(int index) {
            return List.Where(e => e.Order == index).FirstOrDefault().Value;
        }

        public void ReorderByAscending() {
            var oldList = List;
            List = new List<DataSubstring>();
            foreach (var data in oldList.OrderBy(e => e.Value)) {
                List.Add(new DataSubstring(data.Order, data.Value));
            }
        }

    }
}
