/* TrieWithNoChildren.cs
 * Julie Thornton
 * Modified by: Maxine Teixeira
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSolver
{
    /// <summary>
    /// Represents a trie with no children
    /// </summary>
    public class TrieWithNoChildren : ITrie
    {
        /// <summary>
        /// Flagged if word is in trie
        /// </summary>
        private bool _isWord = false;

        /// <summary>
        /// Adds a word to this trie (no change is made if the word is already there)
        /// </summary>
        /// <param name="s">The word to add</param>
        /// <returns>The updated trie</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isWord = true;
                return this;
            }
            else
            {
                return new TrieWithOneChild(s, _isWord);
            }
        }

        /// <summary>
        /// Returns whether a word is contained in this trie
        /// </summary>
        /// <param name="s">The word to find</param>
        /// <returns>Whether word is contained in this trie</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isWord;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Returns true if replaces '?' with a character
        /// </summary>
        /// <param name="s">The word to search</param>
        /// <returns>Whether '?' raplaces a character.</returns>
        public bool WildcardSearch(string s)
        {
            if (s == "")
            {
                return _isWord;
            }
            else
            {
                return false;
            }
        }
    }
}
