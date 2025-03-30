namespace 连点器.Models
{
    internal class RecordedPlan
    {
        internal List<ClickTrack> Tracks { get; set; } = [];

        internal bool LikeHuman = true;
        internal bool LikeMachine = false;
        internal bool Replay = false;
        internal bool RandomReplay = false;

        internal TimeSpan RepeatDuration { get; set; }
        internal void NewTrack()
        {
            Tracks = [];
        }

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
        private void RemoveLastTrack()
        {
            if(Tracks.Count > 0)
                Tracks.RemoveAt(Tracks.Count - 1);  
        }

        internal void PopulateWaitTime()
        {
            OrderTracks();
            RemoveLastTrack();

            for (int i = 0; i < Tracks.Count; i++)
            {
                var current = Tracks[i];
                if (i + 1 < Tracks.Count)
                {
                    var next = Tracks[i + 1];
                    current.WaitTimeBeforeNextClick = (int)(next.Time - current.Time).TotalMilliseconds;
                } else
                {
                    current.WaitTimeBeforeNextClick = 1000;
                }

            }
        }

        internal void ClearTracks()
        {
            Tracks.Clear();
        }

        internal string PrintTracks()
        {
            var result = Environment.NewLine;
            var totalTime = 0;

            foreach (var track in Tracks)
            {
                result += $"Clicked {track.GetCorodinates()}, WaitTime: {track.WaitTimeBeforeNextClick}. {Environment.NewLine}";

                totalTime += track.WaitTimeBeforeNextClick;
            }

            return $"{result}Total time needed: {Math.Ceiling((decimal)totalTime / 1000)}s. ";
            ;
        }
    }
 }
