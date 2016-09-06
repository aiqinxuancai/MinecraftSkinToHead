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
        /// <param name="_image">skin文件的路径</param>
        /// <param name="_size">size必须是8的倍数 16 32 64 ...</param>
        static bool SkinToHeadFile(string _image, int _size)
        {
            if (_size % 8 != 0) //不等于8的倍数
            {
                return false;
            }

            int size = _size / 8;

            Bitmap head = new Bitmap(_size, _size); //创建正方形画布
            Graphics g = Graphics.FromImage(head);  //从画布创建图形
            System.Drawing.Bitmap skin = new Bitmap(_image); //载入skin图片

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
            head.Save("a.png");
            return true;


        }
    }
}
