using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using BusinessLogic;


namespace StudentRegistrationConsole
{
    class Program
    {
        static StudentManager myStudentManager = new StudentManager();
        static void Main(string[] args)
        {
            try
            {
                var Students = myStudentManager.GetStudentList();

                for (int i = 0; i < Students.Count; i++)
                {
                    Console.WriteLine(Students[i].UserName +
                                    " " + Students[i].MajorID +
                                    " " + Students[i].FirstName);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}
