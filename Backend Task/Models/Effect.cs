namespace Backend_Task.Models
{
    public class Effect
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public Effect(int id, string type)
        {
            Id = id;
            Type = type;
        }
    }
}
