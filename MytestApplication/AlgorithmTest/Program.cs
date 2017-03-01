using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace AlgorithmTest
{
    static class Program
    {
        static void Main(string[] args)
        {
            Stopwatch watch = new Stopwatch();//计时器

            List<int> list = new List<int>();
            #region 初始化数组
            //插入10个随机数到数组中
            Console.WriteLine("正在初始化数组...");
            watch.Start();
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(1);
                list.Add(new Random((int)DateTime.Now.Ticks).Next(10, 100));
            }
            watch.Stop();
            Console.WriteLine("排序前的数组：" + string.Join(",", list.Take(10).ToList()) + "构造耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion


            #region 交换排序
            #region 冒泡排序
            var temp1 = list.ToList();
            watch.Restart();
            var rst = AlgorithmLibrary.BubbleSort(temp1);
            watch.Stop();
            Console.WriteLine("冒泡排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion            
            #region 快排
            var temp2 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.QuickSort(temp2, 0, temp2.Count - 1);
            watch.Stop();
            Console.WriteLine("快速排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion
            #endregion

            #region 插入排序
            #region 直接插入排序
            var temp3 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.InsertSort(temp3);
            watch.Stop();
            Console.WriteLine("插入排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion
            #region 希尔排序
            var temp4 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.ShellSort(temp4);
            watch.Stop();
            Console.WriteLine("希尔排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion
            #endregion

            #region 选择排序
            #region 直接选择排序
            var temp5 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.SelectionSort(temp5);
            watch.Stop();
            Console.WriteLine("选择排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion
            #region 堆排序
            var temp6 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.HeapSort(temp6, temp6.Count);
            watch.Stop();
            Console.WriteLine("堆排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion
            #endregion

            #region 归并排序
            var temp7 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.MergeSort(temp7, new int[temp7.Count], 0, temp7.Count - 1);
            watch.Stop();
            Console.WriteLine("归并排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.WriteLine();
            #endregion
            Console.ReadLine();
        }
    }
}
