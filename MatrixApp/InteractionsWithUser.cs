using System;
using MatrixApp.Resources;

namespace Program
{
    public class InteractionsWithUser
    {
        const int MinimumNumberOfAttempts = 1;

        public int numberOfAttempts;

        public InteractionsWithUser(int attemptsNumber)
        {
            if (attemptsNumber < MinimumNumberOfAttempts)
            {
                throw new ArgumentOutOfRangeException("attemptsNumber", attemptsNumber.ToString(), "The number of attempts must be more than 0.");
            }
            numberOfAttempts = attemptsNumber;
        }

        public int GetNumberFromUser(string requestMessage)
        {
            int attempt = 0;
            Console.Write(requestMessage);
            do
            {
                if (int.TryParse(Console.ReadLine(), out int number))
                {
                    return number;
                }
                Console.WriteLine(Message.NotNumberError);
                attempt++;
            } while (attempt < numberOfAttempts);
            throw new AttemptsExhaustedException(Message.AttemptsExhaustedError);
        }
    }
}
