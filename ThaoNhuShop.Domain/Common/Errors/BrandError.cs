using ErrorOr;

namespace ThaoNhuShop.Domain.Common.Errors
{
    public static class BrandError
    {
        public static Error NotFoundBrand{ get; set; } = Error.NotFound(
                code: "NOT_FOUND_BRAND",
                description: "Not found any brand");
        public static Error CreateNewFail{ get; set; } = Error.NotFound(
                code: "CREATE_NEW_FAIL",
                description: "Create new brand fail");
        public static Error DeleteFail{ get; set; } = Error.NotFound(
                code: "DELETE_FAIL",
                description: "Delete brand fail");
    }
}