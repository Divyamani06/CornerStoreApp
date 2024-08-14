namespace CornerStore.API.Models
{
    public class ErrorMessage
    {
        public const string UserAlreadyRegistered = "User already registered.";
        public const string UserCreationFailed = "User creation failed! Please check user details and try again.";
        public const string UserCreatedSuccessfully = "User created successfully!.";
        public const string UserNotFound = "User not found!.";
        public const string PasswordMismatch = "Password mismatch!";
        public const string UserRoleAssignmentFailed = "User Role Assignment Failed";
        public const string AdminRoleAlreadyExits= "Admin and User role already exits";
        public const string UserRoleAlredyExits = "User role already exits";
    }
}
