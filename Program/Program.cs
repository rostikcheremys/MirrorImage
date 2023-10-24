using System.IO;

namespace Program
{
    internal abstract class Program
    {
        public static void Main()
        {
            string folderPath = Directory.GetCurrentDirectory();
            
            MirrorImage image = new MirrorImage();
            
            image.MirrorReflection(folderPath);
        }
    }
}