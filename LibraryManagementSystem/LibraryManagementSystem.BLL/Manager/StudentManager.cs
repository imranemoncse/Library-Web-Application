using LibraryManagementSystem.DAL.Repository;
using LibraryManagementSystem.Model.Model;
using LibraryManagementSystem.Model.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LibraryManagementSystem.BLL.Manager
{
    public class StudentManager
    {
        StudentRepository _studentRepository = new StudentRepository();
        public bool Add(Student student, HttpPostedFileBase image)
        {
            return _studentRepository.Add(student,image);
        }

        public List<Student> GetAll()
        {
            return _studentRepository.GetAll();
        }
        public Student GetByUsername(string username)
        {
           
            return _studentRepository.GetByUsername(username);
        }

        public List<OrderVM> History(int Id)
        {
           
            return _studentRepository.History(Id); ;



        }

        public bool OrderBook(Order order)
        {


            return _studentRepository.OrderBook(order); ;



        }

        public List<OrderVM> Current(int Id)
        {

            return _studentRepository.Current(Id); ;



        }

        public bool IsSameBookBorrow(int studentID, int BookID)
        {
           
            return _studentRepository.IsSameBookBorrow(studentID,BookID);
        }

        public Book GetByBookID(int id)
        {
          

            return _studentRepository.GetByBookID( id);
        }
        public string IsExists(Student student)
        {

           

            return _studentRepository.IsExists(student);
        }
    }
}
