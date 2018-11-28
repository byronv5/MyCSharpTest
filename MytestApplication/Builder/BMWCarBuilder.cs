using System.Collections.Generic;

namespace Builder
{
    public class BMWCarBuilder : CarBuilder
    {
        public BMWCar car = new BMWCar();
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
