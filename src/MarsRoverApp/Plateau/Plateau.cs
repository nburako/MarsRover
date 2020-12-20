namespace MarsRoverApp.PlateauSpace
{
    public class Plateau : IPlateau
    {
        public Size Size { get; set; }
        public void Determine(int width, int height)
        {
            Size = new Size(width, height);
        }
    }
}
