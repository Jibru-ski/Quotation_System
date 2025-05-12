using System.ComponentModel.DataAnnotations;

namespace QuotationSys.Models;

public class Customer
{
    public int CustomerId { get; set; }

    public required string CompanyName { get; set; }

    public required string ContactPerson { get; set; }

    public required string Email { get; set; }

    public required string PhoneNumber { get; set; }

    public required string Address { get; set; }
    public DateOnly CreatedOn { get; set; }

    public DateOnly ModifiedOn { get; set; }

    // Navigation
    public ICollection<Quotation> Quotations { get; set; } = new List<Quotation>();
}