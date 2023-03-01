namespace Finanzauto.ManagementIndicators.API.Vms
{
    public class InsertGaviotaDataVM
    {
        public int RequestId { get; set; }
        public int PhaseId { get; set; }
        public string Phase { get; set; }
        public string Analyst { get; set; }
        public string StartDate { get; set; }
        public string StartHour { get; set; }
        public string EndDate { get; set; }
        public string EndHour { get; set; }
    }
}
