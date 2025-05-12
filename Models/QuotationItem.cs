using System.ComponentModel.DataAnnotations.Schema;

namespace QuotationSys.Models;

public class QuotationItem
{
    public int QuotationItemId { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total => Quantity * UnitPrice;

    // Foreign key to Quotation
    public int QuotationId { get; set; }

    [ForeignKey("QuotationId")]
    public required Quotation Quotation { get; set; }

    // Optional link to a product
    public int? ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}