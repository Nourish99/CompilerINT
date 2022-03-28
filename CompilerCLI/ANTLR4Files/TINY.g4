grammar TINY;


Parentesis: (OParen | CParen) {
   PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es un parentesis: "+ Text, 
				TokenLine=Line,
				TokenCol=Column });
};
Keys: (OBrace | CBrace) {
   PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es una llave: "+ Text, 
				TokenLine=Line,
				TokenCol=Column });
};
 
Type: (INT | Float | Bool)+ {
   PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Esto es un tipado: "+Text,
				TokenLine=Line,
				TokenCol=Column });
};

Reserved: (Program | If | Else | Fi | Do | Until | While | Read | Write | NOT | Or | And)+ 
{
   PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Esto es una palabra reservada: "+Text, 
				TokenLine=Line,
				TokenCol=Column });
};

Operator:
   (Equals | NEquals | GTEquals | LTEquals | Pow | Excl | GT | LT | Add | Subtract | Multiply | Divide | Modulus | Assign)+ {
      PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es un operador: "+ Text, 
				TokenLine=Line,
				TokenCol=Column });
   };

Program: 'program';
If       : 'if';
Else     : 'else';
Fi       :'fi';
Do       :'do';
Until    :'until';
While    : 'while';
Read     :'read';
Write    :'write';
Float    :'float';
INT      :'int';
Bool     :'bool';
NOT      :'not';
Or       : 'or';
And      : 'and';


Equals   : '==';
NEquals  : '!=';
GTEquals : '>=';
LTEquals : '<=';
Pow      : '^';
Excl     : '!';
GT       : '>';
LT       : '<';
Add      : '+';
Subtract : '-';
Multiply : '*';
Divide   : '/';
Modulus  : '%';
Assign   : '=';

OBrace   : '{';
CBrace   : '}';
OParen   : '(';
CParen   : ')';

SColon   : ';' {
   PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es un punto y coma: "+ Text,
				TokenLine=Line,
				TokenCol=Column });
};
Comma    : ',' {
   PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es una coma: "+ Text, 
				TokenLine=Line,
				TokenCol=Column });
};





Number
 : Int ( '.' Digit* )?
 {
    PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Esto es un numero: "+Text,
				TokenLine=Line,
				TokenCol=Column });
 }
 ;

Identifier
 : [a-zA-Z_] [a-zA-Z_0-9]* 
 {
    PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es un identificador: "+ Text,
				TokenLine=Line,
				TokenCol=Column });
 }
 ;



String
 : ["] ( ~["\r\n\\] | '\\' ~[\r\n] )* ["]
 | ['] ( ~['\r\n\\] | '\\' ~[\r\n] )* [']
 ;
Comment
 : ( '//' ~[\r\n]* | '/*' .*? '*/' ) {
    PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es un comentario: "+ Text, 
				TokenLine=Line,
				TokenCol=Column });
 }
 ;
Space
 : [ \t\r\n\u000C] -> skip
 ;
fragment Int
 : [1-9] Digit*
 | '0'
 ;
  
fragment Digit 
 : [0-9]
 ;

ERROR:
   .{
      PruebaANTLR.Program.Results.Add(new TokenItem(){
				TokenName=Text,
				TokenDesc="Es un token no reconocido: "+ Text, 
				TokenLine=Line,
				TokenCol=Column });
   };