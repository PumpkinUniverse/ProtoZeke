using ProtoZeke;

static class Program
{
    static void Main()
    {
        Console.WriteLine("Initating Program...");

        BinaricHandler binaricHandler = new BinaricHandler();

        MemoryHandler.CheckMemory();

        LanguageHandler languageHandler = new LanguageHandler();

        while (true)
        {
            string? Readline = Console.ReadLine();
            switch (Readline)
            {
                case "!!Shutdown":
                    Console.WriteLine("Shutting Down...");
                    Environment.Exit(0);
                    break;

                case "!!WipeMemory":
                    MemoryHandler.WipeMemory();
                    break;

                case "!!CheckMemory":
                    MemoryHandler.CheckMemory();
                    break;

                case "!!StoreData":
                    Console.WriteLine("Submit DataPath");
                    string? DataPath = Console.ReadLine();
                    MemoryHandler.StoreData(DataPath);
                    break;

                case "!!LoadDict":
                    languageHandler.LoadDict();
                    break;

                case "!!ReadMemory":
                    MemoryHandler.ReadMemory();
                    break;

                default:

                    break;
            }

        }
    }
}