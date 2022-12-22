using ErrorOr;

namespace ThaoNhuShop.Domain.Common.Errors
{
    public static class AuthenticationError
    {
        public static Error PhoneOrPasswordWrong{ get; set; } = Error.NotFound(
                code: "PHONE_OR_PASSWORD_WRONG",
                description: "Phone number or password wrong");  

        public static Error DuplicatePhone{ get; set; } = Error.Conflict(
                code: "PHONE_DUPLICATE",
                description: "This phone number is already registered");

        public static Error PasswordNotMatch{ get; set; } = Error.Validation(
                code: "PASSWORD_NOT_MATCH",
                description: "Password not match with re-password");  

        public static Error CreateUserFail{ get; set; } = Error.Conflict(
                code: "CREATE_USER_FAIL",
                description: "Create user fail");  
        
        public static Error GenerateTokenFail{ get; set; } = Error.Conflict(
                code: "GENERATE_TOKEN_FAIL",
                description: "Generate token fail");
    }
}