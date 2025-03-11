using 连点器.Models;

namespace 连点器.Lib
{
    internal class ClickTracks
    {
        internal List<ClickTrack> Tracks { get; set; } = [];

        internal void AddTrack(Point position)
        {
            var newClick = new ClickTrack
            {
                Position = position,
                Time = DateTime.Now,
            };

            Tracks.Add(newClick);
        }

        private void OrderTracks()
        {
            Tracks = Tracks.OrderBy(t => t.Time).ToList();
        }

        // remove last click at the end recording button
        private void RemoveLast()
        {
            Tracks.RemoveAt(Tracks.Count - 1);  
        }

        internal void PopulateWaitTime()
        {
            OrderTracks();
            RemoveLast();

            for (int i = 0; i < Tracks.Count - 1; i++)
            {
                var current = Tracks[i];
                var next = Tracks[i + 1];
                current.waitTimeBeforeNextClick = (int)(next.Time - current.Time).TotalMilliseconds;
            }
        }
        internal void ClearTracks()
        {
            Tracks.Clear();
        }

        internal string Print()
        {
            var result = "";
            foreach (var track in Tracks)
            {
                result += $"Clicked {track.Position.X} {track.Position.Y}, WaitTime: {track.waitTimeBeforeNextClick}. {Environment.NewLine}";
            }

            return result;
        }
    }
 }
