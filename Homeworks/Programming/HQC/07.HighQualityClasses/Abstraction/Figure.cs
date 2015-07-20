namespace Abstraction
{
    public abstract class Figure
    {
        protected const string InvalidRectDimensionInputMessage = "{0} cannot be zero or negative";

        public abstract double CalcPerimeter();

        public abstract double CalcSurface();

        public override string ToString()
        {
            string result = string.Format("I am a {0}.", this.GetType().Name.ToLower());
            result += string.Format(" My perimeter is {0:f2}. My surface is {1:f2}.", this.CalcPerimeter(), this.CalcSurface());

            return result;
        }
    }
}
