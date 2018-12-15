using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorldOfImagesAPI.HttpRequestObjects
{
    public class GetPlaceRequest
    {
        [BindRequired]
        public int x { get; set; }
        [BindRequired]
        public int y { get; set; }

        public GetPlaceRequest()
        {

        }
    }
}
