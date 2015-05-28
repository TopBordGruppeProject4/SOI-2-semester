namespace SHI.Model
{
    public class Worker: Person
    {
        public override string Address { get; set; }
        public override int Id { get; set; }
        public override string Name { get; set; }
        public override string Tlf { get; set; }

        public bool Admin { get; set; }

        public string Username { get; set; }
        public string Password { get; set; }

        public Worker(string address, int id, string name, string tlf, bool admin, string username, string password)
        {
            Address = address;
            Id = id;
            Name = name;
            Tlf = tlf;
            Admin = admin;
            Username = username;
            Password = password;
        }

        public override string ToString()
        {
            //return string.Format("Address: {0}, Id: {1}, Name: {2}, Tlf: {3}, Admin: {4}, Username: {5}, Password: {6}", Address, Id, Name, Tlf, Admin, Username, Password);
            return Name;
        }
    }
}
