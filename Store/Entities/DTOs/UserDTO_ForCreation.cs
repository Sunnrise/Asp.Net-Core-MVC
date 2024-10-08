using System.ComponentModel.DataAnnotations;

namespace Entities.DTOs
{
    public record UserDTO_ForCreation : UserDTO
    {
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required.")]
        public string Password { get; init; }
    }
}