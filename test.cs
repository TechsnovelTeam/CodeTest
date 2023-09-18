/*
Questions:
1. Identify the potential issues related to resource management in the given code. How would you solve them?
2. Imagine this Logger class is used in a multithreaded environment. How would you ensure thread safety for the LogMessage method?
3. The destructor is responsible for closing the stream. Are there any issues or risks associated with this approach? If so, how would you handle resource cleanup more effectively?
*/


public class Logger
{
    private readonly FileStream _stream;

    public Logger(string path)
    {
        _stream = new FileStream(path, FileMode.Append);
    }

    public void LogMessage(string message)
    {
        byte[] data = Encoding.UTF8.GetBytes(DateTime.Now + ": " + message);
        _stream.Write(data, 0, data.Length);
    }

    // Destructor
    ~Logger()
    {
        _stream.Close();
    }
}
