using System;

namespace NeSoyledi.Api.Models.DataTypeObjects
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string UserNameSurname { get; set; }
        public string UserLoginName { get; set; }
        public string UserNiceName { get; set; }
        public string UserEmail { get; set; }
        public string UserUrl { get; set; }
        public string UserAvatar { get; set; }
        public string UserGender { get; set; }
        public string UserBirthday { get; set; }
        public bool UserStatus { get; set; }
    }

    public class UserLoginDTO
    {
        public string UserEmail { get; set; }
        public string UserPass { get; set; }
    }

    public class UserTokenUpdateDTO
    {
        public int Id { get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
    }

    public class SaveUserDTO
    {
        public string UserLoginName { get; set; }
        public string UserEmail { get; set; }
        public string UserPass { get; set; }
    }

    public class SaveUserResponseDTO
    {
        public string ErrorMessage { get; set; }
        public bool Status { get; set; }
    }
}
