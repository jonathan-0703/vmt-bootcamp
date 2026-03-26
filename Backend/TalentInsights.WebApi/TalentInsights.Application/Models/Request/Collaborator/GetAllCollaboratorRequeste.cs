namespace TalentInsights.Application.Models.Request.Collaborator
{
    public class GetAllProyectRequest
    {
        public int limit { get; set; }
        public int offset { get; set; }
        public string? gittlahProfile { get; set; }
        public string? FullName { get; set; }
    }
}
