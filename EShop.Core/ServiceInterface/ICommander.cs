using EShop.Core.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EShop.Core.ServiceInterface
{
    public interface ICommander : IApplicationService
    {
        Task<Command> GetAsyncId(Guid id);

        //IEnumerable<Command> GetAppCommands();
        //Command GetCommandById(int id);
    }
}
