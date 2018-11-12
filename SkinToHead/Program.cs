using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace SkinToHead
{
    class Program
    {
        static void Main(string[] args)
        {
            SkinToHeadFile(@"D:\git\MinecraftElf\MinecraftElf\PNG\MCSkin\zombie.png", 64);

            //登录正版成功，变更头像
            //http://skins.minecraft.net/MinecraftSkins/用户名.png

            
        }

        /// <summary>
        /// 从skin转换到头像
        /// </summary>
        /// <param name="fileName">skin文件的路径</param>
        /// <param name="targetSize">size必须是8的倍数 16 32 64 ...</param>
        static Bitmap SkinToHeadFile(string fileName, int targetSize)
        {
            if (targetSize % 8 != 0) //不等于8的倍数
            {
                throw new Exception("targetSize must be a multiple of 8.");
            }

            int size = targetSize / 8;

            Bitmap head = new Bitmap(targetSize, targetSize); //创建正方形画布
            Graphics g = Graphics.FromImage(head);  //从画布创建图形
            System.Drawing.Bitmap skin = new Bitmap(fileName); //载入skin图片

            //取得头部的8*8位置，并按照比例填充矩形
            for (int x = 8; x <= 15; x++)
            {
                for (int y = 8; y <= 15; y++)
                {
                    //对每个点作为矩形填充
                    g.FillRectangle(new SolidBrush(skin.GetPixel(x, y)), new Rectangle(0 + (x - 8) * size, (y - 8) * size, size, size));
                }
            }

            //存储
            g.Save(); 
            //head.Save("a.png");
            return head;


        }
    }
}
