using shortid;
using shortid.Configuration;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace Example.Infrastructure.Util.Helper
{
    public class ValidateCodeHelper
    {
        /// <summary>
        /// 隨機產生 n 長度不重複文字碼
        /// </summary>
        /// <returns></returns>
        public static string CreateUniqueId(int genLength)
        {
            GenerationOptions options = new GenerationOptions
            {
                UseSpecialCharacters = false,
                Length = genLength //長度
            };
            string uniqueId = ShortId.Generate(options);

            return uniqueId;
        }

        /// <summary>
        /// 生出驗證碼圖片
        /// </summary>
        /// <param name="validateCode"></param>
        /// <returns></returns>
        public static byte[] CreateValidateGraphic(string validateCode)
        {
            Bitmap image = new Bitmap((int)Math.Ceiling(validateCode.Length * 16.0), 27);
            Graphics g = Graphics.FromImage(image);
            try
            {
                //隨機產生
                Random random = new Random();
                //清空圖片背景色
                g.Clear(Color.White);
                //繪製圖片干擾線
                for(int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);
                    g.DrawLine(new Pen(Color.Silver), x1, x2, y1, y2);
                }
                Font font = new Font("Arial", 13, (FontStyle.Bold | FontStyle.Italic));
                LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(validateCode, font, brush, 3, 2);

                //繪製圖片前景干擾線
                for(int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);
                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }
                //繪製圖片邊框
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                //保存圖片資料
                MemoryStream stream = new MemoryStream();
                image.Save(stream, ImageFormat.Jpeg);

                //輸出
                return stream.ToArray();
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }

        /// <summary>
        /// 產生驗證碼圖片，傳回圖片的Base64字串
        /// </summary>
        /// <param name="code"></param>
        /// <param name="length">驗證碼長度</param>
        /// <returns></returns>
        public static string CreateBase64String(out string code, int length = 4)
        {
            code = CreateUniqueId(length);
            var bytes = CreateValidateGraphic(code);
            return "data:image/png;base64," + Convert.ToBase64String(bytes);
        }

    }
}
