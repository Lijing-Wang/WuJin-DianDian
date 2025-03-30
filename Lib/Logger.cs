
namespace WuJinDianDian.Lib
{
    internal class Logger(TextBox resultBox)
    {
        internal void Append(string message)
        {
            resultBox.AppendText(Environment.NewLine);
            resultBox.AppendText(Environment.NewLine);
            resultBox.AppendText(message);
        }

        internal void Log(string message)
        {
            resultBox.Text = message;
        }
    }
}
