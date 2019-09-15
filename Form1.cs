using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RegexTester
{
    public partial class RegexTextForm : Form
    {
        public RegexTextForm()
        {
            InitializeComponent();
        }

        private void TestButton_MouseClick(object sender, MouseEventArgs e)
        {
            string sourceText = sourceTextBox.Text;
            string regexText = regexTextBox.Text;

            resultTextBox.Text = "";

            try
            {

                string input = sourceText;
                string pattern = regexText;

                int matchCount = 0;

                StringBuilder sb = new StringBuilder();

                foreach (Match match in Regex.Matches(input, pattern))
                {
                    sb.Append(String.Format("第{0}个匹配", matchCount));
                    sb.Append("\n");
                    sb.Append(match.Value);
                    sb.Append("\n");

                    for (int i = 0; i < match.Groups.Count; ++i)
                    {
                        sb.Append(String.Format("第{0}子集", i));
                        sb.Append("\n");
                        sb.Append(match.Groups[i].Value);
                        sb.Append("\n");
                    }
                }
                resultTextBox.Text = sb.ToString();
                int findIndex = sourceTextBox.Find(pattern);
                if (findIndex != -1)
                {
                    sourceTextBox.Focus();
                    sourceTextBox.Select(findIndex, 1);
                }
            }
            catch (Exception ex)
            {
                resultTextBox.Text = ex.ToString();
            }
        }
    }
}
