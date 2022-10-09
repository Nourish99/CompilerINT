grammar tiny;

parse
 : block EOF
 ;

block
 : Program Keys ( lista_declaracion lista_sentencias)*  Keys
 ;

lista_declaracion: (declaracion)+ ;
declaracion: Type lista_id ';';
lista_id: Identifier (',' Identifier)*;

lista_sentencias: (sentencia)+ ;
sentencia: seleccion | iteracion | repeticion | sent_read | sent_write | bloque | asignacion | Comment;

seleccion: If Parentesis b_expresion Parentesis Then bloque (Else bloque)? Fi;
iteracion: While Parentesis b_expresion Parentesis bloque;
repeticion: Do bloque Until Parentesis b_expresion Parentesis SColon;
sent_read : Read Identifier SColon;
sent_write : Write b_expresion SColon;
bloque : Keys lista_sentencias Keys;
asignacion : Identifier Assign b_expresion SColon;



b_expresion : b_term (Or b_term)?;
b_term : not_factor (And not_factor)?;
not_factor : (NOT)? b_factor;
b_factor : (True|False) | relacion;
relacion : expresion (RelOperator expresion)?;
expresion :termino ( sumaOp termino )?;
termino : signoFactor (multOp signoFactor )?;
signoFactor : (sumaOp)? factor;
factor : Parentesis b_expresion Parentesis | Number | Identifier;


Parentesis: (OParen | CParen) ;
Keys: (OBrace | CBrace) ;
 
Type: (INT | Float | Bool)+ ;

/*Reserved: (Program | If | Else | Fi | Do | Until | While | Read | Write | NOT | Or | And)+ ;*/

RelOperator:
   (Equals | NEquals | GTEquals | LTEquals | Pow | Excl | GT | LT )+;

sumaOp: (Add | Subtract)+;

multOp: (Multiply | Divide | Modulus)+;

Program: 'program';
If       : 'if';
Else     : 'else';
Then     : 'then';
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
True     : 'true';
False    : 'false';


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

SColon   : ';' ;
Comma    : ',' ;





Number
 : Int ( '.' Digit* )?;

Identifier
 : [a-zA-Z_] [a-zA-Z_0-9]* ;



String
 : ["] ( ~["\r\n\\] | '\\' ~[\r\n] )* ["]
 | ['] ( ~['\r\n\\] | '\\' ~[\r\n] )* [']
 ;
Comment
 : ( '//' ~[\r\n]* | '/*' .*? '*/' ) ;
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
     Console.WriteLine("Error");
   };