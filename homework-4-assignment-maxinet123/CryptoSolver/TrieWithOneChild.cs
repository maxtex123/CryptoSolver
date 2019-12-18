/* TrieWithOneChild.cs
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
    /// Represents a trie with exactly one child
    /// </summary>
    public class TrieWithOneChild : ITrie
    {
        private bool _isWord;
        private ITrie _child;
        private char _childLabel;

        /// <summary>
        /// Constructs a trie containing the given string.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// </summary>
        /// <param name="s">The word to add</param>
        /// <param name="word">Whether this trie is a word</param>
        public TrieWithOneChild(string s, bool word)
        {
            if (s == "" || s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            _isWord = word;
            _childLabel = s[0];
            _child = new TrieWithNoChildren();
            _child = _child.Add(s.Substring(1));
        }

        /// <summary>
        /// Adds a word to this trie (no change is made if the word is already there)
        /// </summary>
        /// <param name="word">The word to add</param>
        /// <returns>The updated trie</returns>
        public ITrie Add(string s)
        {
            if (s == "")
            {
                _isWord = true;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else if (s[0] == _childLabel)
            {
                _child = _child.Add(s.Substring(1));
            }
            else
            {
                return new TrieWithManyChildren(s, _isWord, _childLabel, _child);
            }

            return this;
        }

        /// <summary>
        /// Returns whether a word is contained in this trie
        /// </summary>
        /// <param name="word">The word to find</param>
        /// <returns>Whether word is contained in this trie</returns>
        public bool Contains(string s)
        {
            if (s == "")
            {
                return _isWord;
            }
            else
            {
                if (s[0] == _childLabel)
                {
                    return _child.Contains(s.Substring(1));
                }
                else
                {
                    return false;
                }
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
                if (s[0] == _childLabel || s[0] == '?')
                {
                    return _child.WildcardSearch(s.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
