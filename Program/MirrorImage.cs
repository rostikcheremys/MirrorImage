using System;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace Program
{
    public class MirrorImage
    {
        private readonly Regex _regexExtForImage = new Regex(@"\.(bmp|gif|tiff?|jpe?g|png)$", RegexOptions.IgnoreCase);

        public void MirrorReflection(string folderPath)
        {
            try
            {
                string[] files = Directory.GetFiles(folderPath);

                foreach (string filePath in files)
                {
                    try
                    {
                        if (_regexExtForImage.IsMatch(Path.GetExtension(filePath)))
                        {
                            Bitmap image = new Bitmap(filePath);

                            image.RotateFlip(RotateFlipType.RotateNoneFlipX);

                            string fileName = Path.GetFileNameWithoutExtension(filePath);
                            string newFileName = $"{fileName}-mirrored.gif";
                            string newFilePath = Path.Combine(folderPath, newFileName);

                            image.Save(newFilePath, System.Drawing.Imaging.ImageFormat.Gif);

                            MessageBox.Show($"Зображення '{filePath}' успiшно оброблено i збережено як '{newFileName}'.");
                        }
                        else
                        {
                            MessageBox.Show($"Файл '{filePath}' не є графiчним зображенням.");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Помилка при обробцi файлу '{filePath}': {ex.Message}");
                    }
                }

                MessageBox.Show("Програма завершила роботу.");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Помилка: {ex.Message}");
            }
        }
    }
}
