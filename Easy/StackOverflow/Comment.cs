using System.Reflection.Metadata;

namespace LowLevelDesign.Easy.StackOverflow;

public class Comment
{
    public int Id { get; }
    public string Content { get; }
    public User Author { get; }
    public DateTime CreationDate { get; }

    public Comment(User author, string content)
    {
        Id = (int)(DateTime.Now.Ticks % int.MaxValue);
        Author = author;
        CreationDate = DateTime.Now;
        Content = content;
    }
}