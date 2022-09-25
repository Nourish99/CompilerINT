package codigo.sintax;
import static codigo.Tokens;import java_cup.runtime.*;


%%
%class LexerCup
%type java_cup.runtime.Symbol
%cup
%full
%line
%char


Identifier=[a-zA-Z_][a-zA-Z_0-9]*
Number=([1-9][0-9]*|0)(\.[0-9]*)*
SingleComment=\/\/[^\r\n]*
CommentBlock=(\/\/~[\r\n]*|\/\*.*?\*\/)
Space=[ \t\r\u000C]
//String= ['](~['\r\n\\]|'\\'~[\r\n])*[']
%{
    private Symbol symbol(int type, Object value){
      return new Symbol(type, yyline, yycolumn, value);
    }
    private Symbol symbol(int type){
          return new Symbol(type, yyline, yycolumn);
        }
%}
%%

program {return new Symbol(sym.Program, yychar, yyline, yytext());}
if {return new Symbol(sym.If, yychar, yyline, yytext());}
else {return new Symbol(sym.Else, yychar, yyline, yytext());}
fi {return new Symbol(sym.Fi, yychar, yyline, yytext());}
then {return new Symbol(sym.Then, yychar, yyline, yytext());}
do {return new Symbol(sym.Do, yychar, yyline, yytext());}
until {return new Symbol(sym.Until, yychar, yyline, yytext());}
while {return new Symbol(sym.While, yychar, yyline, yytext());}
read {return new Symbol(sym.Read, yychar, yyline, yytext());}
write {return new Symbol(sym.Write, yychar, yyline, yytext());}
float {return new Symbol(sym.FLOAT, yychar, yyline, yytext());}
int {return new Symbol(sym.INT, yychar, yyline, yytext());}
bool {return new Symbol(sym.BOOL, yychar, yyline, yytext());}
not {return new Symbol(sym.NOT, yychar, yyline, yytext());}
and {return new Symbol(sym.AND, yychar, yyline, yytext());}
or {return new Symbol(sym.OR, yychar, yyline, yytext());}
true {return new Symbol(sym.True, yychar, yyline, yytext());}
false {return new Symbol(sym.False, yychar, yyline, yytext());}
{Space} {/*Ignore*/}
"\n" {return new Symbol(sym.Jump, yychar, yyline, yytext());}
"+" {return new Symbol(sym.Add, yychar, yyline, yytext());}
"-" {return new Symbol(sym.Substract, yychar, yyline, yytext());}
"*" {return new Symbol(sym.Multiply, yychar, yyline, yytext());}
"/" {return new Symbol(sym.Divide, yychar, yyline, yytext());}
"^" {return new Symbol(sym.Pow, yychar, yyline, yytext());}
"%" {return new Symbol(sym.Modulus, yychar, yyline, yytext());}
"<" {return new Symbol(sym.LT, yychar, yyline, yytext());}
"<=" {return new Symbol(sym.LTEquals, yychar, yyline, yytext());}
">" {return new Symbol(sym.GT, yychar, yyline, yytext());}
">=" {return new Symbol(sym.GTEquals, yychar, yyline, yytext());}
"==" {return new Symbol(sym.Equals, yychar, yyline, yytext());}
"!=" {return new Symbol(sym.NEquals, yychar, yyline, yytext());}
"=" {return new Symbol(sym.Assign, yychar, yyline, yytext());}
";" {return new Symbol(sym.SColon, yychar, yyline, yytext());}
"," {return new Symbol(sym.Comma, yychar, yyline, yytext());}
"(" {return new Symbol(sym.OParen, yychar, yyline, yytext());}
")" {return new Symbol(sym.CParen, yychar, yyline, yytext());}
"{" {return new Symbol(sym.OBrace, yychar, yyline, yytext());}
"}" {return new Symbol(sym.CBrace, yychar, yyline, yytext());}
{Identifier} {return new Symbol(sym.Identifier, yychar, yyline, yytext());}
{Number} {return new Symbol(sym.Number, yychar, yyline, yytext());}
{CommentBlock} {return new Symbol(sym.CommentBlock, yychar, yyline, yytext());}
{SingleComment}  {return new Symbol(sym.SingleComment, yychar, yyline, yytext());}
 . {return new Symbol(sym.ERROR, yychar, yyline, yytext());}
