namespace JapPlatformBackend.Services.Helpers
{
    public static class EmailHelpers
    {
        public const string Subject = "JAP Platform Credentials";
        public static string CreateTemplate(string username, string password)
        {
            return $"<html><body>" +
                $"<p>Dear student</p>" +
                $"<p>Your JAP Platform profile is ready.</p>" +
                $"<p>Your credentials are: <br/> " +
                $"Username: {username}, Password: {password}</p>" +
                $"</body></html>";
        }
    }
}
