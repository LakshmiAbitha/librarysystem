using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace librarymanagementsystem
{
    public class Student:Istudents
    {
        public int addstudent(SqlConnection con, int rollno, string sname,string dept,string email)
        {
            SqlCommand cmd = new SqlCommand($"insert into studentdetails values(@rollno,@sname,@dept,@email)", con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@email", email);
            int res = cmd.ExecuteNonQuery();
            Console.WriteLine("student inserted successfully");
            return res;
        }
        public int editstudent(SqlConnection con, int rollno, string sname, string dept, string email)
        {
            SqlCommand cmd = new SqlCommand("update studentdetails set sname=@sname,dept=@dept,email=@email where rollno=@rollno", con);
            cmd.Parameters.AddWithValue("rollno", rollno);
            cmd.Parameters.AddWithValue("@sname", sname);
            cmd.Parameters.AddWithValue("@dept", dept);
            cmd.Parameters.AddWithValue("@email", email);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Student was updated successfully");
            }
            else
            {
                Console.WriteLine("Student details not found");
            }
            return result;
        }
        public int deletestudent(SqlConnection con, int rollno)
        {
            SqlCommand cmd = new SqlCommand($"delete from studentdetails where rollno=@rollno ", con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            int result1 = cmd.ExecuteNonQuery();
            if (result1 > 0)
            {
                Console.WriteLine("student deleted successfully");
            }
            else
            {
                Console.WriteLine("there is no student with such id to delete");
            }
            return result1;
        }
        public string searchstudent(int rollno, SqlConnection con)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand($"select * from studentdetails where rollno=@rollno", con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result += $"{reader[i]} | ";
                    }
                }
            }
            else
            {
                result = "No student with rollno";
            }
            reader.Close();
            return result;
        }
        public int studenthavebook(SqlConnection con)
        {
            SqlCommand cmd = new SqlCommand($"select count(*) from issuebook", con);
            int sb = (int)cmd.ExecuteScalar();
            Console.WriteLine($"Students having the books are {sb}");
            return sb;
        }
    }
}

