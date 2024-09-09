using System;
using System.IO;
using System.Threading.Tasks;

namespace COE.Survey.Web.Helpers
{
    public static class CustomFileUploader
    {
        private static readonly Random _rdm = new Random();
        private const int MinRandomNumber = 1000;
        private const int MaxRandomNumber = 9999;
        private const string baseDirectory = "c://";

        public static string UploadFile(string bytesString)
        {
            const string baseUrl = "https://survey.coe.com.sa/";

            try
            {
                var currentDateTime = DateTime.Now;
                var fileName = $"Survey_{currentDateTime.Day}_{currentDateTime.Month}_{GenerateRandomNo()}.jpg";
                var folderName = "UploadImage";
                var newUrl = $"{baseUrl}{fileName}";

                var file = ConvertBase64StringToByteArray(bytesString);
                var pathToSave = Path.Combine(Directory.GetDirectoryRoot(baseDirectory), folderName, fileName);

                // Ensure the directory exists before saving the file
                Directory.CreateDirectory(Path.GetDirectoryName(pathToSave));
                File.WriteAllBytes(pathToSave, file);

                return newUrl;
            }
            catch (Exception ex)
            {
                // Log the exception or take appropriate action
                Console.WriteLine($"Error: {ex.Message}");
                return string.Empty;
            }
        }

        private static int GenerateRandomNo()
        {
            return _rdm.Next(MinRandomNumber, MaxRandomNumber);
        }

        public static byte[] ConvertBase64StringToByteArray(string base64String)
        {
            if (string.IsNullOrEmpty(base64String))
            {
                return null;
            }

            int indexOfComma = base64String.IndexOf(',');

            if (indexOfComma == -1)
            {
                return null;
            }

            string base64Data = base64String.Substring(indexOfComma + 1);
            byte[] bytes = Convert.FromBase64String(base64Data);

            return bytes;
        }

        

    }

}
