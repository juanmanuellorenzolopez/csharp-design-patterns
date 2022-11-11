using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderRecursiveGenerics
{
    public class EmployeeInfoBuilder
    {
        protected Employee employee = new Employee();

        public EmployeeInfoBuilder SetName(string name)
        {
            employee.Name = name;
            return this;
        }
    }
}
