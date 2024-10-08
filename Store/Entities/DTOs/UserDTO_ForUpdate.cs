namespace Entities.DTOs
{
    public record UserDTO_ForUpdate: UserDTO
    {
        public HashSet<string> UserRoles {get;set;}=new HashSet<string>();
    }
}