
namespace Common.AbilityInterface
{
    /// <summary>
    /// 策略引用类
    /// </summary>
    public class Context
    {        
        readonly Strategy _strategy;

        /// <summary>
        /// 构造指向不同的策略类
        /// </summary>
        /// <param name="strategy"></param>
        public Context(Strategy strategy)
        {
            this._strategy = strategy;
        }

        /// <summary>
        /// 分发到不同的策略(调用不同的接口)
        /// </summary>
        /// <returns>json</returns>
        public string Excute()
        {
            return _strategy.GetResponse(_strategy);
        }
    }
}
