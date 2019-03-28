using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoremIpsum
{
    public partial class Dashboard : MetroFramework.Forms.MetroForm
    {
        public Dashboard()
        {
            InitializeComponent();
        }

        private void metroButtonCount_Click(object sender, EventArgs e)
        {
            string[] words = metroTextBoxInput.Text.Split(' ');
            DataTable uniqueWords = new DataTable();
            uniqueWords.Columns.Add("word", typeof(string));
            uniqueWords.Columns.Add("count", typeof(long));
            char[] textArray = metroTextBoxInput.Text.ToCharArray();
            foreach (char word in textArray)
            {
                string stringWord = word.ToString().ToLower();
                string loWord = stringWord;
                if (loWord == " ")
                {
                    continue;
                }
                bool found = false;
                foreach (DataRow uniqueWord in uniqueWords.Rows)
                {
                    if (uniqueWord["word"].ToString() == loWord)
                    {
                        found = true;
                        int currentCount = Convert.ToInt32(uniqueWord["count"]);
                        uniqueWord["count"] = currentCount + 1;
                        break;
                    }
                }
                if (!found)
                {
                    DataRow newWord = uniqueWords.NewRow();
                    newWord["word"] = loWord;
                    newWord["count"] = 1;
                    uniqueWords.Rows.Add(newWord);
                }
            }

            metroGridOutput.DataSource = uniqueWords;
        }
    }
}
