using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 连点器
{
    internal class ClickTrack
    {
        internal Point Position { get; set; }

        internal DateTime Time { get; set; }

        internal int waitTimeBeforeNextClick { get; set; } 
        
    }
}
