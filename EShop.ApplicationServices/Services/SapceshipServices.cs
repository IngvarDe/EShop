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
                //.Include(y => y.Images)
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
            spaceship.CreatedAt = DateTime.Now;
            spaceship.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }

            await _context.Spaceship.AddAsync(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public async Task<Spaceship> Update(SpaceshipDto dto)
        {
            Spaceship spaceship = new Spaceship();
            FileToDatabase file = new FileToDatabase();

            spaceship.Id = dto.Id;
            spaceship.CrewSize = dto.CrewSize;
            spaceship.Armament = dto.Armament;
            spaceship.Role = dto.Role;
            spaceship.CreatedAt = dto.CreatedAt;
            spaceship.ModifiedAt = DateTime.Now;

            if (dto.Files != null)
            {
                file.ImageData = UploadFile(dto, spaceship);
            }

            _context.Spaceship.Update(spaceship);
            await _context.SaveChangesAsync();
            return spaceship;
        }

        public async Task<Spaceship> Delete(Guid id)
        {
            var spaceshipId = await _context.Spaceship
                .Include(x => x.Images)
                .FirstOrDefaultAsync(x => x.Id == id);

            _context.Spaceship.Remove(spaceshipId);
            await _context.SaveChangesAsync();

            return spaceshipId;
        }

        public byte[] UploadFile(SpaceshipDto dto, Spaceship spaceship)
        {

            if (dto.Files != null && dto.Files.Count > 0)
            {
                foreach (var photo in dto.Files)
                {

                    using (var target = new MemoryStream())
                    {

                        FileToDatabase objfiles = new FileToDatabase
                        {
                            Id = Guid.NewGuid(),
                            ImageTitle = photo.FileName,
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

        public async Task<FileToDatabase> RemoveImage(FileToDatabaseDto dto)
        {
            var imageId = await _context.FileToDatabase
                .FirstOrDefaultAsync(x => x.Id == dto.Id);

            _context.FileToDatabase.Remove(imageId);
            await _context.SaveChangesAsync();

            return imageId;
        }
    }
}
