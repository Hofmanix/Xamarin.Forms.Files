using System.IO;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Files.Droid;

[assembly: Dependency(typeof(FileImplementation))]
namespace Xamarin.Forms.Files.Droid
{
    public class FileImplementation: IFile
    {
        public string DataStorage => global::Android.App.Application.Context.FilesDir.AbsolutePath;
        public string ApplicationStorage => global::Android.App.Application.Context.DataDir.AbsolutePath;
        public string TempStorage => global::Android.App.Application.Context.CacheDir.AbsolutePath;
        public string CacheStorage => global::Android.App.Application.Context.CacheDir.AbsolutePath;
        public string ExternalStorage => Environment.ExternalStorageDirectory.AbsolutePath;
        public string SyncedStorage => "";

        public bool FileExists(string path)
        {
            return File.Exists(path);
        }

        public byte[] LoadBytes(string path)
        {
            return System.IO.File.ReadAllBytes(path);
        }

        public string LoadString(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public string SaveBytes(string path, byte[] data, SaveFileOptions options = null)
        {
            var directoryName = Directory.GetParent(path).FullName;
            Directory.CreateDirectory(directoryName);
            System.IO.File.WriteAllBytes(path, data);
            return path;
        }

        public string SaveString(string path, string data, SaveFileOptions options = null)
        {
            var directoryName = Directory.GetParent(path).FullName;
            Directory.CreateDirectory(directoryName);
            System.IO.File.WriteAllText(path, data);
            return path;
        }
    }
}