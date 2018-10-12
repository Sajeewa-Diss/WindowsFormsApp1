using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace WindowsFormsApp1
{
    public class HelperClass
    {
        /// <summary>
        /// Parse RichTextBox text using existing font properties
        /// </summary>
        /// <param name="rtb1"></param>
        public static void ParseRichTextBox(System.Windows.Forms.RichTextBox rtb1)
        {
            ParseRichTextBox(rtb1, rtb1.Font.Name, rtb1.Font.Size);
        }

        /// <summary>
        /// Parse RichTextBox text using param font properties
        /// </summary>
        /// <param name="rtb1"></param>
        /// <param name="fontName"></param>
        /// <param name="fontSize"></param>
        public static void ParseRichTextBox(System.Windows.Forms.RichTextBox rtb1, string fontName, float fontSize)
        {
            rtb1.SelectionFont = new Font(fontName, fontSize, rtb1.SelectionFont.Style); //this setting is ignored - do we need to be within partial class?? 

            string[] lineArray = rtb1.Lines;
            rtb1.Text = String.Empty;
            rtb1.SuspendLayout();

            for (int i = 0; i <= lineArray.Length-1 ; i++)
            {
                SplitComments(lineArray[i], out string codeText, out string commentText);

                rtb1.SelectionFont = new Font(fontName, fontSize);
                rtb1.SelectionColor = Color.Blue;
                rtb1.AppendText(codeText);
                rtb1.SelectionColor = Color.DarkGreen;
                rtb1.AppendText(commentText);
                rtb1.AppendText("\n"); // add a new line (these have been stripped-out.
            }

            rtb1.ScrollToCaret();
            rtb1.ResumeLayout();
        }

        private static void SplitComments(string input, out string codeText, out string commentText) {

            int commentStart = GetCommentStart(input);
            if (commentStart == -1)
            {
                codeText = input;
                commentText = string.Empty;
            }
            else
            {
                codeText = input.Substring(0, commentStart);
                commentText = input.Substring(commentStart, input.Length - commentStart);
            }
        }

        // returns the start char of a comment tag'//' or returns -1 if no comment tag occurs
        private static int GetCommentStart(string input) 
        {
            int retval = -1;
            bool isSlash = false;

            if (input.Length != 0)
            {
                char[] charArray = input.ToCharArray();

                for (int i = 0; i < charArray.Length - 1; i++)
                {
                    if (charArray[i] == '/')
                    {
                        if (isSlash)       // true if previous char was '/'
                        {
                            retval = i-1;
                            break;
                        }
                        else
                            isSlash = true;
                    }
                    else
                        isSlash = false;
                }
            }
            return retval;
        }
    }
}
