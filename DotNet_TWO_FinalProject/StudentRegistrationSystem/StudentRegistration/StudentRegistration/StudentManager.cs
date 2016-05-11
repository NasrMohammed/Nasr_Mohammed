using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;
using DataAccess;

namespace BusinessLogic
{
    public class StudentManager
    {
        public int GetStudentCount(Active type)
        {
            int count = 0;

            try
            {
                count = StudentAccessor.FetchStudentCount(type);
            }
            catch (Exception)
            {
                throw;
            }

            return count;
        }

        public List<Student> GetStudentList()
        {
            try
            {
                return StudentAccessor.FetchStudentList();
            }
            catch (Exception ex)
            {
                // in practice, the right thing to do would be to log
                // the exception and throw something user-friendly to
                // the presentation layer
                throw new ApplicationException("Bad Mojo! No records.", ex);
            }
        }

        public bool ChangeStudentRecord(int studentID, string userName,  string firstName, string lastName, string phone, string address, string emailAddress)
        {
            bool result = false;

            if (emailAddress.Length > 100)
            {
                throw new ApplicationException("Email Address is Too Long");
            }
            else if (studentID < 1000)
            {
                throw new ApplicationException("Invalid Student ID");
            }
            try
            {
                var count = StudentAccessor.UpdateStudentRecord(studentID, userName,  firstName, lastName, phone, address, emailAddress);
                if (count == 1)
                {
                    result = true;
                }
                else if (count == 0)
                {
                    result = false;
                }
                else
                {
                    throw new ApplicationException("Multiple records found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }
        public bool ChangeDeleteStudentRecord(int userID)
        {
            bool result = false;

            if (userID < 100)
            {
                throw new ApplicationException("Email Address is Too Long");
            }
            else if (userID > 10000000)
            {
                throw new ApplicationException("Invalid Student ID");
            }
            try
            {
                var count = StudentAccessor.DeleteStudentRecord(userID);
                if (count == 1)
                {
                    result = true;
                }
                else if (count == 0)
                {
                    result = false;
                }
                else
                {
                    throw new ApplicationException("Multiple records found!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return result;
        }


        public bool AddNewStudent(
            // int userID,        
                            string userName,
                            string majorID,
                            string firstName,
                            string lastName,
                            string phone,
                            string address,
                            string email
            //bool active
                            )
        {
            // we should have some validation on the passed params
            var std = new Student()
            {
                UserName = userName,
                MajorID = majorID,
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Address = address,
                Email = email,
                //Active = active,


            };

            try
            {
                if (StudentAccessor.InsertStudent(std) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public bool AddNewMajor(string majorID, string majorName)
        {
            // we should have some validation on the passed params
            var mjr = new Major()
            {
                MajorID = majorID,
                MajorName = majorName,
            };

            try
            {
                if (StudentAccessor.InsertMajors(mjr) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public bool AddNewClass(string classID, string departmentID, string description, string numOfSeats, string className)
        {
            // we should have some validation on the passed params
            var cls = new Classes()
            {
                ClassID = classID,
                DepartmentID = departmentID,
                Description = description,
                NumOfSeats = numOfSeats,
                ClassName = className


            };

            try
            {
                if (StudentAccessor.InsertClass(cls) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Major> GetMajorsList()
        {

            try
            {
                return StudentAccessor.FetchMajorList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(" No records Found!.", ex);
            }

        }
        public List<Classes> GetClassesList()
        {

            try
            {
                return StudentAccessor.FetchClassList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(" No records Found!.", ex);
            }

        }
        public bool AddNewDepartment(string departmentID, string departmentName)
        {
            // we should have some validation on the passed params
            var dpr = new Department()
            {
               DepartmentID = departmentID,
               DepartmentName = departmentName

            };

            try
            {
                if (StudentAccessor.InsertDepartment(dpr) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Department> GetDepartmentList()
        {

            try
            {
                return StudentAccessor.FetchDepartmentList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(" No records Found!.", ex);
            }

        }
        public bool AddNewSection(string sectionID, int userID, string termID, string locationID)
        {
            // we should have some validation on the passed params
            var sec = new Section()
            {
                SectionID = sectionID,
                UserID = userID,
                TermID = termID,
                LocationID = locationID

            };

            try
            {
                if (StudentAccessor.InsertSection(sec) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Section> GetSectionList()
        {

            try
            {
                return StudentAccessor.FetchSectionList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(" No records Found!.", ex);
            }

        }
        public bool AddNewLocation(string locationID, string locationName)
        {
            // we should have some validation on the passed params
            var loc = new Location()
            {
                LocationID = locationID,
                LocationName = locationName

            };

            try
            {
                if (StudentAccessor.InsertLocation(loc) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Location> GetLocationList()
        {

            try
            {
                return StudentAccessor.FetchLocationList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(" No records Found!.", ex);
            }

        }
        public bool AddNewEnrolment(string enrolmentID, int userID, string classID, string sectionID)
        {
            // we should have some validation on the passed params
            var enr = new Enrolment()
            {
                EnrolmentID = enrolmentID,
                UserID = userID,
                ClassID = classID, 
                SectionID = sectionID

            };

            try
            {
                if (StudentAccessor.InsertEnrolment(enr) == 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public List<Enrolment> GetEnrolemtList()
        {

            try
            {
                return StudentAccessor.FetchEnrolmentList();
            }
            catch (Exception ex)
            {
                throw new ApplicationException(" No records Found!.", ex);
            }

        }

    }
}

