using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
namespace librarymanagementsystem
{
    public interface Istudents
    {
        public int addstudent(SqlConnection con,int rollno, string sname, string dept, string email);
        public int editstudent(SqlConnection con,int rollno,string sname, string dept, string email);

        public int deletestudent(SqlConnection con,int rollno);
    }
}
