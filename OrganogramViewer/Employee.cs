namespace OrganogramViewer
{
    public class Employee
    {
        public int Id { get; set; }

        public int SuperiorId { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string GetGetFullName()
        {
            return Name + " " + Surname;
        }

        public string Company { get; set; }

        public string City { get; set; }

        public string Position { get; set; }
    }
}
