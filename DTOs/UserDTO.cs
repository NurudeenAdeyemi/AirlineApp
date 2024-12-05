using AirlineApp.Data.Authentication;

namespace AirlineApp.DTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string UserName { get; set; }

        public static User MapToUser(UserDTO userDTO)
        {
            var user = new User()
            {
                UserName = userDTO.UserName,
            };
            return user;
        }
        public static UserDTO MapToUserDTO(User user)
        {
            UserDTO userDTO = new UserDTO()
            {
                Id = user.Id,
                UserName = user.UserName,
            };
            return userDTO;
        }
    }
}