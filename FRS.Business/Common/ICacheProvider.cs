namespace FRS.Business.Common
{
    public interface ICacheProvider
    {
        object Get(string key);
        void Add(string key, object value, int minutes);
        void Remove(string key);
    }
}
