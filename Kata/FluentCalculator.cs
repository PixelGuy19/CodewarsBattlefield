using System;
using System.Data;

namespace CodeWarsBattlefield
{
    partial class Program
    {
        public class FluentCalculator
        {
            private string Expression;

            public Value Zero => new Value(this, "0");
            public Value One => new Value(this, "1");
            public Value Two => new Value(this, "2");
            public Value Three => new Value(this, "3");
            public Value Four => new Value(this, "4");
            public Value Five => new Value(this, "5");
            public Value Six => new Value(this, "6");
            public Value Seven => new Value(this, "7");
            public Value Eight => new Value(this, "8");
            public Value Nine => new Value(this, "9");
            public Value Ten => new Value(this, "10");

            public class Member
            {
                protected FluentCalculator MyCalculator;

                protected Member(FluentCalculator Calculator, string Value)
                {
                    MyCalculator = Calculator;
                    MyCalculator.Expression += Value;
                }
            }
            public class Value : Member
            {
                public double Result()
                {
                    return MyCalculator.Result();
                }

                public static implicit operator double(Value Value)
                {
                    return Value.MyCalculator.Result();
                }

                public Value(FluentCalculator Calculator, string Value) : base(Calculator, Value)
                {
                }

                public Operator Plus => new Operator(MyCalculator, "+");
                public Operator Minus => new Operator(MyCalculator, "-");
                public Operator Times => new Operator(MyCalculator, "*");
                public Operator DividedBy => new Operator(MyCalculator, "/");
            }
            public class Operator : Value
            {
                public Operator(FluentCalculator Calculator, string Value) : base(Calculator, Value)
                {
                }
                
                public Value Zero => new Value(MyCalculator, "0");
                public Value One => new Value(MyCalculator, "1");
                public Value Two => new Value(MyCalculator, "2");
                public Value Three => new Value(MyCalculator, "3");
                public Value Four => new Value(MyCalculator, "4");
                public Value Five => new Value(MyCalculator, "5");
                public Value Six => new Value(MyCalculator, "6");
                public Value Seven => new Value(MyCalculator, "7");
                public Value Eight => new Value(MyCalculator, "8");
                public Value Nine => new Value(MyCalculator, "9");
                public Value Ten => new Value(MyCalculator, "10");
            }

            double Result()
            {
                double Result = Convert.ToDouble(new DataTable().Compute(Expression, ""));
                Expression = string.Empty;
                return Result;
            }
        }
    }
}