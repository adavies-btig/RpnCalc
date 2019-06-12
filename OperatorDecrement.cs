namespace RpnCalc
{
  internal class OperatorDecrement : UnaryOperator
  {
    public override Operand DoOperation(Operand operand, int level)
    {
      return new Operand(operand.Value - 1);
    }
  }
}