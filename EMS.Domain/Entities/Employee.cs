using EMS.Domain.Base;

namespace EMS.Domain.Entities
{
    public record Employee : Entity<int>
    {
        public Employee(string firstName, string lastName, string email, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Position = position;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Position { get; set; }

        public static Employee Create(
            string firstName,
            string lastName,
            string email,
            string position
        ) => new Employee(firstName, lastName, email, position);

        public void Update(string firstName, string lastName, string email, string position)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            Position = position;
        }
    }
}
