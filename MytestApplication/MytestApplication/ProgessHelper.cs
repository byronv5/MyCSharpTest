using System;
using System.Diagnostics;
using System.Linq;

namespace ProcessTest
{
    public class ProgessHelper
    {
        //主操作流程
        public static void MainProcess()
        {
            ProgessHelper helper = new ProgessHelper();

            var result = helper.GetProcess();

            helper.ShowProcess(result.Take(10).ToArray());

            Console.Write("\n请输入您要查看的进程ID：");

            helper.ShowProcessSingle(Console.ReadLine());

            Console.Write("\n请输入您要开启的进程名称：\t");

            var name = helper.StartProcess(Console.ReadLine());


            Console.WriteLine("程序已经开启，是否关闭？(y or n)");

            if (Console.ReadLine() == "y")
            {
                helper.StopProcess(name);

                Console.WriteLine("关闭成功。");
            }
        }

        #region 获取进程
        /// <summary>
        /// 获取进程
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        public Process[] GetProcess(string ip = "")
        {
            if (string.IsNullOrEmpty(ip))
                return Process.GetProcesses();

            return Process.GetProcesses(ip);
        }
        #endregion

        #region 查看进程
        /// <summary>
        /// 查看进程
        /// </summary>
        /// <param name="process"></param>
        public void ShowProcess(Process[] process)
        {
            Console.WriteLine("进程ID\t进程名称\t物理内存\t\t启动时间\t文件名");

            foreach (var p in process)
            {
                try
                {
                    Console.WriteLine("{0}\t{1}\t{2}M\t\t{3}\t{4}", p.Id, p.ProcessName.Trim(), p.WorkingSet64 / 1024.0f / 1024.0f,
                                                                         p.StartTime, p.MainModule.FileName);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
        #endregion

        #region 根据ID查看指定的进程
        /// <summary>
        /// 根据ID查看指定的进程
        /// </summary>
        /// <param name="processID"></param>
        public void ShowProcessSingle(string processID)
        {
            Process process = Process.GetProcessById(Convert.ToInt32(processID));

            Console.WriteLine("\n\n您要查看的进程详细信息如下：\n");

            try
            {
                var module = process.MainModule;

                Console.WriteLine("文件名:{0}\n版本{1}\n描叙{2}\n语言:{3}", module.FileName, module.FileVersionInfo.FileVersion,
                                                                           module.FileVersionInfo.FileDescription,
                                                                           module.FileVersionInfo.Language);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
        #endregion

        #region 进程开启
        /// <summary>
        /// 进程开启
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string StartProcess(string fileName)
        {
            Process process = new Process();

            process.StartInfo = new ProcessStartInfo(fileName);

            process.Start();

            return process.ProcessName;
        }
        #endregion

        #region 终止进程
        /// <summary>
        /// 终止进程
        /// </summary>
        /// <param name="name"></param>
        public void StopProcess(string name)
        {
            var process = Process.GetProcessesByName(name).FirstOrDefault();

            try
            {
                process.CloseMainWindow();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}
