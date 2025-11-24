namespace CAFileStream
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Example10();
            Console.ReadKey();
        }
        static void Example01()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown.txt";
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                Console.WriteLine($"Length: {fs.Length}");
                Console.WriteLine($"CanRead: {fs.CanRead}");
                Console.WriteLine($"CanWrite: {fs.CanWrite}");
                Console.WriteLine($"CanSeek: {fs.CanSeek}");
                Console.WriteLine($"CanTimeout: {fs.CanTimeout}");
                Console.WriteLine($"Position: {fs.Position}");
                fs.WriteByte(65);
                fs.WriteByte(66);
                fs.WriteByte(13);
                Console.WriteLine($"Position: {fs.Position}");
                for (byte i = 65; i < 123; i++)
                {
                    fs.WriteByte(i);
                }

            }
        }
        static void Example02()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown.txt";
            using (var fs = new FileStream(path, FileMode.Open, FileAccess.ReadWrite))
            {
                byte[] data = new byte[fs.Length];
                int numBytesToRead = (int)fs.Length;
                int numBytesRead = 0;
                while (numBytesToRead > 0)
                {
                    int n = fs.Read(data, numBytesRead, numBytesToRead);
                    if (n == 0)
                        break;

                    numBytesToRead -= n;
                    numBytesRead += n;
                }

                foreach (var b in data)
                    Console.WriteLine(b);


                var newPath = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown1.txt";
                using (var fsw = new FileStream(newPath, FileMode.OpenOrCreate, FileAccess.ReadWrite))
                {
                    fsw.Write(data, 0, data.Length);
                }
            }

        }
        static void Example03()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown2.txt";
            using (var fs = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite))
            {
                fs.Seek(20, SeekOrigin.Begin);
                fs.WriteByte(65);
                fs.Position = 0;
                for (int i = 0; i < fs.Length; i++)
                {
                    Console.WriteLine(fs.ReadByte());
                }
            }
        }

        static void Example04()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown3.txt";

            using (var sw = new StreamWriter(path))
            {
                sw.WriteLine("This");
                sw.WriteLine("is");
                sw.WriteLine("C#");
            }
        }
        static void Example05()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown3.txt";
            using (var sr = new StreamReader(path))
            {
                while (sr.Peek() > 0)
                {
                    Console.Write((char)sr.Read());
                }
            }
        }
        static void Example06()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown3.txt";
            using (var sr = new StreamReader(path))
            {
                string line;
                while((line = sr.ReadLine()) is not null)
                {
                    Console.WriteLine(line);
                }
            }
        }
        static void Example07()
        {
           string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown4.txt";

            string[] lines =
            {
                "C#",
                "is",
                "Amazing",
                "Language"
            };
            File.WriteAllLines(path, lines);

        }
        static void Example08() 
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown5.txt";
            string text = "C# is Amazing Language";
            File.WriteAllText(path, text);

        }
        static void Example09()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown5.txt";
            var result = File.ReadAllText(path);
            Console.WriteLine(result);
        }
        static void Example10()
        {
            string path = "C:\\Users\\ahmes\\OneDrive\\Desktop\\unnown4.txt";
            var result = File.ReadAllLines(path);
            foreach(var line in result)
                Console.WriteLine(line);
           
        }
    }
}
