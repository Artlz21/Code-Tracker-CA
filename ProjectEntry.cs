namespace CodeTracker {
    public class ProjectEntry(int id, string name, string date, string duration)
    {
        public int Id { get; set; } = id;
        public string Name { get; set; } = name;
        public string Date { get; set; } = date;
        public string Duration { get; set;} = duration;
    }
}