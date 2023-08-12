namespace PatientInfoApi
{
    public class ServiceResponse
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; }
        public Patient Patient { get; set; }
    }
}
