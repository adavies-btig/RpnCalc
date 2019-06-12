namespace RpnCalc
{
  internal enum OpType
  {
    Operand,            // Literal numeric value, e.g. 3.14159
    OperatorAdd,        // +
    OperatorSubtract,   // -
    OperatorMultiply,   // *
    OperatorDivide,     // /
    OperatorIncrement,  // ++
    OperatorDecrement,  // --
    Other
  }
}