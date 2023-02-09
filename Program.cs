using Newtonsoft.Json;

class Program
{
    static void Main(string[] args)
    {
        string fileToConvert =
            @"C:\Users\User\Documents\TestInput.pdf";
        string fileToWriteOutput =
            @"C:\Users\User\Documents\TestOutput.txt";

        SerializeFileContents(fileToConvert, fileToWriteOutput);
        
        ConvertContentsToBase64(fileToConvert);
    }

    private static void ConvertContentsToBase64(string fileToConvert)
    {
        byte[] fileBytes = File.ReadAllBytes(fileToConvert);

        string base64String = Convert.ToBase64String(fileBytes);

        Console.WriteLine("File converted to base64:");
        Console.WriteLine(base64String);
    }

    private static void SerializeFileContents(string fileToConvert, string fileToWriteOutput)
    {
        byte[] fileBytes = File.ReadAllBytes(fileToConvert);

        string json = JsonConvert.SerializeObject(fileBytes);

        Console.WriteLine("Json serialized byte array:");
        Console.WriteLine(json);

        File.WriteAllTextAsync(fileToWriteOutput, json);
    }
}
