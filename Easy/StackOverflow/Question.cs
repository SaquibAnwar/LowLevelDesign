using System.Diagnostics;

namespace LowLevelDesign.Easy.StackOverflow;

public class Question : IVotable, ICommentable
{
    public int Id { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public User Author { get; set; }
    public DateTime CreationDate { get; set; }
    public List<Tag> Tags { get; set; }
    private readonly List<Answer> _answers;
    private readonly List<Comment> _comments;
    private readonly List<Vote> _votes;

    public Question(User author, string title, string content, List<string> tags)
    {
        Id = (int)(DateTime.Now.Ticks % int.MaxValue);
        Title = title;
        Content = content;
        Author = author;
        CreationDate = DateTime.Now;
        _answers = new List<Answer>();
        _comments = new List<Comment>();
        _votes = new List<Vote>();
        Tags = tags.Select(tag => new Tag(tag)).ToList();
    }

    public void AddAnswer(Answer answer)
    {
        if(!_answers.Contains(answer))
            _answers.Add(answer);
    }

    public void Vote(User user, int value)
    {
        if (value != 1 && value != -1)
        {
            throw new ArgumentException("Votes value must be eiter 1 or -1");
        }
        _votes.RemoveAll(vote => vote.User == user);
        _votes.Add(new Vote(user, value));
        Author.UpdateReputation(value * 5);
    }

    public int GetVoteCount()
    {
        return _votes.Sum(v => v.Value);
    }

    public void AddComment(Comment comment)
    {
        if(!_comments.Contains(comment))
            _comments.Add(comment);
    }

    public List<Comment> GetComments()
    {
        return _comments;
    }
}