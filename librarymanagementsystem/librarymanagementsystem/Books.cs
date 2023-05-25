using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Net;

namespace librarymanagementsystem
{
    public class Books : IBooks
    {
        public int addnewbook(SqlConnection con, int bookid, string bookname, string authorname, int quantity)
        {
            SqlCommand cmd = new SqlCommand($"insert into bookdetails values(@bookid,@bookname,@authorname,@quantity)", con);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            cmd.Parameters.AddWithValue("@bookname", bookname);
            cmd.Parameters.AddWithValue("@authorname", authorname);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int res = cmd.ExecuteNonQuery();
            Console.WriteLine("database inserted new book");
            return res;

        }
        public int editbook(SqlConnection con, int bookid, string bookname, string authorname, int quantity)
        {
            SqlCommand cmd = new SqlCommand("update bookdetails set bookname=@bookname,authorname=@authorname,quantity=@quantity where bookid=@bookid", con);
            cmd.Parameters.AddWithValue("bookid", bookid);
            cmd.Parameters.AddWithValue("@bookname", bookname);
            cmd.Parameters.AddWithValue("@authorname", authorname);
            cmd.Parameters.AddWithValue("@quantity", quantity);
            int result = cmd.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Book is  updated successfully");
            }
            else
            {
                Console.WriteLine("Book is  not found");
            }
            return result;
        }
        public int deletebook(SqlConnection con, int bookid)
        {
            SqlCommand cmd = new SqlCommand($"delete from bookdetails where bookid=@bookid ", con);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            int result1 = cmd.ExecuteNonQuery();
            if (result1 > 0)
            {
                Console.WriteLine("Book is deleted successfully");
            }
            else
            {
                Console.WriteLine("there is no book with such id to delete");
            }
            return result1;
        }
        public void issuebook(SqlConnection con,int rollno,int bookid)
        {
            SqlCommand cmd = new SqlCommand($"select * from bookdetails where bookid=@bookid", con);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                int quantity = Convert.ToInt32(reader["quantity"]);
                if (quantity > 0)
                {
                    reader.Close();
                    SqlCommand cmd2 = new SqlCommand($"insert into issuebook values(@rollno,@bookid)", con);
                    cmd2.Parameters.AddWithValue("@rollno", rollno);
                    cmd2.Parameters.AddWithValue("@bookid", bookid);
                    cmd2.ExecuteNonQuery();
                    Console.WriteLine("Succesfully issued book to student");
                    SqlCommand cmd3 = new SqlCommand($"update bookdetails set quantity=@quantity where bookid=@bookid", con);
                    cmd3.Parameters.AddWithValue("@bookid", bookid);
                    cmd3.Parameters.AddWithValue("@quantity", quantity - 1);
                    cmd3.ExecuteNonQuery();
                    Console.WriteLine("Successfully updated quantity");
                }
                else
                {
                    Console.WriteLine("Book quantity is zero");
                }
            }
            else
            {
                Console.WriteLine("No book found");
            }
            reader.Close();
        }
        public void returnbook(SqlConnection con,int rollno,int bookid)
        {
            SqlCommand cmd = new SqlCommand($"select * from issuebook where rollno=@rollno and bookid=@bookid", con);
            cmd.Parameters.AddWithValue("@rollno", rollno);
            cmd.Parameters.AddWithValue("@bookid", bookid);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Close();
                SqlCommand cmd2 = new SqlCommand($"delete from issuebook where rollno=@rollno and bookid=@bookid", con);
                cmd2.Parameters.AddWithValue("@rollno", rollno);
                cmd2.Parameters.AddWithValue("@bookid", bookid);
                cmd2.ExecuteNonQuery();
                Console.WriteLine("Successfully return book");
                SqlCommand cmd3 = new SqlCommand($"update bookdetails set quantity=quantity +1 where bookid=@bookid", con);
                cmd3.Parameters.AddWithValue("@bookid", bookid);
                cmd3.ExecuteNonQuery();
                Console.WriteLine("Successfully updated quantity");
            }
            else
            {
                Console.WriteLine("No book issued to student");
            }
            reader.Close();
        }
        public string searchbook(string authorname, SqlConnection con)
        {
            string result = "";
            SqlCommand cmd = new SqlCommand($"select * from bookdetails where authorname=@authorname", con);
            cmd.Parameters.AddWithValue("@authorname", authorname);
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        result += ($"{reader[i]} | ");
                    }
                }
            }
            else
            {
                result = "There is no book with author name";
            }
            reader.Close();
            return result;
        }
    }
}
