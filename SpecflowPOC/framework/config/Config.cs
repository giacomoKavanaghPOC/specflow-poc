namespace SpecflowPOC.framework.config
{
    public static class Config
    {
        //Would need to make configurable for use with different test environments, 
        //potentially parse a json configholder object
        public static string baseUrl = "http://www.qaworks.com/";
        public static int webDriverWait = 30;
    }
}
