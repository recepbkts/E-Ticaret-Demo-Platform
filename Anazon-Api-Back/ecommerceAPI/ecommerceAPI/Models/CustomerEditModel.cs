namespace ecommerceAPI.Models
{
    public class CustomerEditModel
    {
        public string CustomerId { get; set; } = null!;

        public string FirstName { get; set; } = null!;

        public string LastName { get; set; } = null!;

        public string? Gender { get; set; } //? yani null olabilir yani Gender varsa ekle

        public DateOnly? BirthDate { get; set; }

        public string? Country { get; set; }

        public string? Province { get; set; }

        public string? City { get; set; }

        public string? Address { get; set; }

        public int? PostalCode { get; set; }

        public string? Photo { get; set; }

        public string? Mobile { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

    }
}
