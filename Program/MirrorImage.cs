﻿using System;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;

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

                            Console.WriteLine($"Зображення '{filePath}' успiшно оброблено i збережено як '{newFileName}'.");
                        }
                        else
                        {
                            Console.WriteLine($"Файл '{filePath}' не є графiчним зображенням.");
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"Помилка при обробцi файлу '{filePath}': {ex.Message}");
                    }
                }

                Console.WriteLine("Програма завершила роботу.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
            }
        }
    }
}