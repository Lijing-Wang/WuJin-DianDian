﻿
namespace WuJinDianDian.Models
{
    internal class ClickTrack
    {
        internal Point Position { get; set; }

        internal DateTime Time { get; set; }

        internal int WaitTimeBeforeNextClick { get; set; }

        internal string GetCorodinates()
        {
            return Position.X + ", " + Position.Y;
        }

    }
}
