using TalentInsights.Application.Helpers;
using TalentInsights.Application.Interfaces.Servicio;
using TalentInsights.Application.Models.DTOs;
using TalentInsights.Application.Models.Request.Collaborator;
using TalentInsights.Application.Models.Response;
using TalentInsing.Shared.Helper;

namespace TalentInsights.Application.Services
{
    public class CollaboratorService : ICollaboratorService
    {
        public GenericResponse<CollaboratorDto> Create(CreateCollaboratorRequest model)
        {
            var creat = new CollaboratorDto
            {
                CollaboratorId = Guid.NewGuid(),
                FullName = model.FullName,
                GitlabProfile = model.GitlabProfile,
                Positions = model.Positions,
                CreatedAt = DateTimeHelper.UtcNow(),
                JoinedAt = DateTimeHelper.UtcNow(),
            };
            return ResponseHelper.Create(creat);
        }

        public GenericResponse<bool> Delete(Guid collaboratorId)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<List<CollaboratorDto>> Get(int limit, int offeset)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<CollaboratorDto> Get(Guid collaboratorId)
        {
            throw new NotImplementedException();
        }

        public GenericResponse<CollaboratorDto> Update(Guid collaboratorId, UpdateCollaboratorRequest model)
        {
            throw new NotImplementedException();
        }
    }
}
