using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Drawing;

namespace ViSpell
{
    /// <summary>
    /// Main core engine to check vietnamese spelling
    /// </summary>
    public class SpellCheckerEngine
    {
        
        private static object _syncRoot = new Object();
        private static volatile SpellCheckerEngine _instance;
        public static SpellCheckerEngine Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_syncRoot)
                    {
                        if (_instance == null)
                            _instance = new SpellCheckerEngine();
                    }
                }

                return _instance;
            }
        }
        /// <summary>
        /// Private constructor for Singleton
        /// </summary>
        private SpellCheckerEngine()
        { }

        /// <summary>
        /// Result with marked spelling error
        /// </summary>
        public string Result { get; set; }

        public List<string> ArrayToTrim { get; set; }
        public List<string> ArrayDoubting { get; set; }
        public SpellCheckerEngineWorkingDictionary DictionaryToWork { get; set; }


        public CheckingResult Run(string pSourceText)
        {
            if(string.IsNullOrEmpty(pSourceText))
            {
                return null;
            }

            string[] arrSingleWord = pSourceText.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

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
                    if (!DictionaryToWork.SingleWordDic.Contains(sSingleWord))
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
                    if (DictionaryToWork.DoubleWordDic.Contains(sDoubleWord) && !arrDoubleWordFail.Contains(sDoubleWord))
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
                    if (DictionaryToWork.TripleWordDic.Contains(sTripleWord) && !arrTripleWordFail.Contains(sTripleWord))
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
                pSourceText = Regex.Replace(pSourceText, Regex.Escape(s), Regex.Escape(WrapStrongWord(s)), RegexOptions.IgnoreCase);
                // sResult = sResult.Replace(s, MakeHTMLStrong(s));
            }
            foreach (string s in arrDoubleWordFail)
            {
                pSourceText = Regex.Replace(pSourceText, Regex.Escape(s), Regex.Escape(WrapStrongWord(s)), RegexOptions.IgnoreCase);
                //sResult = sResult.Replace(s, MakeHTMLStrong(s));
            }
            foreach (string s in arrSingleWordFail)
            {
                pSourceText = Regex.Replace(pSourceText, Regex.Escape(s), Regex.Escape(WrapStrongWord(s)), RegexOptions.IgnoreCase);
                //sResult = sResult.Replace(s, MakeHTMLStrong(s));
            }
            foreach (string s in ArrayDoubting)
            {
                pSourceText = Regex.Replace(pSourceText, Regex.Escape(s), Regex.Escape(WrapColorWord(s, Color.BlueViolet)), RegexOptions.IgnoreCase);
                //sResult = sResult.Replace(s, MakeHTMLColor(s, Color.BlueViolet));
            }


            return new CheckingResult {
                OutputTextWithMark = pSourceText
            };
        }

        /// <summary>
        /// to lower, strip html tag, remove mark (in ArrayToTrim dic) from string s
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        private string NormalizeWord(string s)
        {
            // remove tag
            s = Lib.HtmlRemoval.StripTagsCharArray(s.ToLower());

            // remove mark, space, ... in ignoremark
            foreach (string sMark in ArrayToTrim)
            {
                s = s.Replace(sMark, "");
            }
            return s;
        }


        private string WrapColorWord(string s, Color c)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            return "<span style='color:" + c.Name + ";'>" + s + "</span>";
        }

        private string WrapStrongWord(string s)
        {
            if (string.IsNullOrEmpty(s))
            {
                return s;
            }

            return "<strong>" + s + "</strong>";
        }

    }
}
