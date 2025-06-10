namespace LowLevelDesign.Easy.StackOverflow;

public interface ICommentable
{
    void AddComment(Comment comment);
    List<Comment> GetComments();
}