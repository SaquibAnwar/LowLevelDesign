using System.Security.AccessControl;

namespace LowLevelDesign.Easy.StackOverflow;

public class User
{
    public int Id { get; }
    public string Username { get; }
    public string Email { get; }
    public int Reputation { get; private set; }
    private readonly List<Question> _questions;
    private readonly List<Answer> _answers;
    private readonly List<Comment> _comment;

    private const int QuestionReputation = 3;
    private const int AnswerReputation = 10;
    private const int CommentReputation = 2;

    public User(int id, string username, string email)
    {
        Id = id;
        Username = username;
        Email = email;
        _questions = new List<Question>();
        _answers = new List<Answer>();
        _comment = new List<Comment>();
    }

    public Question AskQuestion(string title, string content, List<string> tags)
    {
        var question = new Question(this, title, content, tags);
        _questions.Add(question);
        UpdateReputation(QuestionReputation);
        return question;
    }

    public Comment AddComment( string content, ICommentable commentable)
    {
        var comment = new Comment(this, content);
        _comment.Add(comment);
        commentable.AddComment(comment);
        UpdateReputation(CommentReputation);
        return comment;
    }

    public Answer AnswerQuestion(Question question, string content)
    {
        var answer = new Answer(this, question, content);
        _answers.Add(answer);
        question.AddAnswer(answer);
        UpdateReputation(AnswerReputation);
        return answer;
    }

    public void UpdateReputation(int value)
    {
        Reputation = System.Math.Max(Reputation + value, 0);
    }

    public List<Question> GetQuestions()
    {
        return _questions;
    }
}