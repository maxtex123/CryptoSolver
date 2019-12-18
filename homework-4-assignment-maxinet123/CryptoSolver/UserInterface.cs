/*
 * UserInterface.cs
 * Maxine Teixeira
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Numerics;

namespace CryptoSolver
{
    /// <summary>
    /// UserInterface represents the GUI
    /// </summary>
    public partial class UserInterface : Form
    {
        /// <summary>
        /// Object to reference to access other class
        /// </summary>
        SubstitutionCipher _cipher = new SubstitutionCipher();
        /// <summary>
        /// Creates the GUI
        /// </summary>
        public UserInterface()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Reads in the dictionary words to access
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void UserInterface_Load(object sender, EventArgs e)
        {
            if (!_cipher.ReadDictionary(@"data\dictionary.txt"))
            {
                MessageBox.Show("File cannot be opened.");
                System.Environment.Exit(1);
            }
        }
        /// <summary>
        /// When the button is pressed it checks if the characters are valid, otherwise if all the words are in the dictionary, otherwise encrypts the messaged entered.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxEncrypt_Click(object sender, EventArgs e)
        {
            string msg = uxMessage.Text.Trim();
            if (_cipher.ContainsInvalid(msg))
            {
                uxResult.Text = "Error: Invalid characters. Only lowercase letters and spaces allowed.";
            }
            else if (!_cipher.AllWords(msg))
            {
                uxResult.Text = "Error: Not all words are in the dictionary.";
            }
            else
            {
                uxResult.Text = _cipher.Encrypt(msg);
            }
            
        }
        /// <summary>
        /// Clears the result textbox. When the button is pressed it checks if all the characters are valid, otherwise checks if the msg can be decrypted, if it can it displays otherwise shows no colution can be found.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UxDecrypt_Click(object sender, EventArgs e)
        {
            string msg = uxMessage.Text.Trim();
            uxResult.Clear();
            if (_cipher.ContainsInvalid(msg))
            {
                uxResult.Text = "Error: Invalid characters. Only lowercase letters and spaces allowed.";
                return;
            }
            bool solved;
            string result = _cipher.Decrypt(msg, out solved);
            if (solved)
            {
                uxResult.Text = result;
            }
            else
            {
                uxResult.Text = "No solutions exists.";
            }
        }
    }
}
