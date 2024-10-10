namespace api.model
{
    public interface iUser
    {
        User  CreateUser(string userId, string username, string password, string role);
        User CreateUser(string id);
    }
}
