using Antlr4.Runtime.Misc;
using CompilerCLI.ParserTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CompilerCLI.GenerateCode
{
    public class IntermediateGenerator
    {
        public int tempCounter { get; set; }
        public int labelCounter { get; set; }
        public ASTNode parent { get; set; }
        public Dictionary<string, ASTNode> Labels { get; set; }
        public string Intermediate_code { get; set; }
        private string tmp_r = "";
        private string tmp_l = "";
        private string tmp_type = "";
        private int lastTemp = 0;
        private Stack<int> temps_stack = new Stack<int>();
        private Stack<int> labels_stack = new Stack<int>();
        private bool isFirstBlock = true;
        private string End_Label = "";
        private int blockLabel = 0;
        private int lastLabelN = 0;


        public IntermediateGenerator(ASTNode parent)
        {
            tempCounter = 0;
            labelCounter = 1;
            this.parent = parent;
            Labels = new Dictionary<string, ASTNode>();
            Intermediate_code = "";
        }
        private void emitOperation(ASTNode it)
        {
            if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count == 0)
            {
                Intermediate_code += "\n";
                temps_stack.Push(tempCounter);
                Intermediate_code += "T" + (tempCounter++) + " = ";
                Intermediate_code += it.Children[0].Label + "";
                Intermediate_code += " " + it.Label + " ";
                Intermediate_code += it.Children[1].Label + "";
                Intermediate_code += "\n";


                return;
            }
            else if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count > 0)
            {
                genCode(it);
                Intermediate_code += "\n";
                temps_stack.Push(tempCounter);
                Intermediate_code += "T" + (tempCounter++) + " = ";
                Intermediate_code += it.Children[0].Label + " ";
                Intermediate_code += " "+it.Label+" ";
                Intermediate_code += "T" + temps_stack.Pop();
                Intermediate_code += "\n";

                return;
            }
            else if (it.Children[0].Children.Count > 0 && it.Children[1].Children.Count == 0)
            {
                
                temps_stack.Push(tempCounter);
                Intermediate_code += "\n";
                Intermediate_code += "T" + (tempCounter++) + " = ";
                Intermediate_code += it.Children[1].Label + " ";
                Intermediate_code += " + ";
                genCode(it);
                Intermediate_code += "\n";


                return;
            }
            genCode(it);
            Intermediate_code += "\n";
            lastTemp = tempCounter;
            Intermediate_code += "T" + (tempCounter++) + " = " + "T"+ temps_stack.Pop() + " + " + "T" + temps_stack.Pop();
            temps_stack.Push(lastTemp);
            Intermediate_code += "\n";
        }


        public void emitConditionalIf(ASTNode it, int? blockLabel, int? lastlabelN)
        {
            if (it.Children.Count==0)
            {
                Intermediate_code += "if(";
                Intermediate_code += it.Label + "== 1";
                Intermediate_code += $") goto L{blockLabel} \n goto L{lastlabelN}";
            }
            else if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count == 0)
            {
                if (labels_stack.Count == 0)
                {
                    Intermediate_code += "\n";
                    labels_stack.Push(labelCounter);
                    Intermediate_code += "L" + labelCounter++ + ": ";
                }
                if (blockLabel != null && lastlabelN!=null)
                {
                    Intermediate_code += "if ( ";
                    emitOperationalCondition(it);
                    Intermediate_code += ") goto L" + blockLabel;
                    Intermediate_code += "\n";
                    labels_stack.Push(labelCounter++);
                    Intermediate_code += "goto L" + lastlabelN + "\n";
                }
                else
                {
                    if (labels_stack.Count < 2)
                    {
                        newLabel();
                        newLabelPush();
                    }
                    var blockif = labels_stack.Pop();
                    //labels_stack.Push(labelCounter++);
                    Intermediate_code += "if ( ";
                    emitOperationalCondition(it);
                    Intermediate_code += ") goto L" + blockif;
                    Intermediate_code += "\n";
                    var ifMark = labels_stack.Pop();
                    var else_goto = labels_stack.Pop();
                    labels_stack.Push(ifMark);
                    labels_stack.Push(else_goto);
                    labels_stack.Push(blockif);
                    Intermediate_code += "goto L" + else_goto + "\n";

                }


                return;
            }
            else if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count > 0)
            {
                

                return;
            }
            else if (it.Children[0].Children.Count > 0 && it.Children[1].Children.Count == 0)
            {

                return;
            }
            else
            {
                if (it.Label != "and" && it.Label != "or")
                {

                }
                else
                {
                    if (labels_stack.Count == 0)
                    {
                        Intermediate_code += "\n";
                        labels_stack.Push(labelCounter);
                        Intermediate_code += "L" + labelCounter++ + ": ";
                    }
                    labels_stack.Push(labelCounter++);
                    Intermediate_code += "if ( ";
                    emitOperationalCondition(it.Children[0]);
                    var secondIf = labels_stack.Pop();
                    Intermediate_code += ") goto L" + secondIf;
                    Intermediate_code += "\n";
                    labels_stack.Push(labelCounter++);
                    var else_goto = labels_stack.Peek();
                    Intermediate_code += "goto L" + else_goto + "\n";
                    Intermediate_code += "L" + secondIf + ": ";
                    labels_stack.Push(labelCounter++);
                    Intermediate_code += "if ( ";
                    emitOperationalCondition(it.Children[1]);
                    Intermediate_code += ") goto L" + labels_stack.Peek();
                    Intermediate_code += "\n";
                    Intermediate_code += "goto L" + else_goto + "\n";
                }
                
               

            }
        }

        public void emitOperationalCondition(ASTNode it)
        {
            if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count == 0)
            {
                Intermediate_code += it.Children[0].Label + " " + it.Label + " " + it.Children[1].Label;
                return;
            }
            else if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count > 0)
            {

                return;
            }
            else if (it.Children[0].Children.Count > 0 && it.Children[1].Children.Count == 0)
            {

                return;
            }
            else
            {
                return;
            }

        }

        public void genCode(ASTNode T)
        {
            if (T != null)
            {
                if (T.Label=="program")
                {
                    End_Label = "L" + labelCounter +": ";
                    labels_stack.Push(labelCounter);
                    labelCounter++;
                }
                if (T.Children.Count > 0)
                {
                    foreach (var it in T.Children)
                    {
                        if (it != null)
                        {

                            getSign(it);
                        }
                    }
                }
                else
                {
                    getSign(T);
                }
                if (T.Label == "program")
                {
                    Intermediate_code += "\n" + End_Label;
                }
            }
            return;
        }
        private void newLabel()
        {
            Intermediate_code += $"\nL{labelCounter}: ";
            labels_stack.Push(labelCounter);
            labelCounter++;
        }
        private void newLabelPush()
        {
            labels_stack.Push(labelCounter);
            labelCounter++;
        }
        public void getSign(ASTNode it)
        {
            switch (it.Label)
            {
                case "program":
                    End_Label = "L" + labelCounter;
                    labels_stack.Push(labelCounter);
                    labelCounter++;
                    genCode(it);
                    if (labels_stack.Count == 0)
                    {
                        Intermediate_code += "\n" + End_Label;

                    }
                    break;
                case "int":
                case "float":
                case "bool":
                    tmp_type = it.Label;
                    genCode(it);
                    tmp_type = null;
                    break;
                case "=":
                    if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count == 0)
                    {
                        Intermediate_code += $"{it.Children[0].Label} = {it.Children[1].Label} \n";

                        break;

                    }
                    else if (it.Children[0].Children.Count == 0 && it.Children[1].Children.Count > 0)
                    {
                        getSign(it.Children[1]);
                        Intermediate_code += it.Children[0].Label + " = T" + temps_stack.Pop() + "\n";

                        break;

                    }
                    else if (it.Children[0].Children.Count > 0 && it.Children[1].Children.Count == 0)
                    {

                        break;

                    }
                    else
                    {
                        

                        break;

                    }
                case "write":
                case "read":
                    Intermediate_code += it.Label + " : ";
                    genCode(it);
                    if (temps_stack.Count == 1)
                    {
                        Intermediate_code += "T" + temps_stack.Pop();
                    }
                    Intermediate_code += "\n";
                    break;
                case "+":
                case "-":
                case "*":
                case "/":
                    emitOperation(it);
                    break;
                case "Bloque":
                    if (labels_stack.Count == 0)
                    {
                        Intermediate_code += "\nL" + labelCounter + ": \n";
                        labels_stack.Push(labelCounter);
                        labelCounter++;
                    }
                    else
                    {
                        Intermediate_code += "\nL" + labels_stack.Pop() + ": \n";
                    }
                    genCode(it);
                    
                    break;
                case "If statment":
                    
                    if (labels_stack.Count == 0)
                    {
                        labels_stack.Push(labelCounter);
                        labelCounter++;
                    }
                    /*else
                    {
                        newLabelPush();
                    }*/
                    getSign(it.Children[0]);
                    getSign(it.Children[1]);

                    break;
                case "if":
                    getSign(it.Children[0]);
                    getSign(it.Children[1]);
                    int o = 0;
                    if (labels_stack.Count > 0)
                    {
                        var intr = labels_stack.Pop();
                        newLabelPush();
                        o = labels_stack.Peek();
                        labels_stack.Push(intr);
                        Intermediate_code += "goto L" + o + ": \n";


                    }

                    break;
                case "else":
                    genCode(it);
                    break;
                case "fi":
                    Intermediate_code += "\nL" + labels_stack.Pop() + ": \n";
                    break;
                case "do - until":
                    newLabel();
                    blockLabel = labels_stack.Peek();
                    genCode(it.Children[0]);
                    labels_stack.Pop();
                    lastLabelN = labels_stack.Pop();
                    newLabel();
                    //Tiene que ir a la funcion de condicionales
                    emitConditionalIf(it.Children[1], blockLabel, lastLabelN);
                    break;
                case "while":
                    //send conditional
                    // newLabel(); //condition label
                    /* if (labels_stack.Count == 1)
                     {

                         lastLabelN = labels_stack.Peek();
                         newLabel();
                     }*/
                    emitConditionalIf(it.Children[0], null, null);
                    Intermediate_code += "\nL" + labels_stack.Pop() + ": \n";
                    //labels_stack.Pop();
                    lastLabelN = labels_stack.Pop();
                    genCode(it.Children[1]);
                    Intermediate_code += "\nL" + lastLabelN + ": \n";
                    //call bloque

                    break;
                case "or":
                    emitConditionalIf(it,null, null);
                    break;
                case "and":
                    emitConditionalIf(it, null, null);
                    break;

                case ">":
                case "<":
                case ">=":
                case "<=":
                case "==":
                case "!=":
                    emitConditionalIf(it, null, null);
                    //Intermediate_code += it.Children[0].Label + " " + it.Label + " " + it.Children[1].Label;
                    break;
                default:

                    if (!string.IsNullOrEmpty(tmp_type))
                    {
                        Intermediate_code += tmp_type + " ";
                        Intermediate_code += " " + it.Label + " ";
                        Intermediate_code += "\n";
                        if (it.Children.Count > 0)
                        {
                            genCode(it);
                        }
                        break;
                    }

                    Intermediate_code += it.Label + " ";
                    break;
            }

        }
    }
}
