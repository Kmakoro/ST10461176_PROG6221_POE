using System;
using System.Drawing;
using System.IO;

namespace ST10461176_PROG6221_POE
{
    public class logo
    {
        public logo()
        {
            try
            {
                //get the app full location
                string full_location = AppDomain.CurrentDomain.BaseDirectory;
                //set new path to root directory of app
                string new_path = full_location.Replace("bin\\Debug\\", "");
                //set final path of the image
                string imagePath = Path.Combine(new_path, "cyber.jpg");

                Bitmap image = new Bitmap(imagePath);
                image = new Bitmap(image, new Size(100, 40));

                //2D representation of bitmap image
                //loop for rows
                for (int vertical = 0; vertical < image.Height; vertical++)
                {
                    //loop for coloumns
                    for (int horizontal = 0; horizontal < image.Width; horizontal++)
                    {
                        //set color scheme depending on color of bitmap image at specified index
                        Color pixelColor = image.GetPixel(horizontal, vertical);
                        int rgb = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;

                        //ascii characters
                        char ascii = rgb > 230 ? '.' : rgb > 150 ? '*' : rgb > 60 ? '`' : '@';
                        switch (ascii)
                        {
                            case '@':
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(ascii);
                                break;
                            case '`':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(ascii);
                                break;
                            case '*':
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(ascii);
                                break;
                            case '.':
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write(ascii);
                                break;
                        }


                    }
                    //new line
                    Console.WriteLine();
                }
                PrintFancyCoCo();
                ChatBot.botResponse("Welcome to CoCo your AI-powered cybersecurity assistant");

            }
            catch (Exception ex)
            {
                //Display appropriate error message
                Console.WriteLine(ex.Message);
            }

        }
        static void PrintFancyCoCo()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(@"   _____       _____");
            Console.WriteLine(@"  / ____|     / ____|");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(@" | |     ___ | |     ___ ");
            Console.WriteLine(@" | |    / _ \|      / _ \");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            Console.WriteLine(@" | |___| (_) | |___| (_) |");
            Console.WriteLine(@"  \_____\___/ \_____\___/ ");
            Console.ResetColor();
            Console.WriteLine();
        }
    }
}