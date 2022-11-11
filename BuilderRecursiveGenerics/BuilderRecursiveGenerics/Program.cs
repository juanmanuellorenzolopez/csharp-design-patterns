using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderRecursiveGenerics
{
    class Program
    {
        static void Main(string[] args)
        {
            var employee = new EmployeeInfoBuilder()
                .SetName("Maks")
                .AtPosition();
        }
    }
}
