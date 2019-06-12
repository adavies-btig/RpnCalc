namespace RpnCalc
{
  using System;
  using System.Collections.Generic;
  using System.Linq;


  class Program
  {
    static int Main(string[] args)
    {
      Console.WriteLine("Enter q to quit");
      var calc = new RpnCalcStack();
      
      while(true) {
        try {
          PrintStackPrompt(calc);
          var line = Console.ReadLine().Trim();
          if(line == "q") break;
          if(string.IsNullOrEmpty(line)) {
            calc.Clear();
            continue;
          }
          var elements = line.Split(' ');
          foreach(var element in elements) calc.Push(element.Trim());
          calc.Calculate();
        }
        catch(InvalidOperationException) { }
        catch(ArgumentException e) {
          Console.WriteLine(e.Message);
        }
        catch(Exception e) {
          Console.WriteLine(e.Message);
          calc.Clear();
        }
      }

      return 0;
    }


    private static void PrintStackPrompt(Stack<OpBase> stack)
    {
      if(stack.Count > 0) {
        var prompt = "";
        prompt += "[ ";
        var n = 0;
        foreach(var element in stack.Reverse()) {
          if(n > 0) prompt += ", ";
          prompt += $"{((Operand)element).Value}";
          ++n;
        }
        prompt += " ]";
        Console.Write(prompt);
      }
      Console.Write(": ");
    }
  }
}