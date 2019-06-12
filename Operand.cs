namespace RpnCalc
{
  using System.Collections.Generic;


  internal class Operand : OpBase
  {
    private readonly double _value;


    public Operand(double value) { _value = value; }


    public override void Calculate(Stack<OpBase> stack, int level) { }


    public double Value => _value;
  }
}