namespace TalentInsights.Application.Models.Request.Proyect
{
    public class GetAllProyectRequest
    {

        public int limit { get; set; }
        public int offset { get; set; }
        public string? ProyectName { get; set; }

    }
}
