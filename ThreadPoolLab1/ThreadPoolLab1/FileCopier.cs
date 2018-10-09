using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadPoolLab1
{
     public class FileCopier
    {
        public static IEnumerable<Tuple<FileInfo,string>> DirectoryCopyWithThreadPool(string sourceDirName, string destDirName, bool copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                var a = new Tuple<FileInfo, string>(file, temppath);

                yield return a;
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);

                    foreach(Tuple<FileInfo,string> res in DirectoryCopyWithThreadPool(subdir.FullName, temppath, copySubDirs))
                    {
                        yield return res;
                    }
                    
                }
            }
        }
    }
}
