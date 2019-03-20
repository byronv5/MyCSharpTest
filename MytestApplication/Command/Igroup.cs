namespace Command
{
    public interface Igroup
    {
        /// <summary>
        /// 查询小组
        /// </summary>
        void Find();
        /// <summary>
        /// 加需求
        /// </summary>
        void Add();
        /// <summary>
        /// 删除需求
        /// </summary>
        void Delete();
        /// <summary>
        /// 改需求
        /// </summary>
        void Change();
        /// <summary>
        /// 变更计划
        /// </summary>
        void Plan();
    }
}
