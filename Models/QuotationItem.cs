using System.ComponentModel.DataAnnotations.Schema;

namespace QuotationSys.Models;

public class QuotationItem
{
    public int QuotationItemId { get; set; }

    public string Description { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal Total => Quantity * UnitPrice;
    
    public int QuotationId { get; set; }

    [ForeignKey("QuotationId")]
    public Quotation Quotation { get; set; }

    public int? ProductId { get; set; }

    [ForeignKey("ProductId")]
    public Product? Product { get; set; }
}