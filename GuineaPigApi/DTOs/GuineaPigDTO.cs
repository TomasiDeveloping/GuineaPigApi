namespace GuineaPigApi.DTO_s
{
    public class GuineaPigDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Birth { get; set; }
        public string Gender { get; set; }
        public string Race { get; set; }
        public DateTime? LastHealthCheck { get; set; }
    }
}
