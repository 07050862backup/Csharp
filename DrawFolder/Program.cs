using System;
using System.IO;

namespace DrawFolder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = @"你的資料夾路徑";
            int maxLevel = 8;

            DirectoryInfo rootDir = new DirectoryInfo(path);
            Console.WriteLine(rootDir.Name);
            PrintDirectory(rootDir, "", maxLevel, 0);

            Console.WriteLine("按下 Enter 鍵繼續...");
            Console.ReadLine();
        }

        static void PrintDirectory(DirectoryInfo dir, string prefix, int maxLevel, int currentLevel)
        {
            // 如果當前層級超過最大層級，則直接返回
            if (currentLevel >= maxLevel)
            {
                return;
            }

            // 獲取目錄中的所有檔案和資料夾
            FileSystemInfo[] files = dir.GetFileSystemInfos();

            // 遍歷目錄中的所有檔案和資料夾
            for (int i = 0; i < files.Length; i++)
            {
                // 當前檔案或資料夾
                FileSystemInfo file = files[i];

                // 根據當前的位置判斷前綴
                string currentPrefix = GetPrefix(prefix, i == files.Length - 1);

                // 輸出當前檔案或資料夾的名字
                Console.WriteLine(currentPrefix + file.Name);

                // 如果當前檔案或資料夾是一個資料夾，則遞歸調用 PrintDirectory 方法繼續輸出該資料夾下的檔案和資料夾
                if ((file.Attributes & FileAttributes.Directory) == FileAttributes.Directory)
                {
                    PrintDirectory((DirectoryInfo)file, prefix + (i == files.Length - 1 ? " " : "|") + "\t", maxLevel, currentLevel + 1);
                }
            }
        }
        // 根據當前位置是否為最後一個，判斷前綴
        static string GetPrefix(string prefix, bool isLast)
        {
            return prefix + (isLast ? "└── " : "├── ");
        }
    }
}
