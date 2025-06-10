namespace LowLevelDesign.Easy.StackOverflow;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; }

    public Tag(string name)
    {
        Id = (int)(DateTime.UtcNow.Ticks / int.MaxValue);
        Name = name;
    }
}