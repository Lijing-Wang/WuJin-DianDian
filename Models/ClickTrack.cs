
namespace 连点器.Models
{
    internal class ClickTrack
    {
        internal Point Position { get; set; }

        internal DateTime Time { get; set; }

        internal int waitTimeBeforeNextClick { get; set; }

        internal string GetCorodinates()
        {
            return Position.X + ", " + Position.Y;
        }

    }
}
