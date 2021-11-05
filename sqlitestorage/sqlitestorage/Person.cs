using SQLite;

namespace sqlitestorage
{
    public class Person
    {
        [PrimaryKey, AutoIncrement]
        public int PersonID { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Confirmpassword { get; set; }
        public string Date { get; set; }

        public string Phonenumber { get; set; }
    }
}