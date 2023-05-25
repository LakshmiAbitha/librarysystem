using System.ComponentModel.Design;
using System.Data.SqlClient;

namespace librarymanagementsystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con = new SqlConnection("Server=IN-6H3K9S3; database=libraryms; Integrated Security=true");
            con.Open();
            Books books = new Books();
            Student student = new Student();
            Console.WriteLine("Enter the username");
            string username = Console.ReadLine();
            Console.WriteLine("Enter the password");
            string userpassword = Console.ReadLine();
            SqlCommand cmd = new SqlCommand("select count(*) from logindetails where username=@username and userpassword=@userpassword", con);
            cmd.Parameters.AddWithValue("@username", username);
            cmd.Parameters.AddWithValue("@userpassword", userpassword);
            int ac = (int)cmd.ExecuteScalar();
            if(ac > 0)
            {
                while (true)
                {
                    Console.WriteLine("--- Welcome to Library Management Menu---");
                    Console.WriteLine("1.Add Book");
                    Console.WriteLine("2.update book");
                    Console.WriteLine("3.delete book");
                    Console.WriteLine("4.Add student");
                    Console.WriteLine("5.update student");
                    Console.WriteLine("6.delete student");
                    Console.WriteLine("7.Issue book to student");
                    Console.WriteLine("8.Return books from student and add in available stock");
                    Console.WriteLine("9.search book based on author name");
                    Console.WriteLine("10.search student based on student rollno");
                    Console.WriteLine("11.We can see that how many students have books right now");
                    Console.WriteLine("Enter your choice");
                    int choice = Convert.ToInt32(Console.ReadLine());
                    switch (choice)
                    {
                        case 1:
                            {
                                Console.WriteLine("Enter the book id");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the book name");
                                string bookname = Console.ReadLine();
                                Console.WriteLine("Enter the book author name");
                                string authorname = Console.ReadLine();
                                Console.WriteLine("Enter the book quantity");
                                int quantity = Convert.ToInt32(Console.ReadLine());
                                books.addnewbook(con,bookid,bookname,authorname,quantity);
                                break;
                            }
                        case 2:
                            {
                                Console.WriteLine("Entet the id to update");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the  new book name");
                                string bookname = Console.ReadLine();
                                Console.WriteLine("Enter the new book authorname");
                                string authorname = Console.ReadLine();
                                Console.WriteLine("Enter the new book quantity");
                                int quantity = Convert.ToInt32(Console.ReadLine());
                                books.editbook(con,bookid,bookname,authorname,quantity);
                                break;
                            }
                        case 3:
                            {
                                Console.WriteLine("Entet the id to delete");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                books.deletebook(con,bookid);
                                break;
                            }
                        case 4:
                            {
                                Console.WriteLine("Enter the student rollno");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the student name");
                                string sname = Console.ReadLine();
                                Console.WriteLine("Enter the student department");
                                string dept = Console.ReadLine();
                                Console.WriteLine("Enter the email");
                                string email = Console.ReadLine();
                                student.addstudent(con,rollno,sname,dept,email);
                                break;
                            }
                        case 5:
                            {
                                Console.WriteLine("Enter the student rollno");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the student name");
                                string sname = Console.ReadLine();
                                Console.WriteLine("Enter the student department");
                                string dept = Console.ReadLine();
                                Console.WriteLine("Enter the email");
                                string email = Console.ReadLine();
                                student.editstudent(con,rollno,sname,dept,email);
                                break;
                            }
                        case 6:
                            {
                                Console.WriteLine("Enter the student rollno");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                student.deletestudent(con,rollno);
                                break;
                            }
                        case 7:
                            {
                                Console.WriteLine("Enter the student rollno");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the bookid");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                books.issuebook(con,rollno,bookid);
                                break;
                            }
                        case 8:
                            {
                                Console.WriteLine("Enter the student rollno");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                Console.WriteLine("Enter the bookid");
                                int bookid = Convert.ToInt32(Console.ReadLine());
                                books.returnbook(con,rollno,bookid);
                                break;
                            }
                        case 9:
                            {
                                Console.WriteLine("Enter the author name to view");
                                string authorname = Console.ReadLine();
                                string searchresult = books.searchbook(authorname, con);
                                Console.WriteLine(searchresult);
                                break;
                            }
                        case 10:
                            {
                                Console.WriteLine("Enter the student rollno to get");
                                int rollno = Convert.ToInt32(Console.ReadLine());
                                string result = student.searchstudent(rollno, con);
                                Console.WriteLine(result);
                                break;
                            }
                        case 11:
                            {
                                student.studenthavebook(con);
                                break;
                            }
                        default:
                            {
                                Console.WriteLine("Invlaid option please enter correct option");
                                break;
                            }
                    }
                    
                }

            }
            else
            {
                Console.WriteLine("Invalid username and password");
            }
            con.Close();
        }
    }
}