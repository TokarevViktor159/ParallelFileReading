using System.Diagnostics;

namespace ParallelFileReading
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            string[] files = {
                "D:\\file1.txt",
                "D:\\file2.txt",
                "D:\\file3.txt" };

            Stopwatch stopwatch = new Stopwatch();

            stopwatch.Start();
            await Parallel.ForEachAsync(files, async (file, cancellationToken) =>
            {
                int cnt = await CountSpacesInFileAsync(file);
                Console.WriteLine($"{file} содержит пробелов: {cnt}");
            });
            stopwatch.Stop();

            Console.WriteLine($"Время выполнения: {stopwatch.ElapsedMilliseconds} мс");
            Console.WriteLine("Нажмите любую клавишу...");
            Console.ReadKey();
        }


        static async Task<int> CountSpacesInFileAsync(string filePath)
        {
            using (var reader = new StreamReader(filePath))
            {
                string content = await reader.ReadToEndAsync();
                return content.Count(cnt => cnt == ' ');
            }
        }
    }
}
