namespace Entity;

public sealed class User
{
    public User()
    {
        UserRoles = new HashSet<UserRole>();
    }
    public int Id { get; set; }
    public string UserName { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
