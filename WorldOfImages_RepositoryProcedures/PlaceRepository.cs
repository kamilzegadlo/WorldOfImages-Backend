using Dapper;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;
using WorldOfImages_Model;
using WorldOfImagesAPI_Model.DomainEntities;
using WorldOfImagesAPI_Model.Repositories;
using WorldOfImagesAPI_Model.ValueObjects;

namespace WorldOfImages_RepositoryProcedures
{
    public class PlaceRepository : IPlaceRepository
    {
        private readonly IOptions<Configuration> configuration;

        public PlaceRepository(IOptions<Configuration> configuration)
        {
            this.configuration = configuration;
        }

        public Place GetPlace(Coordinates coordinates)
        {
            using (var connection = new SqlConnection(configuration.Value.ConnectionString))
            {
                //static cling - extension (static) method
                return connection.QuerySingleOrDefault<Place>("GetPlace @X, @Y"
                    , new { X=coordinates.x, Y=coordinates.y});
            }
        }

        public void AddPlace(Place place)
        {
        }

    }
}
