using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorldOfImagesAPI.HttpRequestObjects
{
    public class AddPlaceRequest
    {
        [BindRequired]
        public string name { get; set; }
        [BindRequired]
        public int x { get; set; }
        [BindRequired]
        public int y { get; set; }

        public AddPlaceRequest()
        {

        }
    }
}
