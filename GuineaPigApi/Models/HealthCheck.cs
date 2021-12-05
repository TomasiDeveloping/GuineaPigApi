namespace GuineaPigApi.Models
{
    public class HealthCheck
    {
        public int Id { get; set; }
        public GuineaPig GuineaPig { get; set; }
        public int GuineaPigId { get; set; }
        public bool IsPawsCheck { get; set; }
        public string PawsComment { get; set; }
        public bool IsChinCheck { get; set; }
        public string ChinComment { get; set; }
        public bool IsMouthCheck { get; set; }
        public string MouthComment { get; set; }
        public bool IsNoseCheck { get; set; }
        public string NoseComment { get; set; }
        public bool IsTeethCheck { get; set; }
        public string TeethComment { get; set; }
        public bool IsEyesCheck { get; set; }
        public string EyesComment { get; set; }
        public bool IsEarsCheck { get; set; }
        public string EarsComment { get; set; }
        public bool IsFurCheck { get; set; }
        public string FurComment { get; set; }
        public decimal Weight { get; set; }
        public DateTime HealthCheckDate { get; set; }
    }
}
