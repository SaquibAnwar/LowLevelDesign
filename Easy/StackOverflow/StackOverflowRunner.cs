namespace LowLevelDesign.Easy.StackOverflow;

public class StackOverflowRunner
{
    public static void Run()
    {
        var system = new StackOverflow();
        var alice = system.CreateUser("Alice", "alice@email.com");
        var bob = system.CreateUser("Bob", "bob@email.com");
        var judy = system.CreateUser("Judy", "judy@email.com");

        var question = system.AskQuestion(alice, "Inheritance", "Can someone explain what is inheritance",
            new List<string> { "OOP", "C#" });
        
        var bobAnswer = system.AddAnswer(bob, question, "Example example example");

        system.AddComment(judy, "That's easy", question);
        
        system.AddComment(alice, "Thank you!", bobAnswer);
        
        system.VoteQuestion(judy, question, 1);
        system.VoteAnswer(alice, bobAnswer, 1);
        
        system.AcceptAnswer(bobAnswer);
        
        var pythonQuestion = system.AskQuestion(bob, "How to use list comprehensions in Python?",
            "I'm new to Python and I've heard about list comprehensions. Can someone explain how to use them?",
            new List<string> { "python", "list-comprehension" });

        // Alice answers Bob's question
        var aliceAnswer = system.AddAnswer(alice, pythonQuestion,
            "List comprehensions in Python provide a concise way to create lists...");

        // Charlie votes on Bob's question and Alice's answer
        system.VoteQuestion(judy, pythonQuestion, 1);  // Upvote
        system.VoteAnswer(judy, aliceAnswer, 1);  // Upvote
        
        Console.WriteLine($"Question: {question.Title}");
        Console.WriteLine($"Asked by: {question.Author.Username}");
        Console.WriteLine($"Tags: {string.Join(", ", question.Tags)}");
        Console.WriteLine($"Votes: {question.GetVoteCount()}");
        Console.WriteLine($"Comments: {question.GetComments().Count}");
        Console.WriteLine($"\nAnswer by {bobAnswer.Author.Username}:");
        Console.WriteLine(bobAnswer.Content);
        Console.WriteLine($"Votes: {bobAnswer.GetVoteCount()}");
        Console.WriteLine($"Accepted: {bobAnswer.IsAccepted}");
        Console.WriteLine($"Comments: {bobAnswer.GetComments().Count}");

        Console.WriteLine("\nUser Reputations:");
        Console.WriteLine($"Alice: {alice.Reputation}");
        Console.WriteLine($"Bob: {bob.Reputation}");
        Console.WriteLine($"Charlie: {judy.Reputation}");

        // Demonstrate search functionality
        Console.WriteLine("\nSearch Results for 'inheritance':");
        var searchResults = system.SearchQuestions("inher");
        foreach (var ques in searchResults)
        {
            Console.WriteLine(ques.Content);
        }

        Console.WriteLine("\nSearch Results for 'python':");
        searchResults = system.SearchQuestions("python");
        foreach (var ques in searchResults)
        {
            Console.WriteLine(ques.Title);
        }

        // Demonstrate getting questions by user
        Console.WriteLine("\nBob's Questions:");
        var bobQuestions = system.GetQuestionsByUser(bob);
        foreach (var ques in bobQuestions)
        {
            Console.WriteLine(ques.Title);
        }
    }
}