namespace RpnCalc
{
  using System;
  using System.Collections.Generic;


  internal class Expression
  {
    private readonly Stack<OpBase> _stack;

    public Expression()
    {
      _stack = new Stack<OpBase>();
    }
  }
}
