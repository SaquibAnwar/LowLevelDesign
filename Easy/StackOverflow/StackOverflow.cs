using System.Collections.Concurrent;

namespace LowLevelDesign.Easy.StackOverflow;

public class StackOverflow
{
    private readonly ConcurrentDictionary<int, User> _users;
    private readonly ConcurrentDictionary<int, Question> _questions;
    private readonly ConcurrentDictionary<int, Answer> _answers;
    private readonly ConcurrentDictionary<string, Tag> _tags;

    public StackOverflow()
    {
        _users = new ConcurrentDictionary<int, User>();
        _questions = new ConcurrentDictionary<int, Question>();
        _answers = new ConcurrentDictionary<int, Answer>();
        _tags = new ConcurrentDictionary<string, Tag>();
    }

    public User CreateUser(string userName, string email)
    {
        int id = _users.Count + 1;
        var user = new User(id, userName, email);
        _users.TryAdd(id, user);
        return user;
    }

    public Question AskQuestion(User user, string title, string content, List<string> tags)
    {
        var question = user.AskQuestion(title, content, tags);
        _questions.TryAdd(question.Id, question);
        foreach (var tag in question.Tags)
        {
            _tags.TryAdd(tag.Name, tag);
        }

        return question;
    }

    public Answer AddAnswer(User user, Question question, string content)
    {
        var answer = user.AnswerQuestion(question, content);
        _answers.TryAdd(answer.Id, answer);
        return answer;
    }

    public Comment AddComment(User user, string content, ICommentable commentable)
    {
        return user.AddComment(content, commentable);
    }

    public void VoteQuestion(User user, Question question, int value)
    {
        question.Vote(user, value);
    }
    
    public void VoteAnswer(User user, Answer answer, int value)
    {
        answer.Vote(user, value);
    }

    public void AcceptAnswer(Answer answer)
    {
        answer.MarkAsAccepted();
    }

    public List<Question> SearchQuestions(string query)
    {
        return _questions.Values.Where(q => q.Title.ToLower().Contains(query.ToLower()) ||
                                            q.Content.ToLower().Contains(query.ToLower()) ||
                                            q.Tags.Any(t => t.Name.ToLower().Equals(query.ToLower())))
            .ToList();
    }

    public List<Question> GetQuestionsByUser(User user) => user.GetQuestions();
}