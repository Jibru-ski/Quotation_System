using System.ComponentModel.DataAnnotations.Schema;
using QuotationSys.Models;

namespace QuotationSys.Models;

public class Quotation
{
    public int QuotationId { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;

    public required string Status { get; set; }

    // Foreign key to Customer
    public int CustomerId { get; set; }

    [ForeignKey("CustomerId")]
    public required Customer Customer { get; set; }

    // Navigation
    public required ICollection<QuotationItem> QuotationItems { get; set; }
}