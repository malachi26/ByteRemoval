using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveBytesProject
{
    public class Class1
    {
        /// <summary>
        /// http://codereview.stackexchange.com/a/106132/18427
        /// My Version of the code
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static byte[] RemoveBytes(byte[] input, byte[] pattern)
        {
            if (pattern.Length == 0) return input;
            var result = new List<byte>();
            for (int i = 0; i < input.Length; i++)
            {
                var patternLeft = i < input.Length - pattern.Length;
                if (patternLeft && (!pattern.Where((t, j) => input[i + j] != t).Any()))
                {
                    i += pattern.Length - 1;
                }
                else
                {
                    result.Add(input[i]);
                }
            }
            return result.ToArray();
        }


        /// <summary>
        /// http://codereview.stackexchange.com/q/106118/18427
        /// Original Post
        /// </summary>
        /// <param name="input"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        public static Byte[] OPRemoveBytes(byte[] input, byte[] pattern)
        {
            if (pattern.Length == 0) return input;
            var result = new List<byte>();
            int i;
            for (i = 0; i <= input.Length - pattern.Length; i++)
            {
                var foundMatch = !pattern.Where((t, j) => input[i + j] != t).Any();
                if (foundMatch) i += pattern.Length - 1;
                else result.Add(input[i]);
            }
            for (; i < input.Length; i++)
            {
                result.Add(input[i]);
            }
            return result.ToArray();
        }


        /*
         some of Heslacher's code, 
         * some of this code is more than what I reviewed
         * so I don't know exactly how to match it with what I did and what the OP did
         * to measure what's faster or more efficient. For Now.
         */

        private static byte[] RemovePattern(byte[] input, byte[] pattern)
        {
            return RemovePattern(input, pattern, new bool[pattern.Length]);
        }

        private static byte[] RemovePattern(byte[] input, byte[] pattern, bool[] wild)
        {
            int patternLength = pattern.Length;
            var patternIndex = -1;

            while ((patternIndex = FindPattern(input, pattern, wild)) >= 0)
            {
                byte[] current = new byte[input.Length - 3];
                Buffer.BlockCopy(input, 0, current, 0, patternIndex);
                Buffer.BlockCopy(input, patternIndex + patternLength, current, patternIndex, input.Length - patternIndex - patternLength);
                input = current;
            }
            return input;
        }

        public static int FindPattern(byte[] body, byte[] pattern, bool[] wild, int start = 0)
        {
            var foundIndex = -1;

            if (body.Length <= 0
                || pattern.Length <= 0
                || start > body.Length - pattern.Length
                || pattern.Length > body.Length)
            { return foundIndex; }

            foreach (int patternStart in GetPatternStartings(body, pattern, wild, start))
            {
                if (IsPattern(body, pattern, wild, patternStart)) { return patternStart; }
            }

            return foundIndex;

        }  
    }
}
