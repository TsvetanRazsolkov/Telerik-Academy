namespace _03.Proxy
{
    using System.Collections.Generic;

    public interface ITownBuilder
    {
        void BuildCapitol(IDictionary<string, int> resources);

        void BuildSeventhLevelUnit(IDictionary<string, int> resources);
    }
}
