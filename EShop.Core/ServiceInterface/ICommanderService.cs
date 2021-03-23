using EShop.Core.Domain;
using EShop.Core.Dtos;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Core.ServiceInterface
{
    public interface ICommanderService : IApplicationService
    {
        Task<Command> GetAsyncId(Guid id);
        Task<Command> Update(CommanderDto dto);
        Task<Command> Add(CommanderDto dto);
        Task<Command> Delete(Guid id);
    }
}
