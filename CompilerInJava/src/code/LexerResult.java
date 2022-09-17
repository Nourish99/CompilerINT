package code;

public class LexerResult {
    private String Lexem;
    private String Description;
    private Integer Line;
    private Integer Col;

    public LexerResult(String le, String de, Integer li, Integer co){
        this.Lexem = le;
        this.Description = de;
        this.Line = li;
        this.Col = co;
    }

    public String getLexem() {
        return Lexem;
    }

    public void setLexem(String lexem) {
        Lexem = lexem;
    }

    public String getDescription() {
        return Description;
    }

    public void setDescription(String description) {
        Description = description;
    }

    public Integer getLine() {
        return Line;
    }

    public void setLine(Integer line) {
        Line = line;
    }

    public Integer getCol() {
        return Col;
    }

    public void setCol(Integer col) {
        Col = col;
    }
}
