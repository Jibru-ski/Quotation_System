using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace QuotationSysAuth.Models;

public class User : IdentityUser
{
    [MaxLength(50)]
    [Display(Name = "First Name")]
    public required string FirstName { get; set; }

    [MaxLength(50)]
    [Display(Name = "Last Name")]
    public required string LastName { get; set; }

    [MaxLength(500)]
    [Display(Name = "Profile Picture")]
    public string? ProfilePicture { get; set; }

    [MaxLength(250)]
    public string? Address { get; set; }

    [Display(Name = "Date of Birth")]
    [DataType(DataType.Date)]
    public DateTime? DateOfBirth { get; set; }

    [MaxLength(500)]
    public string? Bio { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool IsActive { get; set; } = true;
    public DateTime? LastLoginDate { get; set; }
}