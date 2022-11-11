using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuilderRecursiveGenerics
{
    public class EmployeePositionBuilder : EmployeeInfoBuilder
    {
        public EmployeePositionBuilder AtPosition(string position)
        {
            employee.Position = position;
            return this;
        }
    }
}
