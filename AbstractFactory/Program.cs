namespace DesignPatterns
{
    // Class for Printer
    // TODO#1: Convert to use Singleton pattern
    public class Printer
    {
        private static Printer _instance = default!;

        private Printer() { }

        public static Printer GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Printer();
            }
            return _instance;
        }
        public void Print(string message)
        {
            // Output: print out the string message 
            Console.WriteLine(message);
        }
    }

    // Class template for Exam classes
    // TODO#2: Convert to use Abstract Factory pattern
    // Create an Exam interface and an Abstract Factory to manage the creation of different exam types.
    public interface IExam
    {
        void Conduct();

        void Evaluate();

        void PublishResults();
    }

    public interface IExamFactory
    {
        int GetExamCount();

        IExam GetExam();
    }

    public class MathExam : IExam
    {
        private Printer mPrinter = Printer.GetInstance();

        public void Conduct()
        {
            // Output: "Conducting Math Exam", should use Printer class to print the message
            mPrinter.Print("Conducting Math Exam");
        }

        public void Evaluate()
        {
            // Output: "Evaluating Math Exam", should use Printer class to print the message
            mPrinter.Print("Evaluating Math Exam");
        }

        public void PublishResults()
        {
            // Output: "Publishing Math Exam Results", should use Printer class to print the message
            mPrinter.Print("Publishing Math Exam Results");
        }
    }

    public class MathExamFactory : IExamFactory
    {
        private int _ExamCount = 0;

        public int GetExamCount() => _ExamCount;

        public IExam GetExam()
        {
            _ExamCount++;
            return new MathExam();
        }
    }

    // TODO#5: Add new ScienceExam class
    public class ScienceExam : IExam
    {
        private Printer sPrinter = Printer.GetInstance();

        public void Conduct()
        {
            // Output: "Conducting Science Exam", should use Printer class to print the message
            sPrinter.Print("Conducting Science Exam");
        }

        public void Evaluate()
        {
            // Output: "Evaluating Science Exam", should use Printer class to print the message
            sPrinter.Print("Evaluating Science Exam");
        }

        public void PublishResults()
        {
            // Output: "Publishing Science Exam Results", should use Printer class to print the message
            sPrinter.Print("Publishing Science Exam Results");
        }
    }

    public class ScienceExamFactory : IExamFactory
    {
        private int _ExamCount = 0;

        public int GetExamCount() => _ExamCount;

        public IExam GetExam()
        {
            _ExamCount++;
            return new ScienceExam();
        }
    }

    // TODO#6: Add another ProgrammingExam class
    public class ProgrammingExam : IExam
    {
        private Printer pPrinter = Printer.GetInstance();

        public void Conduct()
        {
            // Output: "Conducting Programming Exam", should use Printer class to print the message
            pPrinter.Print("Conducting Programming Exam");
        }

        public void Evaluate()
        {
            // Output: "Evaluating Programming Exam", should use Printer class to print the message
            pPrinter.Print("Evaluating Programming Exam");
        }

        public void PublishResults()
        {
            // Output: "Publishing Programming Exam Results", should use Printer class to print the message
            pPrinter.Print("Publishing Programming Exam Results");
        }
    }

    public class ProgrammingExamFactory : IExamFactory
    {
        private int _ExamCount = 0;

        public int GetExamCount() => _ExamCount;

        public IExam GetExam()
        {
            _ExamCount++;
            return new ProgrammingExam();
        }
    }

    // Main Program
    class Program
    {
        static void Main(string[] args)
        {
            // TODO#7: Initialize Printer that uses Singleton pattern
            Printer printer1 = Printer.GetInstance();

            // TODO#8: Test that the created Printer works, by calling the Print method
            printer1.Print("Exams are about to start");

            // TODO#9: Ensure that only one Printer instance is used throughout the application.
            //         Try to create new Printer object and compare the two objects to check,
            //         that the new printer object is the same instance
            Printer printer2 = Printer.GetInstance();
            printer1.Print("Is there only one printer that works?");
            printer2.Print(printer1 == printer2 ? "Yes" : "No");
            printer1.Print("");

            // TODO#10: Use Abstract Factory to create different types of exams.
            IExamFactory mExamFactory = new MathExamFactory();
            IExam Exam1 = mExamFactory.GetExam();
            Exam1.Conduct();
            Exam1.Evaluate();
            Exam1.PublishResults();
            printer1.Print($"Number of math exams: {mExamFactory.GetExamCount()}\n");

            IExamFactory sExamFactory = new ScienceExamFactory();
            IExam Exam2 = sExamFactory.GetExam();
            Exam2.Conduct();
            Exam2.Evaluate();
            Exam2.PublishResults();
            printer1.Print($"Number of math exams: {sExamFactory.GetExamCount()}\n");

            IExamFactory pExamFactory = new ProgrammingExamFactory();
            IExam Exam3 = pExamFactory.GetExam();
            Exam3.Conduct();
            Exam3.Evaluate();
            Exam3.PublishResults();
            printer1.Print($"Number of math exams: {pExamFactory.GetExamCount()}\n");
        }
    }
}
