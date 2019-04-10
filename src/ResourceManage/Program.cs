using System;
using System.IO;

namespace ResourceManage
{
    class Program
    {
        static void Main(string[] args)
        {
            if (Directory.Exists(RmPublish))
            {
                Directory.Delete(RmPublish, true);
            }
            Directory.CreateDirectory(RmPublish);
            var dirs = Directory.GetDirectories(RunPath);
            foreach (var item in dirs)
            {
                if (item.EndsWith("RmPublish"))
                    continue;
                MoveFile2RmPublish(item);
            }
        }
        #region Properties
        static string RunPath
        {
            get
            {
                return System.AppDomain.CurrentDomain.BaseDirectory;
            }
        }
        static string RmPublish
        {
            get
            {
                return RunPath + @"\RmPublish";
            }
        }
        static string RmConfig
        {
            get
            {
                return RunPath + @"\ResourceManage.config";
            }
        }
        #endregion
        private static void MoveFile2RmPublish(string dirPath)
        {
            DirectoryInfo dirInfo = new DirectoryInfo(dirPath);
            var files = Directory.GetFiles(dirPath);
            foreach (var item in files)
            {
                var fileName = GetFileName(RunPath, item);
                string filePath = string.Format("{0}\\{1}", RmPublish, fileName);
                File.Copy(item, filePath);
            }
            var dirs = Directory.GetDirectories(dirPath);
            foreach (var item in dirs)
            {
                MoveFile2RmPublish(item);
            }
        }
        private static string GetFileName(string basePath, string filePath)
        {
            FileInfo fileInfo = new FileInfo(filePath);
            string nameWithOutEx = fileInfo.Name.Replace(fileInfo.Extension, "");
            string tempFileName = fileInfo.Directory.ToString();
            tempFileName = tempFileName.Replace(basePath, "");
            tempFileName = tempFileName.Replace("\\\\", "\\");
            tempFileName = tempFileName.Replace("\\", "_");
            return string.Format("{0}_{1}{2}", nameWithOutEx, tempFileName, fileInfo.Extension);
        }
    }
}
