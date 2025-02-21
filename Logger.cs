using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 连点器
{
    internal class Logger
    {
        internal TextBox ResultBox { get; set; }

        public Logger(TextBox resultBox)
        {
            ResultBox = resultBox;
            ResultBox.Text = "Results:";
        }

        internal void Log(string message)
        {
            ResultBox.Text = message;
        }
    }
}
