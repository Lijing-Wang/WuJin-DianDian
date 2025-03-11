
namespace 连点器.Lib
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

        internal void Log(string message)
        {
            ResultBox.Text = message;
        }
    }
}
