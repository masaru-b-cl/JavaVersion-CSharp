using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace JavaVersion.Test
{
  [TestClass]
  public class JdkVersionTest
  {
    [TestMethod]
    public void 妥当なバージョン番号ならtrueを返す()
    {
      JdkVersion.IsValid("JDK10u40").Is(true);
    }

    [TestMethod]
    public void JDKで始まらないならfalseを返す()
    {
      JdkVersion.IsValid("hoge").Is(false);
    }

    [TestMethod]
    public void familyVersionが数値でないならfalseを返す()
    {
      JdkVersion.IsValid("JDKxu40").Is(false);
    }

    [TestMethod]
    public void familyVersionとupdateVersionの区切りがuでないならfalseを返す()
    {
      JdkVersion.IsValid("JDK7x40").Is(false);
    }

    [TestMethod]
    public void updateVersionが数値でないならfalseを返す()
    {
      JdkVersion.IsValid("JDK7u9x").Is(false);
    }

    [TestMethod]
    public void familyVersionが0ならfalseを返す()
    {
      JdkVersion.IsValid("JDK00u40").Is(false);
    }

    [TestMethod]
    public void updateVersionが0ならfalseを返す()
    {
      JdkVersion.IsValid("JDK7u00").Is(false);
    }

    [TestMethod]
    public void 正規表現のグループの実装確認()
    {
      var regex = new Regex("a(?<num>[0-9]+?)b");
      var match = regex.Match("a0b");
      match.Success.Is(true);
      match.Groups["num"].Value.Is("0");
    }
  }
}
