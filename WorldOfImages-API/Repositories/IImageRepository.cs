using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WorldOfImagesAPI.DomainEntities;

namespace WorldOfImagesAPI.Repositories
{
    public interface IImageRepository
    {
        void AddImage(Image image);
    }
}
