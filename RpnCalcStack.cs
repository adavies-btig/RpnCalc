namespace RpnCalc
{
  using System;
  using System.Collections.Generic;
  using System.Text.RegularExpressions;


  internal class RpnCalcStack : Stack<OpBase>
  {
    public void Push(string s)
    {
      var type = GetOpType(s);
      switch(type) {
      case OpType.Operand:
        Push(new Operand(double.Parse(s)));
        break;

      case OpType.OperatorAdd:
        Push(new OperatorAdd());
        break;

      case OpType.OperatorSubtract:
        Push(new OperatorSubtract());
        break;

      case OpType.OperatorMultiply:
        Push(new OperatorMultiply());
        break;

      case OpType.OperatorDivide:
        Push(new OperatorDivide());
        break;

      case OpType.OperatorIncrement:
        Push(new OperatorIncrement());
        break;

      case OpType.OperatorDecrement:
        Push(new OperatorDecrement());
        break;

      default:
        throw new ArgumentException($"Unknown operator: {s}");
      }
    }

    public void Calculate()
    {
      if(Count == 0) throw new InvalidOperationException("Can't calculate an empty stack");
      Peek().Calculate(this, 0);
      if(Count != 1) throw new InvalidOperationException("Bad stack");
    }


    private OpType GetOpType(string s)
    {
      var regexOperatorAdd = new Regex(@"^\+$");
      var regexOperatorSubtract = new Regex(@"^\-$");
      var regexOperatorMultiply = new Regex(@"^\*$");
      var regexOperatorDivide = new Regex(@"^\/$");
      var regexOperatorIncrement = new Regex(@"^\+\+$");
      var regexOperatorDecrement = new Regex(@"^\-\-$");
      var regexOperand = new Regex(@"^[-+]?\d+(\.\d+)?$");

      if(regexOperatorAdd.Match(s).Success) return OpType.OperatorAdd;
      if(regexOperatorSubtract.Match(s).Success) return OpType.OperatorSubtract;
      if(regexOperatorMultiply.Match(s).Success) return OpType.OperatorMultiply;
      if(regexOperatorDivide.Match(s).Success) return OpType.OperatorDivide;
      if(regexOperatorIncrement.Match(s).Success) return OpType.OperatorIncrement;
      if(regexOperatorDecrement.Match(s).Success) return OpType.OperatorDecrement;
      if(regexOperand.Match(s).Success) return OpType.Operand;
      return OpType.Other;
    }
  }
}