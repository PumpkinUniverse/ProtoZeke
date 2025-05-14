
namespace ProtoZeke
{
    public static class MemoryHandler
    {

        public static void CheckMemory()
        {
            string currentFilePath = Directory.GetCurrentDirectory();

            if (Directory.Exists(currentFilePath + "\\Memory"))
            {
                Console.WriteLine("Memory Exists...");
            }
            else { Console.WriteLine("Cannot Find Memory"); Console.WriteLine(currentFilePath);
                Console.WriteLine("Creating new Memory Folder...");
                Directory.CreateDirectory(currentFilePath + "\\Memory");
            }
        }

        public static void StoreData(string input)
        {
            if (File.Exists(input))
            {
                string SavedMemory = Path.Combine(Directory.GetCurrentDirectory(), "Memory\\");
                Console.WriteLine("Assign New File Name");
                string FileName = Console.ReadLine();
                Console.WriteLine($"New File name: {FileName} \nTranferring Data to {SavedMemory}...");
                File.Copy(input, SavedMemory + FileName,true);
            }
            else
            {
                Console.WriteLine("Path Not Found!!! Check File Exists!! Remove Quotations!!");
                Console.WriteLine($"Path Used: {input}");
            }
        }

        public static string QueryData()
        {
            Console.WriteLine("Designate Data To Be Read");
            string input = Console.ReadLine();
            string SavedMemory = Path.Combine(Directory.GetCurrentDirectory(), "Memory\\");
            string path = (SavedMemory + $"\\{input}");
            return path;
        }

        public static void ReadMemory()
        {
            string SavedMemory = Path.Combine(Directory.GetCurrentDirectory(), "Memory\\");
            foreach (var f in Directory.GetFileSystemEntries(SavedMemory))
            {
                FileInfo fileInfo = new FileInfo(f);
                Console.WriteLine(Path.GetFileName(f) + " " + FormatFileSize(fileInfo.Length));
                
            }
        }


        public static void WipeMemory()
        {
            string SavedMemory = Directory.GetCurrentDirectory() + "\\Memory";

            foreach (var file in Directory.GetFiles(SavedMemory))
            {
                File.Delete(file);
                Console.WriteLine("Wiped Memory...");
            }
        }

        // Helper method to format file size to a human-readable string (KB, MB, GB)
        static string FormatFileSize(long sizeInBytes)
        {
            if (sizeInBytes < 1024)
                return sizeInBytes + " bytes";
            else if (sizeInBytes < 1048576)
                return (sizeInBytes / 1024) + " KB";
            else if (sizeInBytes < 1073741824)
                return (sizeInBytes / 1048576) + " MB";
            else
                return (sizeInBytes / 1073741824) + " GB";
        }
    }
}
