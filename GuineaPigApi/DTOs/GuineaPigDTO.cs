namespace GuineaPigApi.DTOs
{
    public class GuineaPigDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime Birth { get; set; }
        public string? Gender { get; set; }
        public string? Race { get; set; }
        public DateTime? LastHealthCheck { get; set; }
    }
}
