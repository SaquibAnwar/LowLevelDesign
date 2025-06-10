namespace LowLevelDesign.Easy.StackOverflow;

public class Answer : IVotable, ICommentable
{
    public int Id { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public Question Question { get; set; }
    public bool IsAccepted { get; set; }
    public DateTime CreationDate { get; set; }
    public readonly List<Comment> _comments;
    public readonly List<Vote> _votes;

    public Answer(User author, Question question, string content)
    {
        Id = (int)(DateTime.Now.Ticks % int.MinValue);
        Content = content;
        Author = author;
        Question = question;
        CreationDate = DateTime.Now;
        _comments = new List<Comment>();
        _votes = new List<Vote>();
        IsAccepted = false;
    }

    public void Vote(User user, int value)
    {
        if (value != 1 && value != -1)
        {
            throw new ArgumentException("Vote value must be either 1 or -1");
        }
        _votes.RemoveAll(v => v.User.Equals(user));
        _votes.Add(new Vote(user, value));
        Author.UpdateReputation(value * 10);
    }
    
    public int GetVoteCount()
    {
        return _votes.Sum(v => v.Value);
    }

    public void AddComment(Comment comment)
    {
        _comments.Add(comment);
    }

    public List<Comment> GetComments()
    {
        return new List<Comment>(_comments);
    }

    public void MarkAsAccepted()
    {
        if (IsAccepted)
        {
            throw new InvalidOperationException("This answer is already accepted");
        }
        IsAccepted = true;
        Author.UpdateReputation(15);
    }
}