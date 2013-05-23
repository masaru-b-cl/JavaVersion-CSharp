using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Text.RegularExpressions;

namespace JavaVersion.Test
{
  public partial class JdkVersionTest
  {
    [TestCategory("Learning")]
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
