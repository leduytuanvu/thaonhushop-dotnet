using ErrorOr;

namespace ThaoNhuShop.Domain.Common.Errors
{
    public static class CategoryError
    {
        public static Error NotFoundCategory{ get; set; } = Error.NotFound(
                code: "NOT_FOUND_CATEGORY",
                description: "Not found any category");
        public static Error CreateNewFail{ get; set; } = Error.NotFound(
                code: "CREATE_NEW_FAIL",
                description: "Create new category fail");
        public static Error DeleteFail{ get; set; } = Error.Conflict(
                code: "DELETE_FAIL",
                description: "Delete category fail");
    }
}