using System;

namespace L1_S1
{
    class Program
    {
        // Static fields are initialized to their default values before Main runs.
        // For a reference type (string), the default is null.
        // For a value type (DateTime), it's its default value.
        // For an int, it's 0.
        static string txtAge;
        static DateTime selectedDate;
        static int parsedAge;

        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine(txtAge == null ? "txtAge is null" : txtAge);

                Console.WriteLine(selectedDate == default(DateTime)
                    ? "selectedDate is default"
                    : selectedDate.ToString());

                if (string.IsNullOrEmpty(txtAge))
                {
                    Console.WriteLine("txtAge is null or empty, cannot parse");
                }
                else
                {
                    // This block is never reached
                    parsedAge = int.Parse(txtAge);
                    Console.WriteLine($"Parsed Age: {parsedAge}");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Format Exception Caught");
            }
            catch (ArgumentNullException)
            {
                Console.WriteLine("ArgumentNull Exception Caught");
            }
            finally
            {
                Console.WriteLine("Finally block executed");
            }
        }
    }
}
