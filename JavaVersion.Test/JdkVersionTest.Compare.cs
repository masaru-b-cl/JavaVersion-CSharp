using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace JavaVersion.Test
{
  public partial class JdkVersionTest
  {
    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u40よりJDK7u51の方が大きい()
    {
      var u40 = JdkVersion.Parse("JDK7u40");
      var u51 = JdkVersion.Parse("JDK7u51");
      (u40.CompareTo(u51) < 0).Is(true);
    }

    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u40よりJDK7u51の方が大きいはtrue()
    {
      var u40 = JdkVersion.Parse("JDK7u40");
      var u51 = JdkVersion.Parse("JDK7u51");
      (u40 < u51).Is(true);
    }

    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u51よりJDK7u40の方が大きいはfalse()
    {
      var u40 = JdkVersion.Parse("JDK7u40");
      var u51 = JdkVersion.Parse("JDK7u51");
      (u51 < u40).Is(false);
    }

    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u51よりJDK7u40の方が小さいはtrue()
    {
      var u40 = JdkVersion.Parse("JDK7u40");
      var u51 = JdkVersion.Parse("JDK7u51");
      (u51 > u40).Is(true);
    }

    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u40よりJDK7u51の方が小さいはfalse()
    {
      var u40 = JdkVersion.Parse("JDK7u40");
      var u51 = JdkVersion.Parse("JDK7u51");
      (u40 > u51).Is(false);
    }

    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u40よりJDK8u0の方が大きいはtrue()
    {
      var u40 = JdkVersion.Parse("JDK7u40");
      var jdk8u0 = JdkVersion.Parse("JDK8u0");
      (u40 < jdk8u0).Is(true);
    }

    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u40とJDKu40が等しい()
    {
      var u40_a = JdkVersion.Parse("JDK7u40");
      var u40_b = JdkVersion.Parse("JDK7u40");
      u40_a.Equals(u40_b).Is(true);
    }
    [TestCategory("Compare")]
    [TestMethod]
    public void JDK7u40とJDKu40がで等しい_演算子オーバーロード()
    {
      var u40_a = JdkVersion.Parse("JDK7u40");
      var u40_b = JdkVersion.Parse("JDK7u40");
      (u40_a == u40_b).Is(true);
    }
  }
}
