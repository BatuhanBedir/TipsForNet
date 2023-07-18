namespace Entity;

public sealed class Role
{
    public Role()
    {
        UserRoles = new HashSet<UserRole>();
    }
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<UserRole> UserRoles { get; set; }
}
