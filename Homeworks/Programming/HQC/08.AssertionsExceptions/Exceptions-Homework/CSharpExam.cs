using System;

public class CSharpExam : Exam
{
    private const int MinPossibleScore = 0;
    private const int MaxPossibleScore = 100;

    private int score;

    public CSharpExam(int score)
    {
        this.Score = score;
    }

    public int Score
    {
        get
        {
            return this.score;
        }

        private set
        {
            if (value < MinPossibleScore || value > MaxPossibleScore)
            {
                throw new ArgumentOutOfRangeException(string.Format("Score must be between {0} and {1}.", MinPossibleScore, MaxPossibleScore));
            }

            this.score = value;
        }
    }

    public override ExamResult Check()
    {
        return new ExamResult(this.Score, MinPossibleScore, MaxPossibleScore, "Exam results calculated by score.");
    }
}
