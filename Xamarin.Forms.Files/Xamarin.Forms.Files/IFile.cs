namespace Xamarin.Forms.Files
{
    public interface IFile
    {
        string ApplicationStorage { get; }
        string DataStorage { get; }
        string TempStorage { get; }
        string CacheStorage { get; }
        string ExternalStorage { get; }
        string SyncedStorage { get; }

        bool FileExists(string path);
        byte[] LoadBytes(string path);
        string LoadString(string path);
        string SaveBytes(string path, byte[] data, SaveFileOptions options = null);
        string SaveString(string path, string data, SaveFileOptions options = null);
    }
}