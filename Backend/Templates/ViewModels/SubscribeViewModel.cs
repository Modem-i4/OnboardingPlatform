
namespace Templates.ViewModels
{
    public class SubscribeViewModel
    {
        public SubscribeViewModel(string courseName, string userName, string startDate, string endDate)
        {
            CourseName = courseName;
            UserName = userName;
            StartDate = startDate;
            EndDate = endDate;
        }

        public string CourseName { get; set; }
        public string UserName { get; set; }

        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
