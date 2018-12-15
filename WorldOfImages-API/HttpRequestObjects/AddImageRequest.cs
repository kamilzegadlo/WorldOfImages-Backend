using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace WorldOfImagesAPI.HttpRequestObjects
{
    public class AddImageRequest
    {
        [BindRequired]
        public int x { get; set; }
        [BindRequired]
        public int y { get; set; }
        [BindRequired]
        public string image { get; set; }

        public AddImageRequest()
        {

        }
    }
}
