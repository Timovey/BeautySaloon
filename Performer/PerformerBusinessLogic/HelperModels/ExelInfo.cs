using PerformerBusinessLogic.ViewModels;
using System.Collections.Generic;


namespace PerformerBusinessLogic.HelperModels
{
    public class ExcelInfo
    {
        public string FileName { get; set; }
        public string Title { get; set; }
        public List<ReportDestributionProcedure> ComponentManufactures { get; set; }
    }
}
