using System.IO;

namespace Xamarin.Forms.Files
{
    public static class FilesManager
    {
        private static readonly IFile FileDependency = DependencyService.Get<IFile>();

        public static string ApplicationStorage => FileDependency.ApplicationStorage;
        public static string DataStorage => FileDependency.DataStorage;
        public static string TempStorage => FileDependency.TempStorage;
        public static string CacheStorage => FileDependency.CacheStorage;
        public static string ExternalStorage => FileDependency.ExternalStorage;
        public static string SyncedStorage => FileDependency.SyncedStorage;

        public static bool FileExists(string path)
        {
            return FileDependency.FileExists(path);
        }

        public static byte[] LoadBytes(string path)
        {
            return FileDependency.LoadBytes(path);
        }

        public static string LoadString(string path)
        {
            return FileDependency.LoadString(path);
        }

        public static string SaveBytes(string path, byte[] data, SaveFileOptions options = null)
        {   
            return FileDependency.SaveBytes(path, data, options);
        }

        public static string SaveString(string path, string data, SaveFileOptions options = null)
        {
            return FileDependency.SaveString(path, data, options);
        }
    }
}