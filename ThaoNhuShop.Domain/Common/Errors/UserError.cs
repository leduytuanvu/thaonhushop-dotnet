using ErrorOr;

namespace ThaoNhuShop.Domain.Common.Errors
{
    public static class UserError
    {
        public static Error DuplicatePhone{ get; set; } = Error.Conflict(
                code: "PHONE_DUPLICATE",
                description: "Phone already exists");
    }
}