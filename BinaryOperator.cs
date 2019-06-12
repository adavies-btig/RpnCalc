namespace RpnCalc
{
  using System;
  using System.Collections.Generic;


  internal abstract class BinaryOperator : OpBase
  {
    public override void Calculate(Stack<OpBase> stack, int level)
    {
      if(stack.Count < 3) throw new InvalidOperationException("Bad stack");
      var op = (BinaryOperator)stack.Pop();
      stack.Peek().Calculate(stack, level + 1);
      var rightOperand = (Operand)stack.Pop();
      stack.Peek().Calculate(stack, level + 1);
      var leftOperand = (Operand)stack.Pop();
      var result = op.DoOperation(leftOperand, rightOperand, level);
      stack.Push(result);
    }


    public abstract Operand DoOperation(Operand left, Operand right, int level);
  }
}