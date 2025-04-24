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
	internal class Program
	{
		private static void Main(string[] args)
		{
			PcdTest();
		}

		// PCD 文件读取测试
		public static void PcdTest()
		{
			// 为当前文件夹下 BB.pcd文件，构造路径
			string PCDPath = Path.Combine(Directory.GetCurrentDirectory(), "BB.pcd");

			// 判断文件是否存在
			if (!File.Exists(PCDPath))
			{
				Console.WriteLine($"文件 {PCDPath} 不存在，请在运行目录下放置BB.pcd文件后，再次尝试");
				return;
			}

			using (var cloud = new PointCloudOfXYZRGBA())
			{
				using (var reader = new PCDReader())
					reader.Read(PCDPath, cloud);

				// 打印点云的点数
				Console.WriteLine(cloud.Count);

				// 输出第一个点的坐标
				Console.WriteLine(cloud.Points[0].X);
				Console.WriteLine(cloud.Points[0].Y);
				Console.WriteLine(cloud.Points[0].Z);

				using (var visualizer = new Visualizer("PCD window"))
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

		// Ply 文件读取测试
		//public static void PlyTest()
		//{
		//	// PLY 文件的路径
		//	string PLYPath = Path.Combine(Directory.GetCurrentDirectory(), "BB.ply");

		// // 检查 PLY 文件是否存在 if (!File.Exists(PLYPath)) { Console.WriteLine($"文件 {PLYPath} 不存在。");
		// return; }

		// // 使用点云对象 using (var cloud = new PointCloudOfXYZRGBA()) { // 使用 PLYReader 读取 PLY 文件 using
		// (var reader = new PLYReader()) { reader.Read(PLYPath, cloud); }

		// // 打印点云的点数 Console.WriteLine(cloud.Count);

		// // 输出第一个点的坐标 if (cloud.Count > 0) { Console.WriteLine($"第一个点的坐标: X={cloud.Points[0].X},
		// Y={cloud.Points[0].Y}, Z={cloud.Points[0].Z}"); } else { Console.WriteLine("点云中没有点。"); }

		// // 使用可视化器显示点云 using (var visualizer = new Visualizer("PLY 点云")) {
		// visualizer.AddPointCloud(cloud);
		// visualizer.SetPointCloudRenderingProperties(RenderingProperties.PointSize, 0.2);
		// visualizer.SetPointCloudRenderingProperties(RenderingProperties.Opacity, 0.95);
		// visualizer.SetBackgroundColor(255, 255, 255);

		// visualizer.Spin();

		//			while (!visualizer.WasStopped)
		//			{
		//				visualizer.SpinOnce(100);
		//			}
		//		}
		//	}
		//}

		// 假设 DataPath 方法用于获取文件的完整路径

	
	}
}