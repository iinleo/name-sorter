using NameSorter.Interfaces;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace NameSorter {
    class Program {
        static void Main(string[] args) {
            string path = args[0];
            INameListBuilder build = new NameListBuilder(path);
            build.Order();
            build.PrintList();
            build.WriteFileTo("sorted-name-lists.txt");
            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
