﻿using System;
using System.Collections.Generic;
using System.Text;

namespace EShop.Core.Dtos
{
    public class FileToDatabaseDto
    {
        public Guid Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] ImageData { get; set; }
        public Guid? SpaceshipId { get; set; }
    }
}
