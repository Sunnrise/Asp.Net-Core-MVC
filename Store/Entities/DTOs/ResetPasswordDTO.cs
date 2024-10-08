using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public record ResetPasswordDTO
    {
        public string? UserName { get; init; }


        [DataType(DataType.Password)]

        [Required(ErrorMessage ="Password is required")]
        public string? Password { get; init; }


        [DataType(DataType.Password)]

        [Required(ErrorMessage ="ConfirmPassword is required")]
        [Compare("Password", ErrorMessage ="Password and Confirm password must be match")]
        public string? ConfirmPassword { get; init; }
    }
}