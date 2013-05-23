using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaVersion.Test
{
  public partial class JdkVersionTest
  {
    [TestCategory("Parse")]
    [TestMethod]
    public void Validなバージョンを渡すとバージョンオブジェクトを返す()
    {
      var version = JdkVersion.Parse("JDK7u40");
      version.IsInstanceOf<JdkVersion>();
      version.FamilyNumber.Is(7);
      version.UpdateNumber.Is(40);
    }

    [TestCategory("Parse")]
    [TestMethod]
    public void Invalidなバージョンを渡すと例外を返す()
    {
      AssertEx.Throws<ArgumentException>(() => JdkVersion.Parse("JDK7u9x"));
    }
  }
}
