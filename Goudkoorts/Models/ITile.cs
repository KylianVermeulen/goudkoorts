namespace Goudkoorts.Models
{
    public interface ITile
    {
        ITile PrevY { get; set; }
        ITile NextX { get; set; }
        ITile NextY { get; set; }
        ITile PrevX { get; set; }
        char ToChar();
    }
}