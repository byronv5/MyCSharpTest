using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    public abstract class CarModel
    {
        /// <summary>
        /// 方法执行顺序(不同模型有不同的逻辑)
        /// </summary>
        private List<string> sequence = new List<string>();
        public abstract void Start();
        public abstract void Stop();
        public abstract void Alarm();
        public abstract void EngineBoom();
        public void Run()
        {
            sequence.ForEach(_ =>
            {
                switch (_)
                {
                    //这么写还是感觉不舒服
                    case "Start":
                        this.Start();
                        break;
                    case "Stop":
                        this.Stop();
                        break;
                    case "Alarm":
                        this.Alarm();
                        break;
                    case "EngineBoom":
                        this.EngineBoom();
                        break;
                }
            });
        }
        public void SetSequence(List<string> sequence)
        {
            this.sequence = sequence;
        }
    }
}
