using TalentInsights.Application.Models.DTOs;
using TalentInsights.Application.Models.Request.Collaborator;
using TalentInsights.Application.Models.Response;

namespace TalentInsights.Application.Interfaces.Servicio
{
    public interface ICollaboratorService
    {
        public GenericResponse<CollaboratorDto> Create(CreateCollaboratorRequest model);

        public GenericResponse<CollaboratorDto> Update(Guid collaboratorId, UpdateCollaboratorRequest model);

        public GenericResponse<List<CollaboratorDto>> Get(int limit, int offeset);

        public GenericResponse<CollaboratorDto> Get(Guid collaboratorId);

        public GenericResponse<bool> Delete(Guid collaboratorId);


    }
}
