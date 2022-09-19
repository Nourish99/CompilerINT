package codigo;

import java.util.HashMap;
import java.util.Map;

public class TokenTitleConverter {

    private Map<Tokens,String> map = new HashMap<Tokens,String>();
    public TokenTitleConverter(){
        map.put(Tokens.Reserved,"Reservada");
        map.put(Tokens.Add,"Suma");
        map.put(Tokens.Substract,"Resta");
        map.put(Tokens.Multiply,"Multiplicacion");
        map.put(Tokens.Divide,"Division");
        map.put(Tokens.Pow,"Potencia");
        map.put(Tokens.LT,"Menor que");
        map.put(Tokens.LTEquals,"Menor igual que");
        map.put(Tokens.GT,"Mayor que");
        map.put(Tokens.GTEquals,"Mayor igual que");
        map.put(Tokens.Equals,"Igual que");
        map.put(Tokens.NEquals,"Diferente que");
        map.put(Tokens.Assign,"Asignacion");
        map.put(Tokens.SColon,"Punto y coma");
        map.put(Tokens.Comma,"Coma");
        map.put(Tokens.OParen,"Parentesis Abierto");
        map.put(Tokens.CParen,"Parentesis Cerrado");
        map.put(Tokens.OBrace,"Llave abierta");
        map.put(Tokens.CBrace,"Llave cerrada");
        map.put(Tokens.Identifier,"Identificador");
        map.put(Tokens.Number,"Numero");
        map.put(Tokens.CommentBlock,"Bloque de Comentarios");
        map.put(Tokens.SingleComment, "Comentario Simple");
        map.put(Tokens.ERROR,"Error");

    }

    public Map<Tokens, String> getMap(){
        return this.map;
    }

}
