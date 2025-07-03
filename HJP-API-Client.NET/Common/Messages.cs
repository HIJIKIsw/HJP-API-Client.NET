namespace Hjp.Api.Client.Common
{
    public static class Messages
    {
        public static class Erros
        {
            public const string NotLoggedInWithUser = "先に LoginWithUserAsync を実行してください。";
            public const string NotLoggedInWithModerator = "先に LoginWithModeratorAsync を実行してください。";
            public const string NotLoggedInWithAdmin = "先に LoginWithAdminAsync を実行してください。";

            public const string EmptyResponseBody = "Empty response body";
        }
    }
}