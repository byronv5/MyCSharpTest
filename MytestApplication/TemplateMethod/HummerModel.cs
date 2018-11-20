namespace TemplateMethod
{
    /// <summary>
    /// 悍马汽车模型
    /// </summary>
    public abstract class HummerModel
    {
        protected HummerModel()
        {
            this.isAlarm = true;
        }

        public abstract void Start();
        public abstract void Stop();
        public abstract void Alarm();
        public abstract void EngineBoom();
        protected bool isAlarm { get; set; }
        /// <summary>
        /// 模板方法模式的关键：抽取子类公共部分由父类组织逻辑，子类只需要关注各部分实现
        /// </summary>
        public void Run()
        {
            Start();
            if (isAlarm)
                Alarm();
            EngineBoom();
            Stop();
        }
    }
}
