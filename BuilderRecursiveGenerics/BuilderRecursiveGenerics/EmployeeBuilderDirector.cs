using System;
using System.Collections.Generic;
using System.Text;

namespace BuilderRecursiveGenerics
{
    public class EmployeeBuilderDirector : EmployeeSalaryBuilder<EmployeeBuilderDirector>
    {
        public static EmployeeBuilderDirector NewEmployee => new EmployeeBuilderDirector();
    }
}
