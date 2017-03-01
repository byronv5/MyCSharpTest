using System.Collections.Generic;

namespace AlgorithmTest
{
    /// <summary>
    /// 算法类
    /// </summary>
    internal static class AlgorithmLibrary
    {
        #region 交换排序
        #region 冒泡排序ASC
        /// <summary>
        /// 冒泡排序：从数组第1个元素开始向后比较，将较大的值往后交换，一次遍历比较后最大的值就跑到数组末尾。时间复杂度O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> BubbleSort(List<int> list)
        {
            bool isOrdered = true;//是否有序（假想是有序的）
            for (int i = list.Count - 1; i > 0; i--)//从尾部开始为最大值索引i（当然也可以从头开始，个人喜好）
            {
                if (i < list.Count - 1 && isOrdered)
                { break; }//冒泡后没有发生交换则说明有序，直接跳出循环（冒泡排序的优化版本）
                for (int j = 0; j < i; j++)
                {
                    if (list[j] > list[j + 1])
                    {
                        isOrdered = false;
                        int temp = list[j];
                        list[j] = list[j + 1];//从数组末尾往前填充，比如1-10的排序：...,9,10
                        list[j + 1] = temp;
                    }
                }
            }
            return list;
        }
        #endregion

        #region 快速排序ASC
        #region 查找分割点
        /// <summary>
        /// 获取分割点--分割点左边的元素小于右边的
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        private static int DivisionPoint(List<int> list, int left, int right)
        {
            int baseItem = list[left];//选取数组最左元素作为基准元素,baseItem查找期间永远不归位，until跳出循环
            while (left < right)
            {
                while (left < right && baseItem <= list[right])
                    right--;
                list[left] = list[right];//baseItem >= list[right]--↓

                while (left < right && baseItem >= list[left])
                    left++;
                list[right] = list[left];//baseItem <= list[right]--↑
            }
            list[left] = baseItem;//left=right
            return left;
        }
        #endregion
        #region 分治思想:递归
        /// <summary>
        /// 快排：时间复杂度O(N*logN)～O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <param name="left"></param>
        /// <param name="right"></param>
        /// <returns></returns>
        public static List<int> QuickSort(List<int> list, int left, int right)
        {
            if (left < right)
            {
                int divIndex = DivisionPoint(list, left, right);
                QuickSort(list, left, divIndex - 1);//对分割点左侧的数组递归切割
                QuickSort(list, divIndex + 1, right);//对分割点右侧的数组递归切割
            }
            return list;
        }
        #endregion
        #endregion
        #endregion

        #region 选择排序
        #region 直接选择排序
        /// <summary>
        /// 直接选择排序：从前往后寻找基准值（最小值），一次遍历后将最小值和基准值初始位置交换。时间复杂度O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> SelectionSort(List<int> list)
        {
            for (int i = 0; i < list.Count - 1; i++)
            {
                int baseNum = list[i]; //记录最小值
                int counter = i;//记录最小值的下标
                for (int j = i + 1; j < list.Count; j++) //从基准值右边向后遍历
                {
                    if (baseNum > list[j])
                    {
                        baseNum = list[j]; //基准值永远保存比它小的
                        counter = j; //记录最小值下标
                    }
                }
                //交换最小值和基准值
                int temp = list[i];
                list[i] = list[counter];
                list[counter] = temp;
            }
            return list;
        }
        #endregion

        #region 堆排序：重复构建大根堆，输出最大值
        /// <summary>
        /// 调整堆：按深度调整O(logN)，将parent节点调整到正确位置；如果数据结构本身就是被破坏的大根堆，则调用一次即可形成大根堆
        /// </summary>
        /// <param name="list">待排数组</param>
        /// <param name="parent">父节点</param>
        /// <param name="length">数组长度</param>
        /// <returns></returns>
        private static List<int> HeapAdjust(List<int> list, int parent, int length)
        {
            //temp保存当前父节点
            int temp = list[parent];

            //子节点，先从左孩子开始
            int child = 2 * parent + 1;

            while (child < length)
            {
                //如果parent有右孩子，则要判断左孩子是否小于右孩子
                if (child + 1 < length && list[child] < list[child + 1])
                    child++;//指向右孩子

                //父亲节点大于子节点，就不用做交换
                if (temp >= list[child])
                    break;

                //将较大子节点的值赋给父亲节点
                list[parent] = list[child];

                //然后将子节点做为父亲节点，已防止是否破坏根堆时重新构造
                parent = child;

                //找到该父亲节点较小的左孩子节点
                child = 2 * parent + 1;
            }
            //最后将temp值赋给较大的子节点，以形成两值交换
            list[parent] = temp;

            return list;
        }
        /// <summary>
        /// 堆排序(重复过程：构造大根堆输出最大值)。时间复杂度O(N*logN)
        /// </summary>
        /// <param name="list">待排数组</param>
        /// <param name="length">数组长度</param>
        /// <returns></returns>
        public static List<int> HeapSort(List<int> list, int length)
        {
            //构建大根堆--list.Count/2-1:就是堆中父节点的个数
            for (int i = list.Count / 2 - 1; i >= 0; i--)
            {
                HeapAdjust(list, i, list.Count);
            }

            //最后输出堆元素
            for (int i = list.Count - 1; i > 0; i--)
            {
                //堆顶与当前堆的末尾元素进行值对调：其实就是对数组从后往前进行填充
                int temp = list[0];
                list[0] = list[i];
                list[i] = temp;

                //因为两值交换，可能破坏根堆，调整一次即可重新成为大根堆
                HeapAdjust(list, 0, i);
            }
            return list;
        }
        #endregion
        #endregion

        #region 插入排序
        #region 直接插入排序ASC
        /// <summary>
        /// 插入排序：向有序数组中插入元素。时间复杂度O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> InsertSort(List<int> list)
        {
            //写法一：交换，类似冒泡
            //for (int i = 0; i < list.Count; i++)//初始数组（待排序）
            //{
            //    int unInsertItem = list[i];
            //    for (int j = i - 1; j >= 0; j--)//遍历已排好序的数组
            //    {
            //        if (list[j] > unInsertItem)
            //        {
            //            int temp = list[j];
            //            list[j] = list[j + 1];
            //            list[j + 1] = temp;
            //        }
            //    }
            //}
            //写法二：后移--类似打牌时整理排，较小的牌直接插入到合适位置，后面的牌依次后移
            for (int i = 1; i < list.Count; i++)//初始数组（待排序）
            {
                int j;
                int unInsertItem = list[i];
                //写法1：
                //for (j = i - 1; j >= 0; j--) //遍历已排好序的数组
                //{
                //    if (list[j] > unInsertItem)
                //        list[j + 1] = list[j];
                //    else
                //        break;
                //}

                //写法2：
                for (j = i - 1; j >= 0 && list[j] > unInsertItem; j--) //遍历已排好序的数组
                {
                    list[j + 1] = list[j];
                }
                list[j + 1] = unInsertItem;
            }
            return list;
        }
        #endregion

        #region 希尔排序ASC
        /// <summary>
        /// shell排序:根据增量将数组提炼后插入排序，伴随着增量递减重复提炼重复排序，直到增量为1。 
        /// 时间复杂度为：平均为O(N^3/2)；最坏： O(N^2)
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<int> ShellSort(List<int> list)
        {
            //增量，决定新数组元素位置差
            int delta = list.Count / 2;
            while (delta > 0)
            {
                #region 插入排序
                for (int i = delta; i < list.Count; i++)
                {
                    int j;
                    int temp = list[i];
                    for (j = i - delta; j >= 0 && temp < list[j]; j = j - delta)
                    {
                        list[j + delta] = list[j];
                    }
                    list[j + delta] = temp;
                }
                #endregion
                delta = delta / 2;
            }
            return list;
        }
        #endregion
        #endregion

        #region 归并排序O(n*logn)
        ///<summary>
        /// 数组的划分
        ///</summary>
        ///<param name="array">待排序数组</param>
        ///<param name="temparray">临时存放数组</param>
        ///<param name="left">序列段的开始位置，</param>
        ///<param name="right">序列段的结束位置</param>
        public static List<int> MergeSort(List<int> array, int[] temparray, int left, int right)
        {
            if (left < right)
            {
                //取分割位置
                int middle = (left + right) / 2;

                //递归划分数组左序列
                MergeSort(array, temparray, left, middle);

                //递归划分数组右序列
                MergeSort(array, temparray, middle + 1, right);

                //数组排序操作
                Merge(array, temparray, left, middle + 1, right);
            }
            return array;
        }

        /// <summary>
        /// 数组临时排序,合并后覆盖原数组
        /// </summary>
        ///<param name="array">待排序数组</param>
        ///<param name="temparray">临时数组</param>
        ///<param name="left">第一个区间段开始位置</param>
        ///<param name="middle">第二个区间的开始位置</param>
        ///<param name="right">第二个区间段结束位置</param>
        private static void Merge(List<int> array, int[] temparray, int left, int middle, int right)
        {
            //左指针尾
            int leftEnd = middle - 1;

            //右指针头
            int rightStart = middle;

            //临时数组的下标
            int tempIndex = left;

            //数组合并后的length
            int tempLength = right - left + 1;

            #region 从两个区间取出数据，从小到大依次放入临时数组
            //先循环两个区间段都没有结束的情况
            while ((left <= leftEnd) && (rightStart <= right))
            {
                if (array[left] < array[rightStart])
                    temparray[tempIndex++] = array[left++];
                else
                    temparray[tempIndex++] = array[rightStart++];
            }

            //判断左序列是否结束
            while (left <= leftEnd)
                temparray[tempIndex++] = array[left++];

            //判断右序列是否结束
            while (rightStart <= right)
                temparray[tempIndex++] = array[rightStart++];
            #endregion

            //从已排好序的临时数组中把数据依次赋给原数组
            for (int i = 0; i < tempLength; i++)
            {
                array[right] = temparray[right];
                right--;
            }
        }
        #endregion
    }
}
