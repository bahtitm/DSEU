namespace DSEU.Infrastructure.StateRegisterSearch
{
    public class ElasticSearchOptions
    {
        public string IndexName { get; set; }
        public string UriAddress { get; set; }
        public int RetryOnConflict { get; set; }
        public int ResponseIndexFrom { get; set; }
        public int ResponseCount { get; set; }
        public int SlopCount { get; set; }
        public double BoostValue { get; set; }
        public int EditDistanceCount { get; set; }
    }
}
