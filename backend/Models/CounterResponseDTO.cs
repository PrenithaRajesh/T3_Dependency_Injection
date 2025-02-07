namespace backend.Models{
    public class CounterResponseDTO{
        public int Scoped { get; set; }
        public int Transient { get; set; }
        public int Singleton { get; set; }
    }
}