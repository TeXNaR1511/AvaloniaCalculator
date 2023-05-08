using AvaloniaCalculator.ViewModels;
using ReactiveUI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
//using Microsoft.CodeAnalysis.CSharp.Scripting;
using Avalonia.FreeDesktop.DBusIme;
using Avalonia.Markup.Xaml.Templates;

namespace AvaloniaCalculator
{
    public class Calculator : ViewModelBase
    {
        private string entry = "0";
        
        public string Entry
        {
            get => entry;
            set => this.RaiseAndSetIfChanged(ref entry, value);
        }

        private string expression = " ";

        public string Expression
        {
            get => expression;
            set => this.RaiseAndSetIfChanged(ref expression, value);
        }

        private string action = "";

        //private bool actFlag = false;


        public Calculator() 
        {
            //System.Diagnostics.Debug.WriteLine(Double.PositiveInfinity);
        }

        ~Calculator() { }

        public void addNumber(string number)
        {
            //System.Diagnostics.Debug.WriteLine(number);
            if (Entry == "0" || action != "")
            {
                Entry = number;
            }
            else if (Expression.Contains('='))
            {
                Entry = number;
                Expression = " ";
            }
            else
            {
                Entry += number;
            }
            action = "";
            //actFlag = false;
        }

        public void clearEntry()
        {
            Entry = "0";
        }

        public void clearExpression()
        {
            Expression = " ";
            clearEntry();
        }

        public void backSpace()
        {
            if (Entry.Length > 1)
            {
                Entry = Entry.Remove(Entry.Length - 1);
            }
            else
            {
                Entry = "0";
            }
        }

        public string parseMathExp(string exp)
        {
            //there should be hand-written parser, but for now c# parser
            //return CSharpScript.EvaluateAsync<double>(exp).Result;
            exp = exp.Trim();
            bool flag = true;
            if (exp[0] == '-')
            {
                exp = exp.Substring(1);
                flag = false;
            }

            string[] spliting = exp.Split(new char[] { '+', '-', '*', '/' });

            double x = Convert.ToDouble(spliting[0]);
            x = flag ? x : -x;

            if (spliting.Length == 1)
            {
                return x.ToString();
            }

            else
            {
                double y = Convert.ToDouble(spliting[1]);

                double answer = 0;

                if (exp.Contains('+'))
                {
                    answer = x + y;
                }

                if (exp.Contains('-'))
                {
                    answer = x - y;
                }

                if (exp.Contains('*'))
                {
                    answer = x * y;
                }

                if (exp.Contains('/'))
                {
                    if (y == 0)
                    {
                        return "Impossible";//"Dividing by zero is impossible";
                    }
                    else
                    {
                        answer = x / y;
                    }
                }
                return answer.ToString();
            }

            
        }

     

        public void addAction(string act)
        {
            if (action == "")
            {
                //Expression += Entry + act;
                if (Expression == " ")
                {
                    Expression += Entry + act;
                }
                else
                {
                    //System.Diagnostics.Debug.WriteLine(parseMathExp(Expression + Entry));
                    if (!Expression.Contains('='))
                    {
                        var temp = parseMathExp(Expression + Entry);
                        Expression = temp + act;
                        Entry = temp;
                    }
                    else
                    {
                        Expression = Entry + act;
                    }
                    
                }
            }
            else
            {
                Expression = Expression.Remove(Expression.Length - 1);
                Expression += act;
            }
            action = act;
        }

        public string changeExpEnt(string exp, string ent)
        {
            exp = exp.Trim();

            if (exp[0] == '-')
            {
                exp = exp.Substring(1);
            }

            string[] spliting = exp.Split(new char[] { '+', '-', '*', '/' });

            if (spliting.Length == 1)
            {
                return ent;
            }
            else
            {
                spliting[0] = ent;

                char a = '\0';

                if (exp.Contains('+'))
                {
                    a = '+';
                }
                if (exp.Contains('-'))
                {
                    a = '-';
                }
                if (exp.Contains('*'))
                {
                    a = '*';
                }
                if (exp.Contains('/'))
                {
                    a = '/';
                }
                var answer = String.Join(a, spliting);
                return answer.Remove(answer.Length - 1);
            }


        }

        public void Equal()
        {
            if (Entry.Contains("Impossible") || Entry == Double.PositiveInfinity.ToString() || Entry == Double.NegativeInfinity.ToString())
            {
                clearExpression();
            }
            else
            {
                if (!Expression.Contains('='))
                {
                    var temp = parseMathExp(Expression + Entry);
                    Expression += Entry + "=";
                    Entry = temp;
                }
                else
                {
                    var change = changeExpEnt(Expression, Entry);
                    var temp = parseMathExp(change);
                    Expression = change + "=";
                    Entry = temp;
                }
            }
            
        }

        public void addComma()
        {
            if (!Entry.Contains(','))
            {
                Entry += ',';
            }
            if (Expression.Contains('='))
            {
                Expression = " ";
                Entry = "0,";
            }
        }

        public string sqrt(string num)
        {
            double x = Convert.ToDouble(num);
            if (x >= 0)
            {
                return Math.Sqrt(x).ToString();
            }
            else
            {
                return "Impossible";
            }
        }

        public string sqr(string num)
        {
            return Math.Pow(Convert.ToDouble(num), 2).ToString();
        }

        public string inverse(string num) 
        {
            double x = Convert.ToDouble(num);
            if (x != 0)
            {
                return (1 / x).ToString();
            }
            else
            {
                return "Impossible";
            }
        }

        public string negate(string num)
        {
            return (-Convert.ToDouble(num)).ToString();
        }

        public string percent(string num, string basa)
        {
            return (Convert.ToDouble(num) * Convert.ToDouble(basa) / 100).ToString();
        }

        public string initFunc(string a)
        {
            return a;
        }

        delegate string specOperation(string a);

        public void specFunc(string spec)
        {

            specOperation temp = initFunc;

            if (spec == "+/-")
            {
                temp = negate;
            }
            if (spec == "sqrt")
            {
                temp = sqrt;
            }
            if (spec == "^2")
            {
                temp = sqr;
            }
            if (spec == "1/x")
            {
                temp = inverse;
            }

            if (Expression == " " || Expression.Contains('=') || Expression.Split(new char[] { '+', '-', '*', '/' }).Length == 1 || Expression.Trim()[0] == '-')
            {
                Expression = Entry;
                Entry = temp(Entry);
                //System.Diagnostics.Debug.WriteLine("if");
            }
            else if(Expression.Contains('+') || Expression.Contains('-') || Expression.Contains('*') || Expression.Contains('/'))
            {
                Entry = temp(Entry);
                //System.Diagnostics.Debug.WriteLine("else");
            }
        }

        public void percentFunc()
        {
            if (Expression == " ")
            {
                Entry = percent(Entry, "0");
            }
            else if (Expression.Contains('='))
            {
                //System.Diagnostics.Debug.WriteLine(Entry);
                //System.Diagnostics.Debug.WriteLine(parseMathExp(Expression.Remove(Expression.Length - 1)));
                Entry = percent(Entry, parseMathExp(Expression.Remove(Expression.Length - 1)));
            }
            else
            {
                Entry = percent(Entry, Expression.Split(new char[] { '+', '-', '*', '/' })[0]);
            }
        }
    }
}
