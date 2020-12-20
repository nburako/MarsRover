namespace MarsRoverApp.PlateauSpace
{
    public interface IPlateau
    {
        Size Size { get; set; }
        void Determine(int width, int height);
    }
}
