namespace ecommerceAPI.Helpers
{
    public class İmageHelper
    {
        public static string? ByteToString(byte[]? image) 
        { 
            try
            {
                if (image == null) 
                    return null;
                return "data:image;base64," + Convert.ToBase64String(image);
            }
            catch
            {
                return null;
            }
        }

        public static byte[]? StringToByte(string? image)
        {
            try
            {
                if (image == null) return null;
                return Convert.FromBase64String(image.Split(',')[1]);
            }
            catch
            {
                return null;
            }
        }
    }
}
