namespace DI.Test.Web.Controllers
{
    public static class Common
    {
        public static bool IntPositiveTryParse(string idStr, out int idVerified)
        {
            bool result = int.TryParse(idStr, out idVerified);

            if (idVerified <= 0)
                result = false;

            return result;
        }
    }
}
