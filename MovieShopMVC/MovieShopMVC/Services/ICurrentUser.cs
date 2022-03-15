namespace MovieShopMVC.Services
{
    public interface ICurrentUser
    {
        bool IsAuthenticated { get; }
        int UserId { get; }
        string Email { get; }
        string Firstname { get; }
        string Lastname { get; }
        bool IsAdmin { get; }
        List<string> Roles { get; }
        string IpAddress { get; }

    }
}
