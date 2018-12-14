﻿using WorldOfImagesAPI.HttpRequestObjects;

namespace WorldOfImagesAPI.ValueObjects
{
    public class Coordinates
    {
        public int x { get; private set; }
        public int y { get; private set; }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public Coordinates(GetPlaceRequest getPlaceRequest)
        {
            x = getPlaceRequest.x;
            y = getPlaceRequest.y;
        }
    }
}
