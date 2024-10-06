namespace LeksikalAnalizator
{
    public enum TokenType
    {
        BEGIN, END, VAR, INTEGER, READ, WRITE, FOR, TO, DO, END_FOR,
        SEMICOLON, COLON, EQUALS, PLUS, MINUS, MULT, LPAREN, RPAREN,
        IDENT, CONST, EOF, UNEXP, ZAP // Конец файла
    }

    internal class Token
    {
        public TokenType Type { get; }
        public string Value { get; }

        public Token(TokenType type, string value)
        {
            Type = type;
            Value = value;
        }

        public override string ToString()
        {
            return $"{Type}: {Value}";
        }
    }
}