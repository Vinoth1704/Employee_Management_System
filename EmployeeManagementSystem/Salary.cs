using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee
{
    class Salary
    {
        private int AnalystBasicSalary = 30000;
        private int DeveloperBasicSalary = 40000;
        public int CalculateSalary(string role)
        {
            if (role == "SOFTWARE ANALYST")
            {

                return AnalystBasicSalary;

            }
            else
            {
                return DeveloperBasicSalary;
            }
        }
        public int CalculateSalary(string role, int experience)
        {
            if (role == "SOFTWARE ANALYST")
            {

                return AnalystBasicSalary + (5000 * experience);

            }
            else
            {
                return DeveloperBasicSalary + (10000 * experience);
            }
        }
    }
}
