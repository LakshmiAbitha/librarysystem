using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace librarymanagementsystem
{
    public interface IBooks
    {
        public int addnewbook(SqlConnection con,int bookid, string bookname, string authorname,int quantity);

        public int editbook(SqlConnection con,int bookid,string bookname,string authorname,int quantity);

        public int deletebook(SqlConnection con,int bookid);

    }
}
