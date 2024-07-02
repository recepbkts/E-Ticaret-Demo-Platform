using ecommerceAPI.Models;

namespace ecommerceAPI.Helpers
{
    public class ValidationHelper
    {
        public static bool IsProductCreateModelVlaid(ProductCreateModel model)
        {
            if(string.IsNullOrEmpty(model.ProductName))
                return false;
            if(model.ProductName.Length > 40)
                return false;
            if(model.QuantityPerUnit?.Length > 20)
                return false;

            return true;
        }
    }
}
