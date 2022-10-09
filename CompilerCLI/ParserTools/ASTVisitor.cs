using System;
using System.Collections.Generic;
using System.Linq;
using Antlr4.Runtime.Tree;
using Antlr4.Runtime.Misc;
using CompilerCLI.Models;

namespace CompilerCLI.ParserTools
{
    public class ASTVisitor : tinyBaseVisitor<object?>
    {
        public ASTNode parent { get; set; }
        public Dictionary<string, SymTableItem> Variables { get; } = new();
        private int node_id = 0;
        private int tmp_vars_id = 0;
        private Stack<ASTNode> aSTNodes = new Stack<ASTNode>();
        public List<string> SemanticErrors { get; } = new List<string>();

        public override object VisitBlock([NotNull] tinyParser.BlockContext context)
        {
            parent = new ASTNode()
            {

                Id = node_id,
                Label = context.Program().GetText()
            };
           
            if(context.lista_declaracion().Length > 0)
            {
                foreach(var n in context.lista_declaracion())
                {
                    var listasd = Visit(n);
                    if (typeof(ASTNode).IsInstanceOfType(listasd))
                    {

                        parent.Children.Add((ASTNode)listasd);
                    }
                    else
                    {
                        parent.Children.AddRange((List<ASTNode>)listasd);

                    }
                }
            }
            if (context.lista_sentencias().Length > 0)
            {
                foreach (var n in context.lista_sentencias())
                {
                    var listass = Visit(n);
                    //parent.Children.Add((ASTNode)Visit(n));
                    if (typeof(ASTNode).IsInstanceOfType(listass))
                    {

                        parent.Children.Add((ASTNode)listass);
                    }
                    else
                    {
                        parent.Children.AddRange((List<ASTNode>)listass);

                    }
                }
            }

            return parent;
        }

        public override object VisitLista_sentencias([NotNull] tinyParser.Lista_sentenciasContext context)
        {
            if (context.sentencia().Length <=0)
            {
                return null;

            }else if(context.sentencia().Length == 1)
            {
                return Visit(context.sentencia()[0]);
            }
            else
            {
                var sents = new List<ASTNode>();
                foreach (var a in context.sentencia())
                {
                    sents.Add((ASTNode)Visit(a));
                }
                return sents;
            }
            //return base.VisitLista_sentencias(context);

        }

        public override object VisitSentencia([NotNull] tinyParser.SentenciaContext context)
        {
            if (context.seleccion() != null)
            {
                return Visit(context.seleccion());
            }
            else if (context.iteracion() != null)
            {
                return Visit(context.iteracion());
            }
            else if(context.repeticion() != null)
            {
                return Visit(context.repeticion());
            }
            else if(context.sent_read() != null)
            {
                return Visit(context.sent_read());
            }
            else if(context.sent_write() != null)
            {
                return Visit(context.sent_write());
            }
            else if(context.bloque() != null)
            {
                return Visit(context.bloque());
            }
            else if (context.asignacion() != null)
            {
                return Visit(context.asignacion());
            }
            else
            {
                return base.VisitSentencia(context);
            }
        }


        public override object VisitSeleccion([NotNull] tinyParser.SeleccionContext context)
        {
            var ifStatNode = new ASTNode()
            {
                Id = node_id++,
                Label = "If statment"
            };

            //cuando no
            var ifNode = new ASTNode()
            {
                Id = node_id++,
                Label = context.If().GetText()
            };

            var b_exp = Visit(context.b_expresion());
            var bloq = Visit(context.bloque()[0]);
            if (typeof(ASTNode).IsInstanceOfType(b_exp))
            {
                ifNode.Children.Add((ASTNode)b_exp);
            }
            if (typeof(ASTNode).IsInstanceOfType(bloq))
            {
                ifNode.Children.Add((ASTNode)bloq);
            }


            if (context.Else() != null)
            {
                //cuando hay else
                ifStatNode.Children.Add(ifNode);
                var elseNode = new ASTNode()
                {
                    Id = node_id++,
                    Label = context.Else().GetText()
                };
                var elseBloque = Visit(context.bloque()[1]);
                if (typeof(ASTNode).IsInstanceOfType(elseBloque))
                {
                    elseNode.Children.Add((ASTNode)elseBloque);
                }
                else
                {
                    elseNode.Children.Add(new ASTNode() { Id = node_id++, Label = elseBloque.ToString() });
                }
                elseNode.Children.Add(new ASTNode() { Id = node_id++, Label = context.Fi().GetText() });
                ifStatNode.Children.Add(elseNode);
            }
            else
            {
                ifStatNode = ifNode;
            }
            return ifStatNode;

            //return base.VisitSeleccion(context);
        }


        public override object VisitIteracion([NotNull] tinyParser.IteracionContext context)
        {
            var whileNode = new ASTNode()
            {
                Id = node_id++,
                Label = context.While().GetText()
            };

            if (context.b_expresion()!=null)
            {
                var condicion = Visit(context.b_expresion());
                if (typeof(ASTNode).IsInstanceOfType(condicion))
                {
                    whileNode.Children.Add((ASTNode)condicion);

                }
                else
                {
                    whileNode.Children.Add(new ASTNode()
                    {
                        Id = node_id++,
                        Label = condicion.ToString()
                    });
                }
                var bloquee = Visit(context.bloque());
                if (typeof(ASTNode).IsInstanceOfType(bloquee))
                {
                    whileNode.Children.Add((ASTNode)bloquee);

                }
                else
                {
                    whileNode.Children.Add(new ASTNode()
                    {
                        Id = node_id++,
                        Label = bloquee.ToString()
                    });
                }
            }
            return whileNode;
//            return base.VisitIteracion(context);
        }

        public override object VisitRepeticion([NotNull] tinyParser.RepeticionContext context)
        {
            var doWhileNode = new ASTNode()
            {
                Id = node_id++,
                Label = context.Do().GetText() + " - " + context.Until().GetText()
            };

            var expre = Visit(context.b_expresion());
            var bloquee = Visit(context.bloque());

            if (typeof(ASTNode).IsInstanceOfType(bloquee))
            {
                doWhileNode.Children.Add((ASTNode)bloquee);
            }
            else
            {
                doWhileNode.Children.Add(new ASTNode()
                {
                    Id = node_id++,
                    Label = bloquee.ToString()
                });
            }

            if (typeof(ASTNode).IsInstanceOfType(expre))
            {
                doWhileNode.Children.Add((ASTNode)expre);
            }
            else
            {
                doWhileNode.Children.Add(new ASTNode()
                {
                    Id = node_id++,
                    Label = expre.ToString()
                });

            }
            
            return doWhileNode;
           // return base.VisitRepeticion(context);
        }
        public override object VisitSent_read([NotNull] tinyParser.Sent_readContext context)
        {
            var readNode = new ASTNode() { Id = node_id++, Label = context.Read().GetText() };
            var ident = context.Identifier().GetText();
            if (!Variables.ContainsKey(ident))
            {
                SemanticErrors.Add($"Variable no declarada: {ident}. Linea: {context.Identifier().Symbol.Line}. Columna:{context.Identifier().Symbol.Column}");
            }
            readNode.Children.Add(new ASTNode() { Id=node_id++, Label = ident});
            //Aqui asignar el valoor a la tabla de simbolos
            return readNode;
            //return base.VisitSent_read(context);
        }
        public override object VisitSent_write([NotNull] tinyParser.Sent_writeContext context)
        {
            var writeNode = new ASTNode() { Id = node_id++, Label = context.Write().GetText() };
            var b_exp = Visit(context.b_expresion());
            if (typeof(ASTNode).IsInstanceOfType(b_exp))
            {
                writeNode.Children.Add((ASTNode)b_exp);
            }
            else
            {
                writeNode.Children.Add(new ASTNode()
                {
                    Id = node_id++,
                    Label = b_exp.ToString()
                });
            }
            return writeNode;
//            return base.VisitSent_write(context);
        }
        public override object VisitBloque([NotNull] tinyParser.BloqueContext context)
        {
            var blooqueNode = Visit(context.lista_sentencias());
            var nodeB = new ASTNode()
            {
                Id = node_id++,
                Label = "Bloque"
            };

            if (typeof(ASTNode).IsInstanceOfType(blooqueNode))
            {

                nodeB.Children.Add((ASTNode)blooqueNode);
            }
            else
            {
                nodeB.Children.AddRange((List<ASTNode>)blooqueNode);

            }
            return nodeB;
        }
        public override object VisitLista_declaracion([NotNull] tinyParser.Lista_declaracionContext context)
        {
             if (context.declaracion().Length <= 0)
             {
                return null;
             }else if (context.declaracion().Length == 1)
             {
                 return Visit(context.declaracion()[0]);
             }
             else
             {
                var dec = new List<ASTNode>();
                foreach(var a in context.declaracion())
                {
                    dec.Add((ASTNode)Visit(a));
                }
                return dec;
             }
            //return base.VisitLista_declaracion(context);

        }

        public override object VisitDeclaracion([NotNull] tinyParser.DeclaracionContext context)
        {
            if (context.Type() != null)
            {
                var variablesType = context.Type();
                var variable = Visit(context.lista_id());
                if (typeof(ITerminalNode[]).IsInstanceOfType(variable))
                {
                    var lista_ids = (ITerminalNode[])variable;

                    
                    var nl = lista_ids.ToList();
                    nl.Insert(0,variablesType);
                    var a = convertArrayToTree(nl.ToArray(), 0, variablesType.GetText().ToLower());
                    return a;
                }
            }

            return base.VisitDeclaracion(context);
        }

        public override object VisitLista_id([NotNull] tinyParser.Lista_idContext context)
        {
            return context.Identifier();

        }

        private ASTNode convertArrayToTree(ITerminalNode[] array, int i, string tipo)
        {
            ASTNode root = null;

            if (i < array.Length)
            {
                root = new ASTNode() { Id = node_id++, Label = array[i].GetText(), Valor = tipo };
                if (!isType(array[i].GetText()))
                {
                    if (Variables.ContainsKey(array[i].GetText()))
                    {
                        SemanticErrors.Add($"Doble declaracion de variable: {array[i].GetText()}. Linea: {array[i].Symbol.Line}. Columna:{array[i].Symbol.Column}");
                    }
                    else
                    {
                        Variables.Add(array[i].GetText(), new SymTableItem() { Identifier = array[i].GetText(), Type = tipo, Col = array[i].Symbol.Column, Line = array[i].Symbol.Column });

                    }

                }
                root.Children.Add(convertArrayToTree(array, 2 * i + 1, tipo));
                root.Children.Add(convertArrayToTree(array, 2 * i + 2, tipo));

            }
            return root;
        }

        private bool isType(string pal)
        {
            var a = pal.ToLower();
            switch (a)
            {
                case "bool":
                case "float":
                case "int":
                    return true;
                default:
                    return false;
            }
        }

        /*private ASTNode ConvertListaDeclToTree(tinyParser.DeclaracionContext[] array , int i)
        {
            ASTNode root = null;

            if (i<array.Length)
            {
                root = new ASTNode() { Id = node_id++, Label = "lista_decl" };

                root.Left = ConvertListaDeclToTree(array, 2 * i + 1);
                root.Right = ConvertListaDeclToTree(array, 2 * i + 2);
            }
            return root;
        }*/



        public override object VisitAsignacion([NotNull] tinyParser.AsignacionContext context)
        {
            var varName = context.Identifier().GetText();

            var sign = context.Assign().GetText();

            var value = Visit(context.b_expresion());

            if (value == null)
            {
                throw new Exception($"Error de asignacion");

            }

            if (Variables[varName] == null)
            {
                throw new Exception($"Variable no declarada anteriormente  {varName}");
            }
            else
            {
                Variables[varName].Value = value;
                var r = new ASTNode() { Id = node_id++, Label = sign };
                r.Children.Add(new ASTNode() { Id = node_id++, Label = varName });
                if (typeof(ASTNode).IsInstanceOfType(value))
                {
                    r.Children.Add((ASTNode)value);
                }
                else
                {
                    r.Children.Add(new ASTNode() { Id = node_id++, Label = value.ToString() });

                }
                return r;
                
            }

            //return base.VisitAsignacion(context);
        }

        public override object VisitB_factor([NotNull] tinyParser.B_factorContext context)
        {
            if (context.True() != null)
            {
                var tr = context.True().GetText();

                if (tr != null)
                {
                    return true;

                }
                
            }else if(context.False() != null)
            {
                var fl = context.False().GetText();
                if (fl != null)
                {
                    return false;
                }
            }
            else
            {
                return Visit(context.relacion());
            }
            return base.VisitB_factor(context);
        }
        public override object VisitRelacion([NotNull] tinyParser.RelacionContext context)
        {
            if (context.RelOperator() != null)
            {
                var izq = Visit(context.expresion()[0]);
                var dere = Visit(context.expresion()[1]);

                //pendiente de implementar la operacion y asignarla a la tabla de simbolos

                ASTNode lf;
                ASTNode rt;

                if (!typeof(ASTNode).IsInstanceOfType(izq))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(izq))
                    {
                        if (Variables.ContainsKey((string)izq))
                        {
                            valor = Variables[(string)izq].Value;
                        }
                    }
                    else
                    {
                        valor = izq.GetType().Name;
                    }
                    lf = new ASTNode()
                    {
                        Id = node_id++,
                        Label = (string)izq,
                        Valor = valor.ToString(),
                    };
                }
                else
                {
                    lf = (ASTNode)izq;
                }
                if (!typeof(ASTNode).IsInstanceOfType(dere))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(dere))
                    {
                        if (Variables.ContainsKey((string)dere))
                        {
                            valor = Variables[(string)dere].Value;
                        }
                    }
                    else
                    {
                        valor = dere.GetType().Name;
                    }
                    rt = new ASTNode()
                    {
                        Id = node_id++,
                        Label = dere.ToString(),
                        Valor = valor.ToString()
                    };
                }
                else
                {
                    rt = (ASTNode)dere;
                }

                //Al igual que expresion y todo para abajo


                //falta aqui
                var r = new ASTNode()
                {
                    Id = node_id++,
                    Label = context.RelOperator().GetText()

                };
                r.Children.Add(lf);
                r.Children.Add(rt);
                return r;
            }
            else
            {
                return Visit(context.expresion()[0]);
            }
            //return base.VisitRelacion(context);
        }

        public override object VisitB_expresion([NotNull] tinyParser.B_expresionContext context)
        {
            if (context.Or() != null)
            {
                var izq = Visit(context.b_term()[0]);
                var dere = Visit(context.b_term()[1]);

                //pendiente de implementar la operacion y asignarla a la tabla de simbolos

                ASTNode lf;
                ASTNode rt;

                if (!typeof(ASTNode).IsInstanceOfType(izq))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(izq))
                    {
                        if (Variables.ContainsKey((string)izq))
                        {
                            valor = Variables[(string)izq].Value;
                        }
                    }
                    else
                    {
                        valor = izq.GetType().Name;
                    }
                    lf = new ASTNode()
                    {
                        Id = node_id++,
                        Label = (string)izq,
                        Valor = valor.ToString(),
                    };
                }
                else
                {
                    lf = (ASTNode)izq;
                }
                if (!typeof(ASTNode).IsInstanceOfType(dere))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(dere))
                    {
                        if (Variables.ContainsKey((string)dere))
                        {
                            valor = Variables[(string)dere].Value;
                        }
                    }
                    else
                    {
                        valor = dere.GetType().Name;
                    }
                    rt = new ASTNode()
                    {
                        Id = node_id++,
                        Label = dere.ToString(),
                        Valor = valor.ToString()
                    };
                }
                else
                {
                    rt = (ASTNode)dere;
                }

                //Al igual que expresion y todo para abajo


                //falta aqui
                var r = new ASTNode()
                {
                    Id = node_id++,
                    Label = context.Or().GetText()

                };
                r.Children.Add(lf);
                r.Children.Add(rt);
                return r;
            }
            else
            {
                return Visit(context.b_term()[0]);
            }
            //return base.VisitB_expresion(context);
        }

        public override object VisitB_term([NotNull] tinyParser.B_termContext context)
        {
            if (context.And()!= null)
            {
                var izq = Visit(context.not_factor()[0]);
                var dere = Visit(context.not_factor()[1]);

                //pendiente de implementar la operacion y asignarla a la tabla de simbolos

                ASTNode lf;
                ASTNode rt;

                if (!typeof(ASTNode).IsInstanceOfType(izq))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(izq))
                    {
                        if (Variables.ContainsKey((string)izq))
                        {
                            valor = Variables[(string)izq].Value;
                        }
                    }
                    else
                    {
                        valor = izq.GetType().Name;
                    }
                    lf = new ASTNode()
                    {
                        Id = node_id++,
                        Label = (string)izq,
                        Valor = valor.ToString(),
                    };
                }
                else
                {
                    lf = (ASTNode)izq;
                }
                if (!typeof(ASTNode).IsInstanceOfType(dere))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(dere))
                    {
                        if (Variables.ContainsKey((string)dere))
                        {
                            valor = Variables[(string)dere].Value;
                        }
                    }
                    else
                    {
                        valor = dere.GetType().Name;
                    }
                    rt = new ASTNode()
                    {
                        Id = node_id++,
                        Label = dere.ToString(),
                        Valor = valor.ToString()
                    };
                }
                else
                {
                    rt = (ASTNode)dere;
                }

                //Al igual que expresion y todo para abajo


                //falta aqui
                var r = new ASTNode()
                {
                    Id = node_id++,
                    Label = context.And().GetText()

                };
                r.Children.Add(lf);
                r.Children.Add(rt);
                return r;

            }
            else
            {
                return Visit(context.not_factor()[0]);

            }
//            return base.VisitB_term(context);
        }

        public override object VisitNot_factor([NotNull] tinyParser.Not_factorContext context)
        {
            
            if ( context.NOT()!=null)
            {
                var nodo = Visit(context.b_factor());
                //ooperacion pendiente

                if (typeof(ASTNode).IsInstanceOfType(nodo))
                {
                    var r1 = new ASTNode()
                    {
                        Id = node_id++,
                        Label = context.NOT().GetText()
                    };
                    r1.Children.Add((ASTNode)nodo);
                    return r1;
                }
                else
                {
                    //checar si es variable y si existe en la tabla de ssimbolos y checar tipo
                    if (typeof(bool).IsInstanceOfType(nodo))
                    {
                        return !(bool)nodo;
                    }
                    else
                    {
                        if (Variables.ContainsKey((string)nodo))
                        {
                            if (Variables[(string)nodo].Type != "bool")
                            {
                                SemanticErrors.Add($"No se puede negar una variable no booleana. Linea: {context.NOT().Symbol.Line}, Col:{context.NOT().Symbol.Column} ");
                                return nodo;
                            }
                            else
                            {
                                Variables[(string)nodo].Value = !(bool)Variables[(string)nodo].Value;
                                var r2 = new ASTNode()
                                {
                                    Id = node_id++,
                                    Label = context.NOT().GetText()
                                };
                                r2.Children.Add(new ASTNode()
                                {
                                    Id = node_id++,
                                    Label = (string)nodo,
                                    Valor = "bool"
                                });
                                return r2;
                            }
                        }
                        else
                        {
                            SemanticErrors.Add($"Error semantico al negar ");
                            return nodo;
                        }
                    }
                }
            }
            else
            {
                return Visit(context.b_factor());

            }
            //return base.VisitNot_factor(context);
        }
        public override object VisitExpresion([NotNull] tinyParser.ExpresionContext context)
        {
            if (context.sumaOp() != null)
            {
                var izq = Visit(context.termino()[0]);
                var dere = Visit(context.termino()[1]);

                //pendiente de implementar la operacion y asignarla a la tabla de simbolos

                ASTNode lf;
                ASTNode rt;

                if (!typeof(ASTNode).IsInstanceOfType(izq))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(izq))
                    {
                        if (Variables.ContainsKey((string)izq))
                        {
                            valor = Variables[(string)izq].Value;
                        }
                    }
                    else
                    {
                        valor = izq.GetType().Name;
                    }
                    lf = new ASTNode()
                    {
                        Id = node_id++,
                        Label = (string)izq,
                        Valor = valor.ToString(),
                    };
                }
                else
                {
                    lf = (ASTNode)izq;
                }
                if (!typeof(ASTNode).IsInstanceOfType(dere))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(dere))
                    {
                        if (Variables.ContainsKey((string)dere))
                        {
                            valor = Variables[(string)dere].Value;
                        }
                    }
                    else
                    {
                        valor = dere.GetType().Name;
                    }
                    rt = new ASTNode()
                    {
                        Id = node_id++,
                        Label = dere.ToString(),
                        Valor = valor.ToString()
                    };
                }
                else
                {
                    rt = (ASTNode)dere;
                }

                //Al igual que expresion y todo para abajo


                //falta aqui
                var r = new ASTNode()
                {
                    Id = node_id++,
                    Label = context.sumaOp().GetText()

                };
                r.Children.Add(lf);
                r.Children.Add(rt);
                return r;
            }
            else
            {
                return Visit(context.termino()[0]);
            }

            //return base.VisitExpresion(context);
        }
        public override object VisitTermino([NotNull] tinyParser.TerminoContext context)
        {
            if (context.multOp() != null)
            {
                var izq = Visit(context.signoFactor()[0]);
                var dere = Visit(context.signoFactor()[1]);

                //pendiente de implementar la operacion y asignarla a la tabla de simbolos

                ASTNode lf;
                ASTNode rt;

                if (!typeof(ASTNode).IsInstanceOfType(izq))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(izq))
                    {
                        if (Variables.ContainsKey((string)izq))
                        {
                            valor = Variables[(string)izq].Value;
                        }
                    }
                    else
                    {
                        valor = izq.GetType().Name;
                    }
                    lf = new ASTNode()
                    {
                        Id = node_id++,
                        Label = (string)izq,
                        Valor = valor.ToString(),
                    };
                }
                else
                {
                    lf = (ASTNode)izq;
                }
                if (!typeof(ASTNode).IsInstanceOfType(dere))
                {
                    var valor = new object();
                    if (typeof(string).IsInstanceOfType(dere))
                    {
                        if (Variables.ContainsKey((string)dere))
                        {
                            valor = Variables[(string)dere].Value;
                        }
                    }
                    else
                    {
                        valor = dere.GetType().Name;
                    }
                    rt = new ASTNode()
                    {
                        Id = node_id++,
                        Label = dere.ToString(),
                        Valor = valor.ToString()
                    };
                }
                else
                {
                    rt = (ASTNode)dere;
                }

                //Al igual que expresion y todo para abajo


                //falta aqui
                var r = new ASTNode()
                {
                    Id = node_id++,
                    Label = context.multOp().GetText()

                };
                r.Children.Add(lf);
                r.Children.Add(rt);
                return r;
            }
            else
            {
                return Visit(context.signoFactor()[0]);
            }
            //return base.VisitTermino(context);
        }

        public override object VisitSignoFactor([NotNull] tinyParser.SignoFactorContext context)
        {
            if (context.sumaOp()!=null)
            {
                var nodo = Visit(context.factor());
                //ooperacion pendiente

                if (typeof(ASTNode).IsInstanceOfType(nodo))
                {
                    var r = new ASTNode()
                    {
                        Id = node_id++,
                        Label = context.sumaOp().GetText()
                    };
                    r.Children.Add((ASTNode)nodo);
                    return r;
                }
                else
                {

                    return !(bool)nodo;
                }
            }
            else
            {
                return Visit(context.factor());

            }
            //return base.VisitSignoFactor(context);
        }
        public override object VisitFactor([NotNull] tinyParser.FactorContext context)
        {
            //aqui hacer el casteo

            if (context.b_expresion() != null)
            {
                return Visit(context.b_expresion());
            }
            else
            {
                if (context.Number() != null)
                {
                    var numberText = context.Number().GetText();

                    if (numberText.Contains('.'))
                    {
                        return Convert.ToDouble(numberText);
                    }
                    else
                    {
                        return Convert.ToInt32(numberText);
                    }
                }
                if (context.Identifier() != null)
                {
                    return context.Identifier().GetText();
                }
            }
            return null;

            //return base.VisitFactor(context);
        }
        public override object VisitTerminal(ITerminalNode node)
        {
            /*aSTNodes.Push((ASTNode)node);*/
            return base.VisitTerminal(node);
        }
    }
}

