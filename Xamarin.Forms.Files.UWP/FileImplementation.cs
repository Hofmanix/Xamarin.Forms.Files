using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.ApplicationModel;
using Windows.Storage;
using Xamarin.Forms;
using Xamarin.Forms.Files.UWP;

[assembly: Dependency(typeof(FileImplementation))]
namespace Xamarin.Forms.Files.UWP
{
    public class FileImplementation: IFile
    {
        public string ApplicationStorage => Package.Current.InstalledLocation.Path;
        public string DataStorage => ApplicationData.Current.LocalFolder.Path;
        public string TempStorage => ApplicationData.Current.LocalCacheFolder.Path;
        public string CacheStorage => ApplicationData.Current.LocalCacheFolder.Path;
        public string ExternalStorage => KnownFolders.DocumentsLibrary.Path;
        public string SyncedStorage => ApplicationData.Current.RoamingFolder.Path;

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
            Directory.CreateDirectory(Directory.GetParent(path).FullName);
            File.WriteAllBytes(path, data);
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
