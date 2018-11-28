using System;
using System.Collections.Generic;
using System.Text;

namespace Builder
{
    class BenzCarBuilder : CarBuilder
    {
        public BenzCar car = new BenzCar();
        public override CarModel BuildCar()
        {
            return car;
        }

        public override sealed void SetSequence(List<string> sequence)
        {
            this.car.SetSequence(sequence);
        }
    }
}
