using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Extensions
{
    public static class CharExtension
    {
        public static bool EqualsIgnoreCase(this char value, char compareValue)
        {
            return char.ToUpperInvariant(value).Equals(char.ToUpperInvariant(compareValue));
        }
    }
}
