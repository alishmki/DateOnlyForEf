namespace DateOnlyForEf
{
    public class Blog
    {
        public int BlogId { get; set; }
        public DateOnly RegDate { get; set; }
        public TimeOnly Time { get; set; }
    }
}
