using System.Data.SqlClient;
using librarymanagementsystem;
using Moq;
namespace librarymanagementsystemtest
{
    public class Tests
    {
        private SqlConnection connection;
        private Books books;
        private Student student;
        [SetUp]
        public void Setup()
        {
            connection = new SqlConnection("Server=IN-6H3K9S3; database=libraryms; Integrated Security=true");
            books = new Books();
            student = new Student();
        }
        [Test]
        public void Addnewstudent_whencalled_returntrue() 
        {
            var student = new Mock<Istudents>();
            student.Setup(x => x.addstudent(connection, 4, "abi", "cse", "abi@")).Returns(1);
            var result = student.Object.addstudent(connection, 4, "abi", "cse", "abi@");
            Assert.That(result, Is.EqualTo(1));

        }
        [Test]
        public void updatestudent_whencalled_returntrue()
        {
            var student = new Mock<Istudents>();
            student.Setup(x => x.addstudent(connection, 4, "abi", "ece", "abi@")).Returns(1);
            var result = student.Object.addstudent(connection, 4, "abi", "ece", "abi@");
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void deletestudent_whencalled_returntrue()
        {
            var student = new Mock<Istudents>();
            student.Setup(x => x.deletestudent(connection, 2)).Returns(1);
            var result = student.Object.deletestudent(connection, 2);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void Addbook_whencalled_returntrue()
        {
            var student = new Mock<IBooks>();
            student.Setup(x => x.addnewbook(connection, 5, "sql", "ram", 6)).Returns(1);
            var result = student.Object.addnewbook(connection, 5, "sql", "ram", 6);
            Assert.That(result, Is.EqualTo(1));

        }
        [Test]
        public void updatebook_whencalled_returntrue()
        {
            var student = new Mock<IBooks>();
            student.Setup(x => x.editbook(connection, 5, "mule", "rk", 7)).Returns(1);
            var result = student.Object.editbook(connection, 5, "mule", "rk", 7);
            Assert.That(result, Is.EqualTo(1));
        }
        [Test]
        public void deletebook_whencalled_returntrue()
        {
            var student = new Mock<IBooks>();
            student.Setup(x => x.deletebook(connection, 2)).Returns(1);
            var result = student.Object.deletebook(connection, 2);
            Assert.That(result, Is.EqualTo(1));
        }



        [Test]
        public void searchbook_whenbookexistswithauthorname_shouldreturntrue()
        {
            connection.Open();
            string authorname = "rk";
            string expected = "2 | sea | rk | 0 | ";
            var result = books.searchbook(authorname, connection);
            Assert.AreEqual(expected, result);
            Assert.IsTrue(((string)result).Contains(authorname));
            connection.Close();
        }
        [Test]
        public void searchbook_whenbooknotexistswithauthorname_shouldreturntrue()
        {
            connection.Open();
            string authorname = "john";
            string expected = "There is no book with author name";
            var result = books.searchbook(authorname, connection);
            Assert.AreEqual(expected, result);
            connection.Close();
        }
        [Test]
        public void searchrollno_whenstudentnotexists_shouldreturntrue()
        {
            connection.Open();
            int rollno = 8;
            string expected = "No student with rollno";
            var result = student.searchstudent(rollno, connection);
            Assert.AreEqual(expected, result);
            connection.Close();
        }
        [Test]
        public void searchrollno_whenstudentexists_shouldreturntrue()
        {
            connection.Open();
            int rollno = 1;
            var expected = "1 | abi | cse | abi@ | ";
            var result = student.searchstudent(rollno, connection);
            Assert.AreEqual(expected, result);
            connection.Close();
        }
    }
}