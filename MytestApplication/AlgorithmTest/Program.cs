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
            //插入20个随机数到数组中
            Console.WriteLine("正在初始化数组...");
            watch.Start();
            for (int j = 0; j < 20; j++)
            {
                Thread.Sleep(1);
                list.Add(new Random((int)DateTime.Now.Ticks).Next(10, 100));
            }
            watch.Stop();
            Console.WriteLine("构造数组耗时:" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            var temp = list.ToList();

            #region 交换排序
            #region 冒泡排序
            watch.Start();
            var rst = AlgorithmLibrary.BubbleSort(temp);
            watch.Stop();
            Console.WriteLine("冒泡排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("冒泡排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion            
            #region 快排
            watch.Restart();
            rst = AlgorithmLibrary.QuickSort(temp, 0, temp.Count - 1);
            watch.Stop();
            Console.WriteLine("快速排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("快速排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            #endregion
            
            #region 插入排序
            #region 直接插入排序
            temp = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.InsertSort(temp);
            watch.Stop();
            Console.WriteLine("插入排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("插入排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            #region 希尔排序
            temp = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.ShellSort(temp);
            watch.Stop();
            Console.WriteLine("希尔排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("希尔排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            #endregion

            #region 选择排序
            #region 直接选择排序
            temp = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.SelectionSort(temp);
            watch.Stop();
            Console.WriteLine("选择排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("选择排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            #region 堆排序
            temp = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.HeapSort(temp,temp.Count);
            watch.Stop();
            Console.WriteLine("堆排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("堆排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            #endregion

            #region 归并排序
            temp = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.MergeSort(temp, new int[temp.Count], 0, temp.Count - 1);
            watch.Stop();
            Console.WriteLine("归并排序后:" + string.Join(",", rst.Take(20).ToList()));
            Console.WriteLine("归并排序耗时：" + watch.ElapsedMilliseconds + "毫秒");
            #endregion
            Console.ReadLine();
        }
    }
}
