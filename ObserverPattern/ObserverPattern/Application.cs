
namespace ObserverPattern
{
    public class Application(int jobId, string applicantName)
    {
        public int JobId { get; set; } = jobId;
        public string ApplicantName { get; set; } = applicantName;
    }
}
