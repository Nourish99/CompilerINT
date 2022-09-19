package codigo;
import static codigo.Tokens.*;


%%
%class Lexer
%type Tokens
%line
%column

Identifier=[a-zA-Z_][a-zA-Z_0-9]*
Number=([1-9][0-9]*|0)(\.[0-9]*)*
SingleComment=\/\/[^\r\n]*
CommentBlock=(\/\/~[\r\n]*|\/\*.*?\*\/)
Space=[ \t\r\u000C]
//String= ['](~['\r\n\\]|'\\'~[\r\n])*[']
%{
    public String lexeme;
    public int line;
    public int column;
%}
%%

program {lexeme=yytext(); line=yyline; column=yycolumn; return Program;}
if {lexeme=yytext(); line=yyline; column=yycolumn; return If;}
else {lexeme=yytext(); line=yyline; column=yycolumn; return Else;}
fi {lexeme=yytext(); line=yyline; column=yycolumn; return Fi;}
do {lexeme=yytext(); line=yyline; column=yycolumn; return Do;}
until {lexeme=yytext(); line=yyline; column=yycolumn; return Until;}
while {lexeme=yytext(); line=yyline; column=yycolumn; return While;}
read {lexeme=yytext(); line=yyline; column=yycolumn; return Read;}
write {lexeme=yytext(); line=yyline; column=yycolumn; return Write;}
float {lexeme=yytext(); line=yyline; column=yycolumn; return FLOAT;}
int {lexeme=yytext(); line=yyline; column=yycolumn; return INT;}
bool {lexeme=yytext(); line=yyline; column=yycolumn; return BOOL;}
not {lexeme=yytext(); line=yyline; column=yycolumn; return NOT;}
and {lexeme=yytext(); line=yyline; column=yycolumn; return AND;}
or {lexeme=yytext(); line=yyline; column=yycolumn; return OR;}
{Space} {/*Ignore*/}
"\n" {lexeme=yytext(); line=yyline; column=yycolumn; return Jump;}
"+" {lexeme=yytext(); line=yyline; column=yycolumn; return Add;}
"-" {lexeme=yytext(); line=yyline; column=yycolumn; return Substract;}
"*" {lexeme=yytext(); line=yyline; column=yycolumn; return Multiply;}
"/" {lexeme=yytext(); line=yyline; column=yycolumn; return Divide;}
"^" {lexeme=yytext(); line=yyline; column=yycolumn; return Pow;}
"<" {lexeme=yytext(); line=yyline; column=yycolumn; return LT;}
"<=" {lexeme=yytext(); line=yyline; column=yycolumn; return LTEquals;}
">" {lexeme=yytext(); line=yyline; column=yycolumn; return GT;}
">=" {lexeme=yytext(); line=yyline; column=yycolumn; return GTEquals;}
"==" {lexeme=yytext(); line=yyline; column=yycolumn; return Equals;}
"!=" {lexeme=yytext(); line=yyline; column=yycolumn; return NEquals;}
"=" {lexeme=yytext(); line=yyline; column=yycolumn; return Assign;}
";" {lexeme=yytext(); line=yyline; column=yycolumn; return SColon;}
"," {lexeme=yytext(); line=yyline; column=yycolumn; return Comma;}
"(" {lexeme=yytext(); line=yyline; column=yycolumn; return OParen;}
")" {lexeme=yytext(); line=yyline; column=yycolumn; return CParen;}
"{" {lexeme=yytext(); line=yyline; column=yycolumn; return OBrace;}
"}" {lexeme=yytext(); line=yyline; column=yycolumn; return CBrace;}
{Identifier} {lexeme=yytext(); line=yyline; column=yycolumn; return Identifier;}
{Number} {lexeme=yytext(); line=yyline; column=yycolumn; return Number;}
{CommentBlock} {lexeme=yytext(); line=yyline; column=yycolumn; return CommentBlock;}
{SingleComment}  {lexeme=yytext(); line=yyline; column=yycolumn; return SingleComment;}
 . {lexeme=yytext(); line=yyline; column=yycolumn; return ERROR;}
