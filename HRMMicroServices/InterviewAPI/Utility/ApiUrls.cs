namespace InterviewAPI.Utility
{
    public static class ApiUrls
    {
        public static string GetCandidate => "http://host.docker.internal:40123/api/candidate/get/";
        public static string GetSubmission => "http://host.docker.internal:40123/api/submission/get/";
    }
}
