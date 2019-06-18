using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AITSurvey.Modal
{
    public class Option
    {
        public int oid { get; set; }
        public string option { get; set; }
        public int? nextQid { get; set; }
        public int qid { get; set; }
    }
}