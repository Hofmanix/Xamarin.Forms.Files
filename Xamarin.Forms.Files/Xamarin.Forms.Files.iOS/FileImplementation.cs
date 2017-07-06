using System;
using System.IO;
using Foundation;
using Xamarin.Forms;
using Xamarin.Forms.Files.iOS;

[assembly: Dependency(typeof(FileImplementation))]
namespace Xamarin.Forms.Files.iOS
{
    public class FileImplementation: IFile
    {
        public string DataStorage => Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public string ApplicationStorage => Path.Combine(DataStorage, "..");
        public string TempStorage => Path.Combine(DataStorage, "..", "tmp");
        public string CacheStorage => Path.Combine(DataStorage, "..", "Library", "Caches");
        public string ExternalStorage => "";
        public string SyncedStorage => DataStorage;

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
            System.IO.File.WriteAllBytes(path, data);
            if (options != null && options.SkipCloudBackup)
            {
                NSFileManager.SetSkipBackupAttribute(path, true);
            }
            return path;
        }

        public string SaveString(string path, string data, SaveFileOptions options = null)
        {
            System.IO.File.WriteAllText(path, data);
            if (options != null && options.SkipCloudBackup)
            {
                NSFileManager.SetSkipBackupAttribute(path, true);
            }
            return path;
        }
    }
}