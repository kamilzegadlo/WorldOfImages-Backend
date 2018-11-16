﻿namespace WorldOfImagesAPI.ValueObjects
{
    public class GetPlaceRequest
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public GetPlaceRequest(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
