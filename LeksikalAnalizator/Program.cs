using System.ComponentModel;
using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LeksikalAnalizator;

public class Program
{
    public static void Main(string[] args)
    {
        string input = "VAR x, y: INTEGER; BEGIN x = 5 + 10; WRITE(x); END";
        Lexer lexer = new Lexer(input);

        Token token;
        try
        {
            do
            {
                token = lexer.GetNextToken();
                Console.WriteLine(token);
            } while (token.Type != TokenType.EOF);
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
    }
}