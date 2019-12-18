/*
 * SubstitutionCipher.cs
 * Maxine Teixeira
 */
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoSolver
{
    public class SubstitutionCipher
    {
        /// <summary>
        /// Generates random number depending on the clock time.
        /// </summary>
        private Random _generator = new Random();
        /// <summary>
        /// Initializes tree to have no children
        /// </summary>
        private ITrie _words = new TrieWithNoChildren();
        /// <summary>
        /// Checks whether all words in msg are in the dictionary.
        /// </summary>
        /// <param name="msg">String being checked.</param>
        /// <returns>True if it is in it, otherwise false.</returns>
        public bool AllWords(string msg)
        {
            string[] pieces = msg.Split(new char []{ ' ' });
            foreach (string s in pieces)
            {
                if (!_words.Contains(s.Trim()))
                {
                    return false;
                }
            }
            return true;
        }
        /// <summary>
        /// Applies a random cipher to encrypt msg, and returns the resulting ciphertext.
        /// </summary>
        /// <param name="msg">String being encrypted.</param>
        /// <returns>The encrypted string.</returns>
        public string Encrypt(string msg)
        {
            StringBuilder sb = new StringBuilder();
            Dictionary<char, char> d = new Dictionary<char, char>();
            bool[] used = new bool[26];
            for (char i = 'a'; i <= 'z'; i++)
            {
                int temp = _generator.Next(used.Length);
                while (used[temp])
                {
                    temp = _generator.Next(used.Length);
                }
                used[temp] = true;
                char abc = (char)(temp + 'a');
                d.Add(i, abc);
            }
            foreach (char letter in msg)
            {
                if (letter == ' ')
                {
                    sb.Append(' ');
                }
                else
                {
                    sb.Append(d[letter]);
                }
            }
            return sb.ToString();
        }
        /// <summary>
        /// Reads the fileName input file of allowable words and adds them to trie.
        /// </summary>
        /// <param name="fileName">Name of file to be read.</param>
        /// <returns>Whether the file was successfully read.</returns>
        public bool ReadDictionary(string fileName)
        {
            try
            {
                using (StreamReader sr = new StreamReader(fileName))
                {
                    ITrie temp = new TrieWithNoChildren();
                    while (!sr.EndOfStream)
                    {
                        string word = sr.ReadLine().Trim().ToLower();
                        temp = temp.Add(word);
                    }
                    _words = temp;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        /// <summary>
        /// Checks whether the msg contains characters other than lower-case letters or spaces.
        /// </summary>
        /// <param name="msg">String being checked.</param>
        /// <returns>True if it is invalid, otherwise false.</returns>
        public bool ContainsInvalid(string msg)
        {
            for (int i = 0; i < msg.Length; i++){
                if ((msg[i] < 'a' || msg[i] > 'z') && msg[i] != ' ')
                {
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// Checks whether the words in plain have possible completions in the trie. 
        /// </summary>
        /// <param name="plain">StringBuilder being checked.</param>
        /// <returns>True if there are possible completions, otherwise false.</returns>
        public bool PossibleCompletion(StringBuilder[] plain)
        {
            foreach (StringBuilder word in plain)
            {
                if (!_words.WildcardSearch(word.ToString()))
                {
                    return false;
                }
            }
            return  true;
        }
        /// <summary>
        /// Checks whether the words in plain are a completed decryption.
        /// </summary>
        /// <param name="plain">String being checked.</param>
        /// <returns>True if it is solved, otherwise false.</returns>
        public bool Solved(StringBuilder[] plain)
        {

            foreach (StringBuilder word in plain)
            {
                if (!_words.Contains(word.ToString()))
                {
                    return false;
                }
                foreach (char c in word.ToString())
                {
                    if (c == '?')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        /// <summary>
        /// Size-2 array of the position of the next "?" character in plain
        /// </summary>
        /// <param name="plain">StringBuilder being checked.</param>
        /// <returns>Position of the next "?", otherwise null</returns>
        public int[] NextPos(StringBuilder[] plain)
        {
            int[] next = new int[2];
            for (int i = 0; i < plain.Length; i++)
            {
                    for (int j = 0; j < plain[i].Length; j++)
                    {
                        if (plain[i][j] == '?')
                        {
                            next[0] = i;
                            next[1] = j;
                            return next;
                        }
                    }
                
            }
            return null;
        }
        /// <summary>
        ///For all occurances of og in cipher, substitutes the corresponding position with replace in plain
        /// </summary>
        /// <param name="og">The original character.</param>
        /// <param name="replace">The character it is replacing the original with.</param>
        /// <param name="cipher">Array of strings</param>
        /// <param name="plain">Array of StringBuilder</param>
        private void Substitute(char og, char replace, string[] cipher, StringBuilder[] plain)
        {
            for (int i = 0; i < cipher.Length; i++)
            {
                for (int j = 0; j < cipher[i].Length; j++)
                {
                    if (cipher[i][j] == og)
                    {
                        plain[i][j] = replace;
                    }
                }
            }
        }
        /// <summary>
        /// Performs a recursive search to solve the cryptogram.
        /// </summary>
        /// <param name="cipher">Words of the encrypted message</param>
        /// <param name="partial">Current partial solution to the cipher</param>
        /// <param name="alphaUsed">keeps track of which lowercase letters have been used in the decryption.</param>
        /// <returns>If the decryption is valid on the message.</returns>
        public bool DecryptionSearch(string[] cipher, StringBuilder[] partial, bool[] alphaUsed)
        {

            if (Solved(partial))
            {
                return true;
            }
            else if (!PossibleCompletion(partial))
            {
                return false;
            }
            int[] loc = NextPos(partial);
            if (loc == null)
            {
                return false;
            }
            for (int i = 0; i < alphaUsed.Length; i++)
            {
                if (!alphaUsed[i])
                {
                    char c = (char)(i + 'a');
                    Substitute(cipher[loc[0]][loc[1]], c, cipher, partial);
                    alphaUsed[i] = true;
                    bool b = DecryptionSearch(cipher, partial, alphaUsed);
                    if (b)
                    {
                        return true;
                    }
                    else
                    {
                        alphaUsed[i] = false;
                        Substitute(cipher[loc[0]][loc[1]], '?', cipher, partial);
                    }
                }
            }
            return false;
        }
        /// <summary>
        /// Decrypts the message and returns the first possible solution.
        /// </summary>
        /// <param name="msg">Message being decrypted</param>
        /// <param name="solved">Whether or not the solution is found.</param>
        /// <returns>First possible solution.</returns>
        public string Decrypt(string msg, out bool solved)
        {
            string[] word = msg.Split(' ');
            StringBuilder[] sb = new StringBuilder[word.Length];
            bool[] alphaUsed = new bool[26];
            for (int i = 0; i < word.Length; i++)
            {
                sb[i] = new StringBuilder();
                foreach(char c in word[i])
                {
                    sb[i].Append('?');
                }
            }
            solved = DecryptionSearch(word, sb, alphaUsed);
            StringBuilder full = new StringBuilder();
            for (int i = 0; i < word.Length; i++)
            {
                full.Append(sb[i]);
                full.Append(" ");
            }
            return full.ToString();
        }

    }
}
