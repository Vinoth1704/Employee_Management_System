using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectEmployee
{
    class Menu
    {
        //public static MySqlConnection databaseConnection;
        public void MenuList()
        {
            List<EmployeeDetail> employeeList = new List<EmployeeDetail>();

            EmployeeDetail employee = new EmployeeDetail();
        //using (databaseConnection = new MySqlConnection())
        //{
        //    string connectionString = ConfigurationManager.ConnectionStrings["myDatabaseConnection"].ConnectionString;
        //    databaseConnection = new MySqlConnection(connectionString);
        //    databaseConnection.Open();


        Start:
            {
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("\t\t\t\t\t\t\t\t\tWELCOME TO ASPIRE SYSTEMS");
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("MENU\n");
                Console.WriteLine("1.Add EmployeeDetail");
                Console.WriteLine("2.Search EmployeeDetail Details");
                Console.WriteLine("3.View All EmployeeDetail Details");
                Console.WriteLine("4.Modify EmployeeDetail Details");
                Console.WriteLine("5.Remove EmployeeDetail Details");
                Console.WriteLine("6.Exit");
            Choice:
                Console.WriteLine("\nEnter your choice ");
                try
                {
                    int number = Convert.ToInt32(Console.ReadLine());
                    switch (number)
                    {
                        case 1:
                            employee.AddEmployee(employeeList);
                            break;
                        case 2:
                            employee.SearchEmployee(employeeList);
                            break;
                        case 3:
                            employee.AllEmployee(employeeList);
                            break;
                        case 4:
                            employee.ModifyEmployee(employeeList);
                            break;
                        case 5:
                            employee.RemoveEmployee(employeeList);
                            break;
                        case 6:
                            goto exit;
                        default:
                            Console.WriteLine("INVALID NUMBER. PLEASE ENTER CORRECT CHOICE!");
                            goto Choice;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("ENTER ONLY NUMBERS");
                    goto Choice;
                }
            Continue:
                Console.Write("\nWould you like to continue(Y/N) : ");
                char answer = Convert.ToChar(Console.ReadLine());
                if (answer == 'Y' || answer == 'y')
                {
                    goto Start;
                }
                else if (answer == 'N' || answer == 'n')
                {
                    return;
                }
                else
                {
                    Console.WriteLine("PLEASE CHOOSE CORRECT OPTION..");
                    goto Continue;
                }
            exit: { }
            }
            //}
        }
    }
}
