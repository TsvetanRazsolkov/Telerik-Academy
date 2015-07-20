using System;

public class SimpleMathExam : Exam
{
    private const int ProblemsCount = 10;
    private const int BadResultMaxProblemsCount = 2;
    private const int AverageResultMaxProblemsCount = 5;

    private int problemsSolved;

    public SimpleMathExam(int problemsSolved)
    {  
        this.ProblemsSolved = problemsSolved;
    }

    public int ProblemsSolved
    {
        get 
        { 
            return this.problemsSolved; 
        }

        private set
        {
            if (value < 0)
            {
                this.problemsSolved = 0;
            }
            else if (value > ProblemsCount)
            {
                this.problemsSolved = ProblemsCount;
            }
            else
            {
                this.problemsSolved = value;
            }
        }
    }

    public override ExamResult Check()
    {
        if (this.ProblemsSolved <= BadResultMaxProblemsCount)
        {
            return new ExamResult(2, 2, 6, "Bad result: nothing done.");
        }
        else if (this.ProblemsSolved <= AverageResultMaxProblemsCount)
        {
            return new ExamResult(4, 2, 6, "Average result: continue to next course.");
        }
        else
        {
            return new ExamResult(6, 2, 6, "Excellent result: continue to next course.");
        }
    }
}
