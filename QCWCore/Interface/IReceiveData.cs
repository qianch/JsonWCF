namespace QCWCore.Interface
{
    public interface IReceiveData
    {
        string GetString(string name);
        string GetStringMust(string name);
        string GetStringNoException(string name);
    }
}