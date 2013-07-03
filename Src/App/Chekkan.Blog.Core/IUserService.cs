namespace Chekkan.Blog.Core
{
    public interface IUserService
    {
        bool IsValid(string email, string password);
    }
}
