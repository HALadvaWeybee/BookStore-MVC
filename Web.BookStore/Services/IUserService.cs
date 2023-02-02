namespace Web.BookStore.Services
{
    public interface IUserService
    {
        string GetUserId();
        bool IsAuthenticated();
    }
}