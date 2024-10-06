namespace LeksikalAnalizator
{
    internal class Lexer
    {
        private string _input;
        private int _position;
        private Dictionary<string, TokenType> _keywords = new Dictionary<string, TokenType>
{
{ "BEGIN", TokenType.BEGIN },
{ "END", TokenType.END },
{ "VAR", TokenType.VAR },
{ "INTEGER", TokenType.INTEGER },
{ "READ", TokenType.READ },
{ "WRITE", TokenType.WRITE },
{ "FOR", TokenType.FOR },
{ "TO", TokenType.TO },
{ "DO", TokenType.DO },
{ "END_FOR", TokenType.END_FOR }
};

        public Lexer(string input)
        {
            _input = input;
            _position = 0;
        }

        private char CurrentChar => _position >= _input.Length ? '\0' : _input[_position];

        private void Advance() => _position++;

        private void SkipWhitespace()
        {
            while (char.IsWhiteSpace(CurrentChar))
            {
                Advance();
            }
        }

        private Token GetNumber()
        {
            string result = "";
            while (char.IsDigit(CurrentChar))
            {
                result += CurrentChar;
                Advance();
            }
            return new Token(TokenType.CONST, result);
        }

        private Token GetIdentifier()
        {
            string result = "";
            while (char.IsLetterOrDigit(CurrentChar))
            {
                result += CurrentChar;
                Advance();
            }

            if (_keywords.ContainsKey(result))
            {
                return new Token(_keywords[result], result);
            }

            return new Token(TokenType.IDENT, result);
        }

        public Token GetNextToken()
        {
            while (CurrentChar != '\0')
            {
                if (char.IsWhiteSpace(CurrentChar))
                {
                    SkipWhitespace();
                    continue;
                }

                if (char.IsLetter(CurrentChar))
                {
                    return GetIdentifier();
                }

                if (char.IsDigit(CurrentChar))
                {
                    return GetNumber();
                }

                switch (CurrentChar)
                {
                    case ';':
                        Advance();
                        return new Token(TokenType.SEMICOLON, ";");
                    case ':':
                        Advance();
                        return new Token(TokenType.COLON, ":");
                    case '=':
                        Advance();
                        return new Token(TokenType.EQUALS, "=");
                    case '+':
                        Advance();
                        return new Token(TokenType.PLUS, "+");
                    case '-':
                        Advance();
                        return new Token(TokenType.MINUS, "-");
                    case '*':
                        Advance();
                        return new Token(TokenType.MULT, "*");
                    case '(':
                        Advance();
                        return new Token(TokenType.LPAREN, "(");
                    case ')':
                        Advance();
                        return new Token(TokenType.RPAREN, ")");
                    case ',':
                        Advance();
                        return new Token(TokenType.ZAP, ",");
                }

                throw new Exception($"Unknown character: {CurrentChar}");
            }

            return new Token(TokenType.EOF, null);
        }
    }
}