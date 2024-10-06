using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace LeksikalAnalizator.Token;

public enum TokenType
{
    BEGIN, END, VAR, INTEGER, READ, WRITE, FOR, TO, DO, END_FOR,
    SEMICOLON, COLON, EQUALS, PLUS, MINUS, MULT, LPAREN, RPAREN,
    IDENT, CONST, EOF // Конец файла
}

public class Token
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