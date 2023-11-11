namespace MySecondDll
{
    public class FileManager
    {
        public static void CopyFile(String sourcePath, String destinationPath)
        {
            File.Copy(sourcePath, destinationPath, true);
        }

        public static void CopyDirectory(String sourceDir, String destinationDir)
        {
            DirectoryCopy(sourceDir, destinationDir, true);
        }

        public static void DeleteFile(String filePath)
        {
            File.Delete(filePath);
        }

        public static void DeleteFiles(String[] fileNames)
        {
            foreach (var fileName in fileNames)
            {
                File.Delete(fileName);
            }
        }

        public static void DeleteFilesByMask(String directoryPath, String fileMask)
        {
            String[] files = Directory.GetFiles(directoryPath, fileMask);
            DeleteFiles(files);
        }

        public static void MoveFile(String sourcePath, String destinationPath)
        {
            File.Move(sourcePath, destinationPath);
        }

        private static void DirectoryCopy(String sourceDir, String destinationDir, Boolean copySubDirs)
        {
            DirectoryInfo dir = new DirectoryInfo(sourceDir);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!Directory.Exists(destinationDir))
            {
                Directory.CreateDirectory(destinationDir);
            }

            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                String tempPath = Path.Combine(destinationDir, file.Name);
                file.CopyTo(tempPath, true);
            }

            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    String tempPath = Path.Combine(destinationDir, subdir.Name);
                    DirectoryCopy(subdir.FullName, tempPath, copySubDirs);
                }
            }
        }

        public static void SearchWordInFile(String filePath, String searchWord, String reportFilePath)
        {
            try
            {
                string[] lines = File.ReadAllLines(filePath);
                var matchingLines = lines.Where(line => line.Contains(searchWord)).ToList();

                int wordCount = matchingLines.Sum(line => line.Split(new[] { ' ', '.', ',', ';', '!', '?' }, StringSplitOptions.RemoveEmptyEntries)
                                                            .Count(word => word.Equals(searchWord, StringComparison.OrdinalIgnoreCase)));

                File.WriteAllText(reportFilePath, $"{wordCount}");
            }
            catch (Exception ex)
            {
                File.WriteAllText(reportFilePath, $"Error: {ex.Message}");
            }
        }

        public static void SearchWordInDirectory(String directoryPath, String searchWord, String reportFilePath)
        {
            try
            {
                String[] files = Directory.GetFiles(directoryPath, "*", SearchOption.AllDirectories);
                var matchingFiles = files.Where(file => File.ReadAllText(file).Contains(searchWord)).ToList();

                File.WriteAllLines(reportFilePath, matchingFiles);
            }
            catch (Exception ex)
            {
                File.WriteAllText(reportFilePath, $"Error: {ex.Message}");
            }
        }
    }
}