# PclSharp
Point Cloud Library pinvoke binding for c#

The project has c# 7 features, and thus requires Visual Studio 2017 to build.
Nuget package: https://www.nuget.org/packages/PclSharp/


# 编译步骤

1、安装 PCL-1.8.1rc1-AllInOne-msvc2017-win64.exe这个版本 到C盘默认安装位置  C:\Program Files\PCL 1.8.1

2、设置环境变量  PCL_ROOT
![image](https://github.com/user-attachments/assets/0b38bcac-261a-4cf3-9833-527f69fc1c23)

3、修复错误 

```
1、 error C2039: “seekpos”: 不是“std::fpos<_Mbstatet>”的成员这样的错误
只要将在positioning.hpp 中报错的这句return pos.seekpos();注释掉即可。

2、注意 库是否与本地安装的一致
```

4、运行效果

![image](https://github.com/user-attachments/assets/73af44bc-e389-4509-bc94-cd095e1bb031)
