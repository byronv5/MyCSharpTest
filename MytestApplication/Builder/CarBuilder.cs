using System.Collections.Generic;

namespace Builder
{
    public abstract class CarBuilder
    {
        public abstract void SetSequence(List<string> sequence);
        public abstract CarModel BuildCar();
    }
}
