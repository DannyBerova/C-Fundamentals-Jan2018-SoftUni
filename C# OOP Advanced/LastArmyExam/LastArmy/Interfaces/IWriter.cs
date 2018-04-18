public interface IWriter
{
    string StoredMessage { get; }

    void WriteLine(string output);

    void StoreMessage(string message);
}
