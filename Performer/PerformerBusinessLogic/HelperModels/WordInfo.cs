using PerformerBusinessLogic.ViewModels;
using System.Collections.Generic;

namespace PerformerBusinessLogic.HelperModels
{
    class WordInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDestributionProcedure> Manufactures { get; set; }
    }

}
