﻿using Albums.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Albums.Domain.Contracts
{
    public interface IPhotosService
    {
        Task<IEnumerable<Photo>> GetPhotosFilteredByTitleAsync(string title);
        Task<IEnumerable<Photo>> GetPhotosFilteredByAlbumAsync(int album);
    }
}
