using EShop.Core.Domain;
using EShop.Core.Dtos;
using EShop.Core.ServiceInterface;
using EShop.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.IO;
using System.Threading.Tasks;

namespace EShop.ApplicationServices.Services
{
    public class SapceshipServices : ISpaceshipService
    {
        private readonly EShopDbContext _context;

        public SapceshipServices(
            EShopDbContext context
            )
        {
            _context = context;
        }

        public async Task<Spaceship> GetAsync(Guid id)
        {
            var result = await _context.Spaceship
                .FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<Spaceship> Add(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = Guid.NewGuid();
            spaceship.CrewSize = dto.CrewSize;
            spaceship.Armament = dto.Armament;
            spaceship.Role = dto.Role;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = dto.ModifiedAt;

            //todo sapceship file update method
            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }


            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public byte[] UploadFile(SpaceshipDto dto, Spaceship spaceship)
        {
            string fileName = null;

            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {
                    fileName = Guid.NewGuid().ToString() + "_" + photo.FileName;

                    using (var target = new MemoryStream())
                    {

                        FileToDatabase objfiles = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = fileName,
                            ImageData = target.ToArray(),
                            SpaceshipId = spaceship.Id
                        };

                        photo.CopyTo(target);
                        objfiles.ImageData = target.ToArray();

                        _context.FileToDatabase.Add(objfiles);
                    }
                }
            }
            return null;
        }

        //public static byte[] FileToDatabase(SpaceshipDto dto)
        //{
        //    foreach (var file in dto.Image)
        //    {
        //        FileToDatabaseDto img = new FileToDatabaseDto();

        //        MemoryStream ms = new MemoryStream();
        //        file.CopyTo(ms);
        //        img.ImageData = ms.ToArray();

        //        ms.Close();
        //        ms.Dispose();

        //        _context.FileToDatabase.Add(img);

        //    }

        //    return null;
        //}

    }
}
