using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace JavaVersion.Test
{
  public partial class JdkVersionTest
  {
    [TestCategory("IsValid")]
    [TestMethod]
    public void 妥当なバージョン番号ならtrueを返す()
    {
      JdkVersion.IsValid("JDK10u40").Is(true);
    }

    [TestCategory("IsValid")]
    [TestMethod]
    public void JDKで始まらないならfalseを返す()
    {
      JdkVersion.IsValid("hoge").Is(false);
    }

    [TestCategory("IsValid")]
    [TestMethod]
    public void familyNumberが数値でないならfalseを返す()
    {
      JdkVersion.IsValid("JDKxu40").Is(false);
    }

    [TestCategory("IsValid")]
    [TestMethod]
    public void familyNumberとupdateNumberの区切りがuでないならfalseを返す()
    {
      JdkVersion.IsValid("JDK7x40").Is(false);
    }

    [TestCategory("IsValid")]
    [TestMethod]
    public void updateNumberが数値でないならfalseを返す()
    {
      JdkVersion.IsValid("JDK7u9x").Is(false);
    }

    [TestCategory("IsValid")]
    [TestMethod]
    public void familyNumberが0ならfalseを返す()
    {
      JdkVersion.IsValid("JDK00u40").Is(false);
    }

    [TestCategory("IsValid")]
    [TestMethod]
    public void updateNumberが0ならtrueを返す()
    {
      JdkVersion.IsValid("JDK7u00").Is(true);
    }
  }
}
