namespace MVVMShop.Common.Hashers
{
    public interface IHasher
    {
        string Hash(string value, byte[] salt = null);
        bool Equals(string value, string newValue);
    }
}