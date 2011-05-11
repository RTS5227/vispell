using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;

namespace ViSpell
{
    /// <summary>
    /// Main UI of the program
    /// </summary>
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitApp();
        }
        
        private void btnReloadApp_Click(object sender, EventArgs e)
        {
            InitApp();
        }

        /// <summary>
        /// Do check spelling
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCheck_Click(object sender, EventArgs e)
        {
            string sourceText = browserSource.Document.GetElementById("sourcetext").InnerHtml;

            var ret = SpellCheckerEngine.Instance.Run(sourceText);
            if (ret != null)
            {
                browserResult.Document.GetElementById("result").InnerHtml = ret.OutputTextWithMark;
                pln(ret.OutputTextWithMark);
            }
            else 
            {
                pln("Không phân tích được");
            }           
        }



        /// <summary>
        /// Use interop browser to render result as HTML
        /// </summary>
        private void InitBrowserResultDisplay()
        {
            // init browser result display
            string sURL = Application.StartupPath + @"/html/source.htm";
            browserSource.Navigate(sURL);
            sURL = Application.StartupPath + @"/html/result.htm";
            browserResult.Navigate(sURL);
        }

        private void InitWorkingParameter()
        {
            // TODO:
            pln("Init Working param OK");
        }

        public SpellCheckerEngineWorkingDictionary InitDictionary()
        {
            string sSingleWordDic = string.Empty;
            string sDoubleWordDic = string.Empty;
            string sTripleWordDic = string.Empty;
            string sDoubtWordDic = string.Empty;
            string sIgnoreMarkDic = string.Empty;
            List<string> arrToTrim = new List<string>();
            List<string> arrDoubting = new List<string>();

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

            return new SpellCheckerEngineWorkingDictionary { 
                SingleWordDic = sSingleWordDic, 
                DoubleWordDic = sDoubleWordDic, 
                TripleWordDic = sTripleWordDic,
                DoubtWorkDic = sDoubtWordDic,
                IgnoreMarkDic = sIgnoreMarkDic
            };
        }

        private void p(string s)
        {
            txtConsole.Text = DateTime.Now.ToString("yyyy MM dd hh:mm:ss") + ": " + s + txtConsole.Text;
        }
        private void pln(string s)
        {
            p(s + Environment.NewLine);
        }

        private void InitApp()
        {
            InitializeComponent();

            string sDoubleWordOKDic = File.ReadAllText("ok.double.dic", Encoding.UTF8);

            var dic = InitDictionary();
            InitWorkingParameter();
            SpellCheckerEngine.Instance.DictionaryToWork = dic;

            InitBrowserResultDisplay();
        }
    }
}
