using System.Runtime.InteropServices;

namespace SimpleSharpUtils
{
    public class Utilities
    {
        /*
        This function reverses a string. It sturns a string into 
        a character array (assigning it to a variable), then it reverses
        that array, and then it merges it back together, returning it. 
        */
        public static string Reverse(string strToReverse)
        {
            char[] arrayStrToReverse = strToReverse.ToCharArray();
            char[] result = arrayStrToReverse.Reverse().ToArray();
            return String.Join("",arrayStrToReverse);
        }
    }
}