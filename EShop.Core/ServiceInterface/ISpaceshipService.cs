using EShop.Core.Domain;
using EShop.Core.Dtos;
using System;
using System.Threading.Tasks;

namespace EShop.Core.ServiceInterface
{
    public interface ISpaceshipService : IApplicationService
    {
        Task<Spaceship> GetAsync(Guid id);
        Task<Spaceship> Add(SpaceshipDto dto);
        Task<Spaceship> Update(SpaceshipDto dto);
        Task<Spaceship> Delete(Guid id);
        Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto);
    }
}
