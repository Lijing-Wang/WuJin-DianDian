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
        }

        internal void Append(string message)
        {
            ResultBox.AppendText(Environment.NewLine);
            ResultBox.AppendText(Environment.NewLine);
            ResultBox.AppendText(message);
        }
    }
}
