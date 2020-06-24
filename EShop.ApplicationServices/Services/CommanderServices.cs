using EShop.Core.Domain;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EShop.ApplicationServices.Services
{
    public class CommanderServices : ICommander
    {
        private readonly EShopDbContext _context;

        CommanderServices(
            EShopDbContext context
            )
        {
            _context = context;
        }


        public async Task<Command> GetAsyncId(Guid id)
        {
            var result = await _context.Command
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }



        //public IEnumerable<Command> GetAppCommands()
        //{
        //    var commands = new List<Command>
        //    {
        //        new Command
        //        {
        //            Id = Guid.Parse("11111111-69cf-47d1-baa4-cc662e74788b"),
        //            HowTo = "Boil an egg",
        //            Line = "Boil water",
        //            Platfrom = "Kettle and pan"
        //        },
        //        new Command
        //        {
        //            Id = Guid.Parse("22222222-69cf-47d1-baa4-cc662e74788b"),
        //            HowTo = "Cut bread",
        //            Line = "Get a knife",
        //            Platfrom = "Knife and chopping board"
        //        },
        //        new Command
        //        {
        //            Id = Guid.Parse("33333333-69cf-47d1-baa4-cc662e74788b"),
        //            HowTo = "Make cup of tea",
        //            Line = "Teabag",
        //            Platfrom = "Kettle and cup"
        //        }
        //    };

        //    return commands;
        //}

        //public Command GetCommandById(int id)
        //{
        //    return new Command 
        //    { 
        //        Id = Guid.Parse("fb52eacb-69cf-47d1-baa4-cc662e74788b"),
        //        HowTo = "Boil an egg",
        //        Line = "Boil water",
        //        Platfrom = "Kettle and pan"
        //    };
        //}
    }
}
