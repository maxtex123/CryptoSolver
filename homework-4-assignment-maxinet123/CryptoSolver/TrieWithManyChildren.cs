/* TrieWithManyChildren.cs
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
    /// Represents a trie with more than one child
    /// </summary>
    public class TrieWithManyChildren : ITrie
    {
        /// <summary>
        /// Whether this trie is a word
        /// </summary>
        private bool _isWord = false;

        /// <summary>
        /// All children of this trie. 'a' = [0], 'b' = [1], etc.
        /// </summary>
        private ITrie[] _children = new ITrie[26];

        /// <summary>
        /// Constructs a trie containing the given string and having the given child at the given label.
        /// If s contains any characters other than lower-case English letters,
        /// throws an ArgumentException.
        /// If childLabel is not a lower-case English letter, throws an ArgumentException.
        /// </summary>
        /// <param name="s">The string to include.</param>
        /// <param name="hasEmpty">Indicates whether this trie should contain the empty string.</param>
        /// <param name="childLabel">The label of the child.</param>
        /// <param name="child">The child labeled childLabel.</param>
        public TrieWithManyChildren(string s, bool hasEmpty, char childLabel, ITrie child)
        {
            if (childLabel < 'a' || childLabel > 'z')
            {
                throw new ArgumentException();
            }
            _isWord = hasEmpty;
            _children[childLabel - 'a'] = child;
            Add(s);
        }

        /// <summary>
        /// Returns whether a word is contained in this trie
        /// </summary>
        /// <param name="s">The word to find</param>
        /// <returns>Whether word is contained in this trie</returns>
        public bool Contains(string s)
        {
            if (s.Length == 0)
            {
                return _isWord;
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                return false;
            }
            else
            {
                char letter = s[0];
                int index = letter - 'a';
                if (_children[index] == null)
                {
                    return false;
                }
                else return _children[index].Contains(s.Substring(1));
            }
        }

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
            }
            else if (s[0] < 'a' || s[0] > 'z')
            {
                throw new ArgumentException();
            }
            else
            {
                int loc = s[0] - 'a';
                if (_children[loc] == null)
                {
                    _children[loc] = new TrieWithNoChildren();
                }
                _children[loc] = _children[loc].Add(s.Substring(1));
            }

            return this;
        }

        /// <summary>
        /// Returns true if replaces '?' with a character
        /// </summary>
        /// <param name="s">The word to search</param>
        /// <returns>Whether '?' raplaces a character.</returns>
        public bool WildcardSearch(string s)
        {
            if (s.Length == 0)
            {
                return _isWord;
            }
            else if (s[0] == '?')
            {
                for (int i = 0; i < _children.Length; i++)
                {
                    if (_children[i] != null)
                    {
                        if (_children[i].WildcardSearch(s.Substring(1)))
                        {
                            return true;
                        }
                    }
                }
                return false; 
            }
            else
            {
                char letter = s[0];
                int index = letter - 'a';
                if (_children[index] != null)
                {
                    return _children[index].WildcardSearch(s.Substring(1));
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
