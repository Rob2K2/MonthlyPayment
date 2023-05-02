using System.Collections;
using System.Collections.Generic;

namespace Tests.LCDTests
{
    public class LCDTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] {new[] {"    _  _  _ ", "  || || || |", "  ||_||_||_|"}, "1000"};
            yield return new object[] {new[] {"    _ ", "  || |", "  ||_|"}, "10"};
            yield return new object[] {new[] {" _ ", "| |", "|_|"}, "0"};
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}