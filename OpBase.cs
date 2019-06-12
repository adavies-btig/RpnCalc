namespace RpnCalc
{
  using System.Collections.Generic;


  internal abstract class OpBase
  {
    public abstract void Calculate(Stack<OpBase> stack, int level);
  }
}