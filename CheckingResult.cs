using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ViSpell
{
    /// <summary>
    /// 
    /// </summary>
    public class CheckingResult
    {
        public string OutputTextWithMark { get; set; }

        public List<string> DoubtingList { get; set; }
        
        public List<string> ErrorList { get; set; }
    }
}
