namespace RpnCalc
{
  internal class OperatorIncrement : UnaryOperator
  {
    public override Operand DoOperation(Operand operand, int level)
    {
      return new Operand(operand.Value + 1);
    }
  }
}