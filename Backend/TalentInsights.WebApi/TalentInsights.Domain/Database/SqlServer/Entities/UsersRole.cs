namespace TalentInsights.Domain.Database.SqlServer.Entities;

public partial class UsersRole
{
    public Guid UserId { get; set; }

    public int RoleId { get; set; }
}