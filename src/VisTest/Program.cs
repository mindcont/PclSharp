using PclSharp;
using PclSharp.IO;
using PclSharp.Struct;
using PclSharp.Vis;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VisTest
{
    class Program
    {
        static void Main(string[] args)
        {
			using (var cloud = new PointCloudOfXYZRGBA())
            {
                using (var reader = new PCDReader())
                    reader.Read(DataPath("D:/BB.pcd"), cloud);


				// 打印点云的点数
				Console.WriteLine(cloud.Count);

				// 输出第一个点的坐标
				Console.WriteLine(cloud.Points[0].X);
				Console.WriteLine(cloud.Points[0].Y);
				Console.WriteLine(cloud.Points[0].Z);


				using (var visualizer = new Visualizer("a window"))
                {
		
					visualizer.AddPointCloud(cloud);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.PointSize, 0.2);
                    visualizer.SetPointCloudRenderingProperties(RenderingProperties.Opacity, 0.95);
                    visualizer.SetBackgroundColor(255, 255, 255);

					visualizer.Spin();

 
					while (!visualizer.WasStopped)
						visualizer.SpinOnce(100);
				}     
            }
        }

        public static string DataPath(string path)
            => Path.Combine("..", "..", "..", "..", "data", path);
    }
}
