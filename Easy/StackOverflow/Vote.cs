using System.Reflection.Metadata;

namespace LowLevelDesign.Easy.StackOverflow;

public class Vote
{
    public User User { get; }
    public int Value { get; }

    public Vote(User user, int value)
    {
        User = user;
        Value = value;
    }
}