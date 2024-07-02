using System;
using System.Collections.Generic;

namespace ecommerceAPI.Models.Database;

public partial class Employee
{
    public int EmployeeId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string? Gender { get; set; }

    public DateOnly? BirthDate { get; set; }

    public string? Country { get; set; }

    public string? Province { get; set; }

    public string? City { get; set; }

    public string? Address { get; set; }

    public string? PostalCode { get; set; }

    public byte[]? Photo { get; set; }

    public string? Mobile { get; set; }

    public DateOnly? HireDate { get; set; }

    public string? Username { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
