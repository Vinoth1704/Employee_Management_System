using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;


namespace ProjectEmployee
{
    abstract class ManagerDetail
    {
        public string ManagerName = "Hari Krishnan";
        public string Branch = "Chennai";
    }
    class EmployeeDetail : ManagerDetail
    {
        private string _empId;
        private string _name;
        private string _contact;
        private string _emailId;
        private string _designation;
        private DateTime _dateOfJoining;
        private DateTime _dateOfBirth;
        private int _salary;

        public void AddEmployee(List<EmployeeDetail> employeeList)
        {
        AddEmployee:
            Console.WriteLine("\nEnter number of employees to be added:");
            try
            {
                int number = Convert.ToInt32(Console.ReadLine());
                if (number > 5 || number < 1)
                {
                    Console.WriteLine("ONLY 1-5 EMPLOYEES CAN BE ADDED AT A TIME");
                    goto AddEmployee;
                }
                for (int count = 1; count <= number; count++)
                {
                    Console.WriteLine($"\nEnter employee {count} details:");
                    EmployeeDetail employeeDetail = new EmployeeDetail
                    {
                        //_empId = GetEmployeeID(employeeList),
                        //_name = GetEmployeeName(),
                        //_emailId = GetEmployeeEmailID(),
                        //_contact = GetEmployeeContact(),
                        _dateOfBirth = GetEmployeeDateOfBirth(),
                        _designation = GetEmployeeDesignation(),
                    };
                    employeeDetail._dateOfJoining = employeeDetail.GetEmployeeJoiningDate();
                    employeeDetail._salary = employeeDetail.GetEmployeeSalary();


                    employeeList.Add(employeeDetail);
                    Console.WriteLine("---------------------------------------------------------------");

                }
            }
            catch (FormatException)
            {
                Console.WriteLine("ENTER ONLY NUMBERS");
                goto AddEmployee;
            }

            //Console.WriteLine("---------------------------------------------------------------");
            Console.WriteLine("\t\tEmployee Deatils Added Successfully.");
            Console.WriteLine("---------------------------------------------------------------\n");

        }
        public string GetEmployeeID(List<EmployeeDetail> employeeList)
        {
            try
            {
            ID:
                Console.WriteLine("\nEnter employee ID (For example:ACE1234) :");
                _empId = Console.ReadLine();
                foreach (EmployeeDetail i in employeeList)
                {
                    if (i._empId == this._empId)
                    {
                        Console.WriteLine("ENTERED EMPLOYEE ID IS ALREADY EXIST");
                        goto ID;
                    }
                }
                if (_empId == "ACE0000")
                {
                    Console.WriteLine("EMPLOYEE ID CANNOT BE ACE0000");
                    goto ID;
                }
                int idLength = _empId.Length;
                if (idLength == 7)
                {

                    if (_empId[0] != 'A' || _empId[1] != 'C' || _empId[2] != 'E')
                    {
                        Console.WriteLine("PLEASE ENTER VALID EMPLOYEE ID WHICH STARTS WITH ACE FOLLOWED BY 4 NUMERIC VALUE");
                        goto ID;
                    }

                    for (int Index = 3; Index < 7; Index++)
                    {
                        if (!char.IsDigit(_empId[Index]))
                        {
                            Console.WriteLine("PLEASE ENTER VALID EMPLOYEE ID WHICH STARTS WITH ACE FOLLOWED BY 4 NUMERIC VALUE");
                            goto ID;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("PLEASE ENTER VALID EMPLOYEE ID WHICH STARTS WITH ACE FOLLOWED BY 4 NUMERIC VALUE");
                    goto ID;
                }

            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
            return _empId;
        }
        public string GetEmployeeName()
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
        Name:
            Console.WriteLine("\nEnter your name : ");
            employeeDetail._name = Console.ReadLine();
            if (!employeeDetail._name.All(Char.IsLetter))
            {
                Console.WriteLine("INAVLID NAME. PLEASE DON'T ENTER ANY SPECIAL CHARACTERS OR NUMBERS");
                goto Name;
            }
            else if (string.IsNullOrEmpty(employeeDetail._name))
            {
                Console.WriteLine("NAME CAN'T BE EMPTY");
                goto Name;
            }
            else if (employeeDetail._name.Length < 3)
            {
                Console.WriteLine("PLEASE CHECK YOUR NAME. SIZE OF THE NAME SHOULD BE MORE THAN 2 CHARACTERS");
                goto Name;
            }
            for (int Index = 0; Index < employeeDetail._name.Length - 2; Index++)
            {
                if ((employeeDetail._name[Index] == employeeDetail._name[Index + 1]) && (employeeDetail._name[Index + 1] == employeeDetail._name[Index + 2]))
                {
                    Console.WriteLine("PLEASE CHECK YOUR NAME.IT SHOULD NOT CONTAIN ALPHABET WITH MORE THAN 2 OCCURENCES");
                    goto Name;
                }
            }
            return employeeDetail._name;
        }
        public string GetEmployeeContact()
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
        Contact:
            Console.WriteLine("\nEnter contact number : ");
            employeeDetail._contact = Console.ReadLine();
            int length = employeeDetail._contact.Length;
            if (length != 10)
            {
                Console.WriteLine("PLEASE ENTER VALID CONATCT NUMBER");
                goto Contact;
            }
            if (employeeDetail._contact[0] == '9' || employeeDetail._contact[0] == '8' || employeeDetail._contact[0] == '7' || employeeDetail._contact[0] == '6')
            {

            }
            else
            {
                Console.WriteLine(employeeDetail._contact[0]);
                Console.WriteLine("EMPLOYEE PHONE NUMBER SHOULD BEGIN WITH 6 OR 7 OR 8 OR 9.");
                goto Contact;
            }
            if (!employeeDetail._contact.All(char.IsDigit))
            {
                Console.WriteLine("CONTACT NUMBER SHOULD CONTAIN ONLY NUMBERS");
                goto Contact;
            }
            else if (string.IsNullOrEmpty(employeeDetail._contact))
            {
                Console.WriteLine("EMPLOYEE PHONE NUMBER SHOULD NOT BE EMPTY");
                goto Contact;
            }
            return employeeDetail._contact;
        }
        public string GetEmployeeEmailID()
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
        EmailId:
            Console.WriteLine("\nEnter Mail Id : ");
            employeeDetail._emailId = Console.ReadLine();
            if (string.IsNullOrEmpty(employeeDetail._emailId))
            {
                Console.WriteLine("MAIL ID SHOULD NOT BE EMPTY");
            }
            else if (Regex.IsMatch(employeeDetail._emailId, "^([0-9a-zA-Z]([-\\.\\w]*[_0-9a-zA-Z])*@([a-zA-Z]*[a-zA-Z]\\.)+[a-zA-Z]{2,9})$"))
            {
                employeeDetail._emailId = employeeDetail._emailId.ToLower();
            }
            else
            {
                Console.WriteLine("DOMAIN NAME SHOULD NOT CONTAIN NUMBERS");
                goto EmailId;
            }

            return employeeDetail._emailId;

        }
        public DateTime GetEmployeeDateOfBirth()
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
        DOB:
            bool counter = true;
            while (counter)
            {
                Console.WriteLine("\nEnter Date of birth: (Example : 30-09-2000 OR 30/09/2000 OR 24.10.2000) ");
                string EmpDob = Console.ReadLine();
                if (string.IsNullOrEmpty(EmpDob))
                {
                    Console.WriteLine("DATE OF BIRTH SHOULD NOT BE EMPTY");
                    goto DOB;
                }

                char DOB1 = char.Parse(EmpDob.Substring(2, 1));
                char DOB2 = char.Parse(EmpDob.Substring(5, 1));
                if (DOB1 == '-' && DOB2 == '-')
                {
                    DateTime EmployeeDateOfBirth = Convert.ToDateTime(EmpDob);
                    int Age = DateTime.Now.Subtract(EmployeeDateOfBirth).Days / 365;
                    employeeDetail._dateOfBirth = EmployeeDateOfBirth;

                    if (Age >= 18 && Age <= 60)
                    {
                        counter = false;
                    }
                    else
                    {
                        Console.WriteLine("PLEASE ENTER THE VALID DATE OF BIRTH");
                    }
                }
                else if ((DOB1 == '/' && DOB2 == '/'))
                {
                    DateTime EmployeeDateOfBirth = Convert.ToDateTime(EmpDob);
                    int Age = DateTime.Now.Subtract(EmployeeDateOfBirth).Days / 365;
                    employeeDetail._dateOfBirth = EmployeeDateOfBirth;

                    if (Age >= 18 && Age <= 60)
                    {
                        counter = false;
                    }
                    else
                    {
                        Console.WriteLine("PLEASE ENTER THE VALID DATE OF BIRTH");
                    }
                }
                else if ((DOB1 == '.' && DOB2 == '.'))
                {
                    DateTime EmployeeDateOfBirth = Convert.ToDateTime(EmpDob);
                    int Age = DateTime.Now.Subtract(EmployeeDateOfBirth).Days / 365;
                    employeeDetail._dateOfBirth = EmployeeDateOfBirth;

                    if (Age >= 18 && Age <= 60)
                    {
                        counter = false;
                    }
                    else
                    {
                        Console.WriteLine("PLEASE ENTER THE VALID DATE OF BIRTH");
                    }
                }

                else
                {
                    Console.WriteLine("DATE OF BIRTH SHOULD BE IN THE REQUIRED FORMAT(24-10-2000 OR 24/10/2000 OR 24.10.2000)");
                }

            }
            return employeeDetail._dateOfBirth;

        }
        public DateTime GetEmployeeJoiningDate()
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
        DOJ:
            bool counter = true;
            while (counter)
            {
                Console.WriteLine("\nEnter Date of joining: (Example : 30-09-2020 OR 30/09/2020 OR 24.10.2020) ");
                string EmpDoj = Console.ReadLine();
                if (string.IsNullOrEmpty(EmpDoj))
                {
                    Console.WriteLine("DATE OF JOIN SHOULD NOT BE EMPTY");
                    goto DOJ;
                }
                char DOJ1 = char.Parse(EmpDoj.Substring(2, 1));
                char DOJ2 = char.Parse(EmpDoj.Substring(5, 1));
                DateTime EmployeeDateOfJoining = Convert.ToDateTime(EmpDoj);
                employeeDetail._dateOfJoining = EmployeeDateOfJoining;
                int TimePeriod = (EmployeeDateOfJoining - _dateOfBirth).Days / 365;
                if ((TimePeriod <= 18) || (TimePeriod >= 60))
                {
                    Console.WriteLine("ENTER THE VALID DOJ");
                }

                else if ((DOJ1 == '-' && DOJ2 == '-'))
                {
                    DateTime employeeDateOfJoining = Convert.ToDateTime(EmpDoj);
                    int remainder = DateTime.Compare(employeeDateOfJoining, DateTime.Now);
                    if (remainder > 0)
                    {
                        Console.WriteLine("DATE OF JOINING SHOULD NEVER BE FUTURE DATES");
                    }
                    else
                    {
                        counter = false;
                    }
                }
                else if ((DOJ1 == '/' && DOJ2 == '/'))
                {
                    DateTime employeeDateOfJoining = Convert.ToDateTime(EmpDoj);
                    int remainder = DateTime.Compare(employeeDateOfJoining, DateTime.Now);
                    if (remainder > 0)
                    {
                        Console.WriteLine("DATE OF JOINING SHOULD NEVER BE FUTURE DATES");
                    }
                    else
                    {
                        counter = false;
                    }
                }
                else if ((DOJ1 == '.' && DOJ2 == '.'))
                {
                    DateTime employeeDateOfJoining = Convert.ToDateTime(EmpDoj);
                    int remainder = DateTime.Compare(employeeDateOfJoining, DateTime.Now);
                    if (remainder > 0)
                    {
                        Console.WriteLine("DATE OF JOINING SHOULD NEVER BE FUTURE DATES");
                    }
                    else
                    {
                        counter = false;
                    }
                }
                else
                {
                    Console.WriteLine("DATE OF JOINING SHOULD BE IN THE REQUIRED FORMAT");
                }
            }
            return employeeDetail._dateOfJoining;
        }
        public string GetEmployeeDesignation()
        {
            EmployeeDetail employeeDetail = new EmployeeDetail();
        Designation:
            Console.WriteLine("\nEnter designation from the list (SOFTWARE ANALYST, SOFTWARE DEVELOPER) : ");
            employeeDetail._designation = Console.ReadLine();
            employeeDetail._designation = employeeDetail._designation.ToUpper();
            if (employeeDetail._designation != "SOFTWARE ANALYST" && employeeDetail._designation != "SOFTWARE DEVELOPER")
            {
                Console.WriteLine("PLEASE ENTER CORRECT DESIGNATION");
                goto Designation;
            }
            return employeeDetail._designation;
        }
        public int GetEmployeeSalary()
        {
            EmployeeDetail employee = new EmployeeDetail();
            Salary setsalary = new Salary();
            int experience = (DateTime.Now - _dateOfJoining).Days / 365;

            if (experience > 0)
            {
                employee._salary = setsalary.CalculateSalary(_designation, experience);
            }
            else
            {
                employee._salary = setsalary.CalculateSalary(_designation);
            }
            return employee._salary;
        }


        public void SearchEmployee(List<EmployeeDetail> employeeList)
        {
            Console.WriteLine("Enter EmployeeDetail ID :");
            String SearchID = Console.ReadLine();

            int Flag = 1;

            foreach (EmployeeDetail i in employeeList)
            {
                if (i._empId == SearchID)
                {
                    Thread.Sleep(2000);
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine($"EmployeeDetail ID    : {i._empId} "
                                  + $"\nName           : {i._name}"
                                  + $"\nContact Number : {i._contact}"
                                  + $"\nDOB            : {i._dateOfBirth:dd/MM/yyyy}"
                                  + $"\nEmail          : {i._emailId}"
                                  + $"\nRole           : {i._designation}"
                                  + $"\nManager _name   : {ManagerName}"
                                  + $"\nBranch Location: {Branch}"
                                  + $"\nSalary         : {i._salary}");
                    Console.WriteLine("---------------------------------------------------------------");
                    Flag = 1;
                }
            }
            if (Flag != 1)
            {
                Console.WriteLine("RECORD NOT FOUND");
            }


        }
        public void AllEmployee(List<EmployeeDetail> employeeList)
        {
            foreach (EmployeeDetail i in employeeList)
            {
                Thread.Sleep(1000);
                Console.WriteLine("---------------------------------------------------------------");
                Console.WriteLine($"EmployeeDetail ID    : {i._empId} "
                                  + $"\nName           : {i._name}"
                                  + $"\nContact Number : {i._contact}"
                                  + $"\nDOB            : {i._dateOfBirth:dd/MM/yyyy}"
                                  + $"\nEmail          : {i._emailId}"
                                  + $"\nRole           : {i._designation}"
                                  + $"\nManager _name   : {ManagerName}"
                                  + $"\nBranch Location: {Branch}"
                                  + $"\nSalary         : {i._salary}");
                //Console.WriteLine("---------------------------------------------------------------");
            }
        }
        public void ModifyEmployee(List<EmployeeDetail> employeeList)
        {
            Console.WriteLine("Enter EmployeeDetail ID :");
            String SearchID = Console.ReadLine();
            int Flag = 1;
            foreach (EmployeeDetail i in employeeList)
            {
                if (i._empId == SearchID)
                {
                Start:
                    Console.WriteLine("---------------------------------------------------------------");
                    Console.WriteLine("Select the field to be modified");
                    Console.WriteLine("1._name");
                    Console.WriteLine("2.Contact");
                    Console.WriteLine("3.Date Of Birth");
                    Console.WriteLine("4.Email ID");
                    Console.WriteLine("5._designation");
                    Console.WriteLine("6.Date of Joining");
                    Console.WriteLine("\nEnter the Choice :");
                Choice:
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            i._name = i.GetEmployeeName();
                            break;
                        case 2:
                            i._contact = i.GetEmployeeContact();
                            break;
                        case 3:
                            i._dateOfBirth = i.GetEmployeeDateOfBirth();
                            break;
                        case 4:
                            i._emailId = i.GetEmployeeEmailID();
                            break;
                        case 5:
                            i._designation = i.GetEmployeeDesignation();
                            break;
                        case 6:
                            i._dateOfJoining = i.GetEmployeeJoiningDate();
                            break;
                        default:
                            Console.WriteLine("Invalid Number. Please enter correct choice!");
                            goto Choice;

                    }
                Continue:
                    Console.Write("\nWould you like to modify any other fields(Y/N) : ");
                    char Ans = Convert.ToChar(Console.ReadLine());
                    if (Ans == 'Y' || Ans == 'y')
                    {
                        goto Start;
                    }
                    else if (Ans == 'N' || Ans == 'n')
                    {
                        Console.WriteLine("---------------------------------------------------------------");
                        Console.WriteLine($"EmployeeDetail ID    : {i._empId} "
                                      + $"\nName           : {i._name}"
                                      + $"\nContact Number : {i._contact}"
                                      + $"\nDOB            : {i._dateOfBirth:dd/MM/yyyy}"
                                      + $"\nEmail          : {i._emailId}"
                                      + $"\nRole           : {i._designation}"
                                      + $"\nManager _name   : {ManagerName}"
                                      + $"\nBranch Location: {Branch}"
                                      + $"\nSalary         : {i._salary}");
                        Console.WriteLine("---------------------------------------------------------------");
                        Flag = 1;
                    }
                    else
                    {
                        Console.WriteLine("Please choose correct option..");
                        goto Continue;
                    }

                }
            }
            if (Flag != 1)
            {
                Console.WriteLine("ID not found");
            }
        }
        public void RemoveEmployee(List<EmployeeDetail> employeeList)
        {
            Console.WriteLine("Enter employee ID to be removed:");
            String SearchID = Console.ReadLine();
            int Flag = 0;
            foreach (EmployeeDetail i in employeeList)
            {

                if (i._empId == SearchID)
                {
                    employeeList.Remove(i);
                    Flag = 1;
                    Console.WriteLine("RECORD DELETED");
                    return;
                }
            }
            if (Flag != 1)
            {
                Console.WriteLine("RECORD NOT FOUND");
            }
        }

    }

}
