using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
// using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ViSpell
{
    public partial class FormMain : Form
    {
        protected string sSingleWordDic = string.Empty;
        protected string sDoubleWordDic = string.Empty;
        protected string sTripleWordDic = string.Empty;
        
        protected string sDoubtWordDic = string.Empty;
        
        protected string sIgnoreMarkDic = string.Empty;
        
        List<string> arrToTrim = new List<string>();
        List<string> arrDoubting = new List<string>();

        public FormMain()
        {
            InitApp();
        }

        private void InitApp()
        {
            InitializeComponent();

            string sDoubleWordOKDic = File.ReadAllText("ok.double.dic", Encoding.UTF8);
            
            InitDictionary();
            InitWorkingParameter();

            // init browser result display
            string sURL = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"/html/source.htm";
            browserSource.Navigate(sURL);
            sURL = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"/html/result.htm";
            browserResult.Navigate(sURL);            
        }

        private void InitWorkingParameter()
        {
            // TODO:
            pln("Init Working param OK");
        }

        private void InitDictionary()
        {
            try
            {
                sSingleWordDic = File.ReadAllText("ok.single.dic", Encoding.UTF8);
                pln("Init SingleWord Dic OK");
            }
            catch (Exception ex)
            {
                pln("Init SingleWord Dic Failed");
            }
            try
            {
                sDoubleWordDic = File.ReadAllText("wrong.double.dic", Encoding.UTF8);
                pln("Init wrong DoubleWord Dic OK");
            }
            catch (Exception ex)
            {
                pln("Init wrong DoubleWord Dic Failed");
            }
            try
            {
                sTripleWordDic = File.ReadAllText("wrong.triple.dic", Encoding.UTF8);
                pln("Init wrong TripleWord Dic OK");
            }
            catch (Exception ex)
            {
                pln("Init wrong TripleWord Dic Failed");
            }
            try
            {
                sDoubtWordDic = File.ReadAllText("grey.doubt.dic", Encoding.UTF8);
                arrDoubting.AddRange(sDoubtWordDic.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries));
                pln("Init doubting Dic OK");
            }
            catch (Exception ex)
            {
                pln("Init doubting Dic Failed");
            }
            try
            {
                sIgnoreMarkDic = File.ReadAllText("ignoremark.dic", Encoding.UTF8);
                arrToTrim.AddRange(sIgnoreMarkDic.Split(new string[] { "\r\n", "\n", "\r" }, StringSplitOptions.RemoveEmptyEntries));
                pln("Init ignore mark Dic OK");
            }
            catch (Exception ex)
            {
                pln("Init sIgnoreMarkDic Failed");
            }
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            string sResult = browserSource.Document.GetElementById("sourcetext").InnerHtml;

            string[] arrSingleWord = sResult.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            
            string sSingleWord = string.Empty;
            string sDoubleWord = string.Empty;
            string sTripleWord = string.Empty;

            List<string> arrSingleWordFail = new List<string>();
            List<string> arrDoubleWordFail = new List<string>();
            List<string> arrTripleWordFail = new List<string>();
            
            for (int i = 0; i < arrSingleWord.Length; i++)
            {
                sSingleWord = NormalizeWord(arrSingleWord[i]);
                if (!arrSingleWordFail.Contains(sSingleWord))
                {
                    if(!sSingleWordDic.Contains(sSingleWord))
                    {
                        arrSingleWordFail.Add(sSingleWord);
                    }
                        // TODO: support more uppercase unicode letter of VNese
                    else if (Regex.IsMatch(arrSingleWord[i], "[A-Z]{2}"))
                    {
                        arrSingleWordFail.Add(arrSingleWord[i]);
                    }
                }

                if (i < arrSingleWord.Length - 1)
                {
                    sDoubleWord = sSingleWord + " " + NormalizeWord(arrSingleWord[i + 1]);
                    if (sDoubleWordDic.Contains(sDoubleWord) && !arrDoubleWordFail.Contains(sDoubleWord))
                    {
                        arrDoubleWordFail.Add(sDoubleWord);
                    }
                }
                else
                {
                    sDoubleWord = string.Empty; 
                }

                if (i < arrSingleWord.Length - 2)
                {
                    sTripleWord = sDoubleWord + " " + NormalizeWord(arrSingleWord[i + 2]);
                    if (sTripleWordDic.Contains(sTripleWord) && !arrTripleWordFail.Contains(sTripleWord))
                    {
                        arrTripleWordFail.Add(sTripleWord);
                    }
                }
                else
                {
                    sTripleWord = string.Empty;
                }
            }

            foreach (string s in arrTripleWordFail)
            {
                sResult = Regex.Replace(sResult, Regex.Escape(s), Regex.Escape(MakeHTMLStrong(s)), RegexOptions.IgnoreCase);
                // sResult = sResult.Replace(s, MakeHTMLStrong(s));
            }
            foreach (string s in arrDoubleWordFail)
            {
                sResult = Regex.Replace(sResult, Regex.Escape(s), Regex.Escape(MakeHTMLStrong(s)), RegexOptions.IgnoreCase);
                //sResult = sResult.Replace(s, MakeHTMLStrong(s));
            }
            foreach (string s in arrSingleWordFail)
            {
                sResult = Regex.Replace(sResult, Regex.Escape(s), Regex.Escape(MakeHTMLStrong(s)), RegexOptions.IgnoreCase);
                //sResult = sResult.Replace(s, MakeHTMLStrong(s));
            }
            foreach (string s in arrDoubting)
            {
                sResult = Regex.Replace(sResult, Regex.Escape(s), Regex.Escape(MakeHTMLColor(s, Color.BlueViolet)), RegexOptions.IgnoreCase);                
                //sResult = sResult.Replace(s, MakeHTMLColor(s, Color.BlueViolet));
            }            

            browserResult.Document.GetElementById("result").InnerHtml = sResult;
            pln(sResult);
        }


        private void p(string s)
        {
            txtConsole.Text = s + txtConsole.Text;
        }
        private void pln(string s)
        {
            p(s + Environment.NewLine);
        }


        

        private string NormalizeWord(string s)
        {
            // remove tag
            s = Lib.HtmlRemoval.StripTagsCharArray(s.ToLower());
            
            // remove mark, space, ... in ignoremark
            foreach (string sMark in arrToTrim)
            {
                s = s.Replace(sMark, "");
            }
            return s;
        }

        private string MakeHTMLStrong(string s)
        {
            return "<strong>" + s + "</strong>";
        }
        private string MakeHTMLColor(string s, Color c)
        {
            return "<span style='color:" +c.Name+ ";'>" + s + "</span>";
        }

        private void btnReloadApp_Click(object sender, EventArgs e)
        {
            InitApp();
        }

        
    }
}
