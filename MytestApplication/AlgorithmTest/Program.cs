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
            #region 初始化数组
            List<int> list = new List<int>();
            
            //插入10个随机数到数组中(如果测效率则设大点)
            Console.WriteLine("正在初始化数组...");
            watch.Start();
            for (int j = 0; j < 10; j++)
            {
                Thread.Sleep(1);
                list.Add(new Random((int)DateTime.Now.Ticks).Next(10, 100));
            }
            watch.Stop();
            Console.WriteLine("排序前的数组：" + string.Join(",", list.Take(10).ToList()) + "构造耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            goto heap;
            #region 七大基本排序算法
            #region 交换排序
            #region 冒泡排序
            bubble:
            var temp1 = list.ToList();
            watch.Restart();
            var rst = AlgorithmLibrary.BubbleSort(temp1);
            watch.Stop();
            Console.WriteLine("冒泡排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion            
            #region 快排
            quick:
            var temp2 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.QuickSort(temp2, 0, temp2.Count - 1);
            watch.Stop();
            Console.WriteLine("快速排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            #endregion

            #region 插入排序
            #region 直接插入排序
            insert:
            var temp3 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.InsertSort(temp3);
            watch.Stop();
            Console.WriteLine("插入排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            #region 希尔排序
            shell:
            var temp4 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.ShellSort(temp4);
            watch.Stop();
            Console.WriteLine("希尔排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            #endregion

            #region 选择排序
            #region 直接选择排序
            sel:
            var temp5 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.SelectionSort(temp5);
            watch.Stop();
            Console.WriteLine("选择排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            #region 堆排序
            heap:
            var temp6 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.HeapSort(temp6);
            watch.Stop();
            Console.WriteLine("堆排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            #endregion

            #region 归并排序
            merge:
            var temp7 = list.ToList();
            watch.Restart();
            rst = AlgorithmLibrary.MergeSort(temp7, new int[temp7.Count], 0, temp7.Count - 1);
            watch.Stop();
            Console.WriteLine("归并排序后:" + string.Join(",", rst.Take(10).ToList()) + "耗时:" + watch.ElapsedMilliseconds + "毫秒");
            Console.ReadLine();
            #endregion
            #endregion
            #region 单链表
            link:
            LinkList<int> link = new LinkList<int>();
            link.Add(8);
            link.Add(1);
            link.Add(6);
            link.Add(3);

            link.Reverse();
            #endregion
            Console.ReadLine();
        }
    }
    #region 链表节点
    /// <summary>
    /// 链表节点
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkNode<T>
    {
        public T Data { set; get; }//数据域,当前结点数据
        public LinkNode<T> Next { set; get; }//位置域,下一个结点地址

        public LinkNode(T item)
        {
            this.Data = item;
            this.Next = null;
        }

        public LinkNode()
        {
            this.Data = default(T);
            this.Next = null;
        }
    }
    #endregion
    #region 单链表实现
    /// <summary>
    /// 链表类：节点、链表操作方法
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class LinkList<T>
    {
        /// <summary>
        /// 链表节点
        /// </summary>
        public LinkNode<T> Head { set; get; } //单链表节点

        /// <summary>
        /// 初始化清空链表
        /// </summary>
        public LinkList()
        {
            Head = null;
        }

        /// <summary>
        /// 增加新元素到单链表末尾
        /// </summary>
        public void Add(T item)
        {
            LinkNode<T> foot = new LinkNode<T>(item);//实例化尾节点
            LinkNode<T> tempNode = new LinkNode<T>();
            if (Head == null)
            {
                Head = foot;
                return;
            }
            tempNode = Head;
            while (tempNode.Next != null)
            {
                tempNode = tempNode.Next;
            }
            tempNode.Next = foot;//注意：A和Head是引用类型，A指向Head的最后一个节点
        }
        /// <summary>
        /// 移除链表中的指定元素
        /// </summary>
        /// <param name="item"></param>
        public void Remove(T item)
        {
            LinkNode<T> tempNode = new LinkNode<T>(item);
            if (Head == null) return;
            if (Head == tempNode) Head = null;//只有一个节点且恰好就是待删除节点
            if (Head.Data.Equals(item)) Head = Head.Next;//删除第一个节点
            tempNode = Head;
            while (tempNode.Next != null)
            {
                if (tempNode.Next.Data.Equals(item))
                {
                    if (tempNode.Next.Next != null) tempNode.Next = tempNode.Next.Next;
                    else tempNode.Next = null;//说明移除的元素是尾元素
                }
                else tempNode = tempNode.Next;
            }
            return;
        }
        /// <summary>
        /// 查找节点（为空则不存在）
        /// </summary>
        /// <param name="item"></param>
        /// <returns></returns>
        public LinkNode<T> Find(T item)
        {
            LinkNode<T> tempNode = new LinkNode<T>();
            if (Head == null) return null;
            tempNode = Head;           
            while (tempNode.Next != null)
            {
                if (tempNode.Data.Equals(item)) return tempNode;
                else tempNode = tempNode.Next;               
            }
            return null;
        }
        /// <summary>
        /// 链表反转（头插法：节点依次插入到头结点前面）
        /// </summary>
        public void Reverse()
        {
            var tempHeadNode = new LinkNode<T>();
            if (Head.Next == null) return;//只有一个节点无需反转
            while(Head.Next != null)
            {
                tempHeadNode = new LinkNode<T>(Head.Next.Data);
                tempHeadNode.Next = Head;
                Head = tempHeadNode;
                Head.Next = Head.Next.Next;
            }
        }
    }
    #endregion
}
