using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace NExtents.Tests.String.Extensions
{
  [TestClass]
  public class TrimTests
  {
    [TestMethod]
    [DataRow("...aBc...", "aBc...", "...")]
    [DataRow("x...aBc...", "x...aBc...", "...")]
    [DataRow("aBc", "aBc", "...")]
    [DataRow("   aBc   ", "   aBc   ", "...")]
    public void Extension_Should_Trim_At_Start_With_String(string target, string expected, string data)
    {
      string actual = target.TrimStart(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "...aBc", "...")]
    [DataRow("...aBc...x", "...aBc...x", "...")]
    [DataRow("aBc", "aBc", "...")]
    [DataRow("   aBc   ", "   aBc   ", "...")]
    public void Extension_Should_Trim_At_End_With_String(string target, string expected, string data)
    {
      string actual = target.TrimEnd(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "aBc", "...")]
    [DataRow("x...aBc...", "x...aBc", "...")]
    [DataRow("...aBc...x", "aBc...x", "...")]
    [DataRow("aBc", "aBc", "...")]
    [DataRow("   aBc   ", "   aBc   ", "...")]
    public void Extension_Should_Trim_With_String(string target, string expected, string data)
    {
      string actual = target.Trim(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "aBc...", new string[]{"...", "*"})]
    [DataRow("*...aBc...", "aBc...", new string[] { "...", "*" })]
    [DataRow("...*aBc...", "aBc...", new string[] { "...", "*" })]
    [DataRow("x...aBc...x", "x...aBc...x", new string[] { "...", "*" })]
    [DataRow("x*aBc*x", "x*aBc*x", new string[] { "...", "*" })]
    [DataRow("aBc", "aBc", new string[] { "...", "*" })]
    [DataRow("   aBc   ", "   aBc   ", new string[] { "...", "*" })]
    public void Extension_Should_Trim_At_Start_With_String_Enumeration(string target, string expected, string[] data)
    {
      string actual = target.TrimStart(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "...aBc", new string[] { "...", "*" })]
    [DataRow("...aBc...*", "...aBc", new string[] { "...", "*" })]
    [DataRow("...aBc*...", "...aBc", new string[] { "...", "*" })]
    [DataRow("x...aBc...x", "x...aBc...x", new string[] { "...", "*" })]
    [DataRow("x*aBc*x", "x*aBc*x", new string[] { "...", "*" })]
    [DataRow("aBc", "aBc", new string[] { "...", "*" })]
    [DataRow("   aBc   ", "   aBc   ", new string[] { "...", "*" })]
    public void Extension_Should_Trim_At_End_With_String_Enumeration(string target, string expected, string[] data)
    {
      string actual = target.TrimEnd(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "aBc", new string[] { "...", "*" })]
    [DataRow("...aBc...*", "aBc", new string[] { "...", "*" })]
    [DataRow("...aBc*...", "aBc", new string[] { "...", "*" })]
    [DataRow("x...aBc...x", "x...aBc...x", new string[] { "...", "*" })]
    [DataRow("x*aBc*x", "x*aBc*x", new string[] { "...", "*" })]
    [DataRow("aBc", "aBc", new string[] { "...", "*" })]
    [DataRow("   aBc   ", "   aBc   ", new string[] { "...", "*" })]
    public void Extension_Should_Trim_With_String_Enumeration(string target, string expected, string[] data)
    {
      string actual = target.Trim(data);

      Assert.AreEqual(expected, actual);
    }


    [TestMethod]
    [DataRow("...aBc...", "aBc...", new char[] { '.', '*' })]
    [DataRow("***aBc...", "aBc...", new char[] { '.', '*' })]
    [DataRow("...aBc...*", "aBc...*", new char[] { '.', '*' })]
    [DataRow("*.*aBc*.*.", "aBc*.*.", new char[] { '.', '*' })]
    [DataRow(".*.aBc*.*.", "aBc*.*.", new char[] { '.', '*' })]
    [DataRow("x...aBc...x", "x...aBc...x", new char[] { '.', '*' })]
    [DataRow("x*aBc*x", "x*aBc*x", new char[] { '.', '*' })]
    [DataRow("aBc", "aBc", new char[] { '.', '*' })]
    [DataRow("   aBc   ", "   aBc   ", new char[] { '.', '*' })]
    public void Extension_Should_Trim_At_Start_With_Char_Enumeration(string target, string expected, char[] data)
    {
      string actual = target.TrimStart(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "...aBc", new char[] { '.', '*' })]
    [DataRow("...aBc***", "...aBc", new char[] { '.', '*' })]
    [DataRow("*...aBc...*", "*...aBc", new char[] { '.', '*' })]
    [DataRow("*.*aBc*.*.", "*.*aBc", new char[] { '.', '*' })]
    [DataRow(".*.aBc*.*.", ".*.aBc", new char[] { '.', '*' })]
    [DataRow("x...aBc...x", "x...aBc...x", new char[] { '.', '*' })]
    [DataRow("x*aBc*x", "x*aBc*x", new char[] { '.', '*' })]
    [DataRow("aBc", "aBc", new char[] { '.', '*' })]
    [DataRow("   aBc   ", "   aBc   ", new char[] { '.', '*' })]
    public void Extension_Should_Trim_At_End_With_Char_Enumeration(string target, string expected, char[] data)
    {
      string actual = target.TrimEnd(data);

      Assert.AreEqual(expected, actual);
    }

    [TestMethod]
    [DataRow("...aBc...", "aBc", new char[] { '.', '*' })]
    [DataRow("...aBc***", "aBc", new char[] { '.', '*' })]
    [DataRow("*...aBc...", "aBc", new char[] { '.', '*' })]
    [DataRow("*.*aBc*.*.", "aBc", new char[] { '.', '*' })]
    [DataRow(".*.aBc*.*.", "aBc", new char[] { '.', '*' })]
    [DataRow("x...aBc...x", "x...aBc...x", new char[] { '.', '*' })]
    [DataRow("x*aBc*x", "x*aBc*x", new char[] { '.', '*' })]
    [DataRow("aBc", "aBc", new char[] { '.', '*' })]
    [DataRow("   aBc   ", "   aBc   ", new char[] { '.', '*' })]
    public void Extension_Should_Trim_With_Char_Enumeration(string target, string expected, char[] data)
    {
      string actual = target.Trim(data);

      Assert.AreEqual(expected, actual);
    }
  }
}
