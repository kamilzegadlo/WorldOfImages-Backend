namespace WorldOfImagesAPI.ValueObjects
{
    public class Coordinates
    {
        public readonly int x;
        public readonly int y;

        //Because it is used ad a parameter in API Controllers it has to have a parameterless constructor...
        //Hence, to still have a value object, x and y are changed to readonly
        public Coordinates()
        {

        }

        public Coordinates(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}
