//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.9.2
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from c:\Users\amaur\Documents\Compiladores I\PruebasProyecto\Prueba3\antlrGrammar\tiny.g4 by ANTLR 4.9.2

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using IParseTreeListener = Antlr4.Runtime.Tree.IParseTreeListener;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete listener for a parse tree produced by
/// <see cref="tinyParser"/>.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.9.2")]
[System.CLSCompliant(false)]
public interface ItinyListener : IParseTreeListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterParse([NotNull] tinyParser.ParseContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.parse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitParse([NotNull] tinyParser.ParseContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBlock([NotNull] tinyParser.BlockContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.block"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBlock([NotNull] tinyParser.BlockContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.lista_declaracion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLista_declaracion([NotNull] tinyParser.Lista_declaracionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.lista_declaracion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLista_declaracion([NotNull] tinyParser.Lista_declaracionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.declaracion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterDeclaracion([NotNull] tinyParser.DeclaracionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.declaracion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitDeclaracion([NotNull] tinyParser.DeclaracionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.lista_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLista_id([NotNull] tinyParser.Lista_idContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.lista_id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLista_id([NotNull] tinyParser.Lista_idContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.lista_sentencias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterLista_sentencias([NotNull] tinyParser.Lista_sentenciasContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.lista_sentencias"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitLista_sentencias([NotNull] tinyParser.Lista_sentenciasContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.sentencia"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSentencia([NotNull] tinyParser.SentenciaContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.sentencia"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSentencia([NotNull] tinyParser.SentenciaContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.seleccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSeleccion([NotNull] tinyParser.SeleccionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.seleccion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSeleccion([NotNull] tinyParser.SeleccionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.iteracion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterIteracion([NotNull] tinyParser.IteracionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.iteracion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitIteracion([NotNull] tinyParser.IteracionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.repeticion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRepeticion([NotNull] tinyParser.RepeticionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.repeticion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRepeticion([NotNull] tinyParser.RepeticionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.sent_read"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSent_read([NotNull] tinyParser.Sent_readContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.sent_read"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSent_read([NotNull] tinyParser.Sent_readContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.sent_write"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSent_write([NotNull] tinyParser.Sent_writeContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.sent_write"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSent_write([NotNull] tinyParser.Sent_writeContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.bloque"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterBloque([NotNull] tinyParser.BloqueContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.bloque"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitBloque([NotNull] tinyParser.BloqueContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.asignacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterAsignacion([NotNull] tinyParser.AsignacionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.asignacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitAsignacion([NotNull] tinyParser.AsignacionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.b_expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterB_expresion([NotNull] tinyParser.B_expresionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.b_expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitB_expresion([NotNull] tinyParser.B_expresionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.b_term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterB_term([NotNull] tinyParser.B_termContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.b_term"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitB_term([NotNull] tinyParser.B_termContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.not_factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterNot_factor([NotNull] tinyParser.Not_factorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.not_factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitNot_factor([NotNull] tinyParser.Not_factorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.b_factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterB_factor([NotNull] tinyParser.B_factorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.b_factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitB_factor([NotNull] tinyParser.B_factorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.relacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterRelacion([NotNull] tinyParser.RelacionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.relacion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitRelacion([NotNull] tinyParser.RelacionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterExpresion([NotNull] tinyParser.ExpresionContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.expresion"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitExpresion([NotNull] tinyParser.ExpresionContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.termino"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterTermino([NotNull] tinyParser.TerminoContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.termino"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitTermino([NotNull] tinyParser.TerminoContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.signoFactor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSignoFactor([NotNull] tinyParser.SignoFactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.signoFactor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSignoFactor([NotNull] tinyParser.SignoFactorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterFactor([NotNull] tinyParser.FactorContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.factor"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitFactor([NotNull] tinyParser.FactorContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.sumaOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterSumaOp([NotNull] tinyParser.SumaOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.sumaOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitSumaOp([NotNull] tinyParser.SumaOpContext context);
	/// <summary>
	/// Enter a parse tree produced by <see cref="tinyParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void EnterMultOp([NotNull] tinyParser.MultOpContext context);
	/// <summary>
	/// Exit a parse tree produced by <see cref="tinyParser.multOp"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	void ExitMultOp([NotNull] tinyParser.MultOpContext context);
}