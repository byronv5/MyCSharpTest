using System.Reflection;

namespace Factory.HumanCreate
{
    /// <summary>
    /// 抽象工厂
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class HumanFactory<T> : AbstractHumanFactory<T> where T : IHuman
    {
        public override T CreateHuman(string who)
        {
            return (T)Assembly.Load("Factory").CreateInstance($"Factory.HumanCreate.{who}");
        }
    }

    /// <summary>
    /// 简单工厂、静态工厂
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class SimpleHumanFactory<T> where T : IHuman
    {
        public static T CreateHuman(string who)
        {
            return (T)Assembly.Load("Factory").CreateInstance($"Factory.HumanCreate.{who}");
        }
    }
}
