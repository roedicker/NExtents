using System;
using System.Collections.Generic;
using System.Linq;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NExtents.Tests.String.Extensions
{
  [TestClass]
  public class TokenizeTests
  {
    [TestMethod]
    public void Extension_Should_Tokenize_Separated_Text()
    {
      string data = "-a: b /c --d efg";
      string[] expected = new string[] { "-a:", "b", "/c", "--d", "efg" };
      IList<string> actual = data.Tokenize();

      Assert.IsTrue(expected.SequenceEqual(actual), "Result is not as expected");
    }

    [TestMethod]
    public void Extension_Should_Tokenize_Separated_Quoted_Text()
    {
      string data = @"-a:b /c --d ""efg hij""";
      string[] expected = new string[] { "-a:b", "/c", "--d", "efg hij" };
      IList<string> actual = data.Tokenize();

      Assert.IsTrue(expected.SequenceEqual(actual), "Result is not as expected");
    }

    [TestMethod]
    public void Extension_Should_Tokenize_Condensed_Quoted_Text()
    {
      string data = @"-a:""b #1"" /c --d=""efg hij"" ""/k : l mn o""";
      string[] expected = new string[] { "-a:b #1", "/c", "--d=efg hij", "/k : l mn o" };
      IList<string> actual = data.Tokenize();

      Assert.IsTrue(expected.SequenceEqual(actual), "Result is not as expected");
    }
  }
}
