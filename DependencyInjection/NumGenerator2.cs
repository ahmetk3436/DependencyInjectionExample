namespace DependencyInjection
{
    public class NumGenerator2 : INumGenerator2
    {
        private readonly INumGenerator numGenerator;

        public int RandomValue { get;  }
        public NumGenerator2(INumGenerator numGenerator)
        {
            this.numGenerator = numGenerator;
            RandomValue = new Random().Next(1000); 
        }
        public int GetNumGeneratorRandomValue()
        {
            return numGenerator.RandomValue;
        }
    }

    public interface INumGenerator2
    {
        public int RandomValue { get; }
        public int GetNumGeneratorRandomValue();
    }
}
