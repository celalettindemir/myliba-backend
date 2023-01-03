using System.ComponentModel.DataAnnotations;

namespace Case.Domain.DTO;

public class PersonalUpdateDTO
{
    public string Id { get; set; }
    [MinLength(3,ErrorMessage = "The name is minimum 3 length ")]
    [Required(ErrorMessage = "The name is required")]
    public string Name { get; set; }
    [MinLength(3,ErrorMessage = "The surname is minimum 3 length")]
    [Required(ErrorMessage = "The surname is required")]
    public string Surname { get; set; }
    [Required(ErrorMessage = "The email address is required")]
    [EmailAddress(ErrorMessage = "Invalid Email Address")]
    public string Email { get; set; }
    public bool IsDeleted { get; set; }
}