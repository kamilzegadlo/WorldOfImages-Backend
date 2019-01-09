using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WorldOfImagesAPI_Model.DomainEntities;
using WorldOfImagesAPI_Model.Repositories;
using WorldOfImagesAPI_Model.ValueObjects;

namespace WorldOfImages_RepositoryProcedures
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly IConfiguration configuration;

        public PlaceRepository(IConfiguration config)
        {
            configuration = config;
        }

        public Place GetPlace(Coordinates coordinates)
        {
            using (var connection = new SqlConnection(configuration.GetConnectionString("DefaultConnection")))
            {
                //static cling - extension (static) method
                return connection.QuerySingleOrDefault<Place>("GetPlace @X, @Y"
                    , new { X = coordinates.x, Y = coordinates.y });
            }
        }

        public void AddPlace(Place place)
        {
        }

    }
}
