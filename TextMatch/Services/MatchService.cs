using System;
using System.Collections.Generic;
using TextMatch.Models;

namespace TextMatch.Services
{
    public class MatchService : IMatchService
    {
        /// <summary>
        /// Returns the result of calling the KMP Algorithm on provided text and pattern to find all
        /// indices of matching pattern in the text
        /// </summary>
        /// <param name="textString"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public IEnumerable<int> AllIndicesOf(TextString textString)
        {
            if (string.IsNullOrEmpty(textString.SubText))
            {
                throw new ArgumentNullException(nameof(textString.SubText));
            }
            return Kmp(textString.Text.ToUpper(), textString.SubText.ToUpper());
        }

        /// <summary>
        /// Using KMP Algorithm: O(M,N) where M is the length of original text and N is the length of searching pattern
        /// </summary>
        /// <param name="text"></param>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private IEnumerable<int> Kmp(string text, string pattern)
        {
            var lps = LongestPrefixSuffix(pattern);
            int i = 0, j = 0;

            while (i < text.Length)
            {
                if (pattern[j] == text[i])
                {
                    j++;
                    i++;
                }
                if (j == pattern.Length)
                {
                    yield return i - j;
                    j = lps[j - 1];
                }

                else if (i < text.Length && pattern[j] != text[i])
                {
                    if (j != 0)
                    {
                        j = lps[j - 1];
                    }
                    else
                    {
                        i++;
                    }
                }
            }
        }

        /// <summary>
        /// Loop through LongestPrefixSuffix(lps) to find indices of character in provided pattern  
        /// </summary>
        /// <param name="pattern"></param>
        /// <returns></returns>
        private int[] LongestPrefixSuffix(string pattern)
        {
            var lps = new int[pattern.Length];
            int length = 0, i = 1;

            while (i < pattern.Length)
            {
                if (pattern[i] == pattern[length])
                {
                    length++;
                    lps[i] = length;
                    i++;
                }
                else
                {
                    if (length != 0)
                    {
                        length = lps[length - 1];
                    }
                    else
                    {
                        lps[i] = length;
                        i++;
                    }
                }
            }
            return lps;
        }
    }
}