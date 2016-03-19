namespace ToastmastersTimer.UWP.Features.Authentication
{
    public class UserData
    {
        public UserData(string displayName, string city, string country, string status, string sessionId)
        {
            Status = status;
            DisplayName = displayName;
            City = city;
            Country = country;
            SessionId = sessionId;
        }

        public string DisplayName { get; }

        public string City { get; }

        public string Country { get; }

        public string Status { get; }

        public string SessionId { get; }
    }
}