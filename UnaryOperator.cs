namespace RpnCalc
{
  using System;
  using System.Collections.Generic;


  internal abstract class UnaryOperator : OpBase
  {
    public override void Calculate(Stack<OpBase> stack, int level)
    {
      if(stack.Count < 2) throw new InvalidOperationException("Bad stack");
      var op = (UnaryOperator)stack.Pop();
      stack.Peek().Calculate(stack, level + 1);
      var operand = (Operand)stack.Pop();
      var result = op.DoOperation(operand, level);
      stack.Push(result);
    }


    public abstract Operand DoOperation(Operand operand, int level);
  }
}