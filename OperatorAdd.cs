namespace RpnCalc
{
  internal class OperatorAdd : BinaryOperator
  {
    public override Operand DoOperation(Operand left, Operand right, int level)
    {
      return new Operand(left.Value + right.Value);
    }
  }
}