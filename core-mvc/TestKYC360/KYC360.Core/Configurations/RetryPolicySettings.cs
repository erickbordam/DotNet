namespace KYC360.Core.Configurations
{
    public class RetryPolicySettings
    {
        public int MaxRetryAttempts { get; set; }
        public int InitialDelay { get; set; }
        public int MaxDelay { get; set; }
        public double BackoffFactor { get; set; }
    }
}
