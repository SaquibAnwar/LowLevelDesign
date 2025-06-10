namespace LowLevelDesign.Easy.StackOverflow;

public interface IVotable
{
    void Vote(User user, int value);
    int GetVoteCount();
}