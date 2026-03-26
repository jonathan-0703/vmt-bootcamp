namespace TalentInsights.Application.Models.DTOs
{
    public class ProyectDto
    {
        public Guid ProyectId { get; set; }
        public string ProyectName { get; set; }

        public string ProyectDescription { get; set; }

        public DateTime JoinedAt { get; set; }

        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
