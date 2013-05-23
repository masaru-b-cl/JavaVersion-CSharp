using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JavaVersion
{
  public class JdkVersion
  {
    public int FamilyNumber { get; private set; }
    public int UpdateNumber { get; private set; }

    public static bool IsValid(string version)
    {
      var regex = new Regex("^JDK(?<familyVersion>[0-9]+?)u(?<updateVersion>[0-9]+?)$");
      var match = regex.Match(version);
      if (!match.Success)
      {
        return false;
      }

      var familyVersion = match.Groups["familyVersion"].Value;
      int oFamilyVersion;
      if (!Int32.TryParse(familyVersion, out oFamilyVersion) || oFamilyVersion == 0)
      {
        return false;
      }

      var updateVersion = match.Groups["updateVersion"].Value;
      int oUpdateVersion;
      if (!Int32.TryParse(updateVersion, out oUpdateVersion) || oUpdateVersion == 0)
      {
        return false;
      }

      return true;
    }

    public static JdkVersion Parse(string version)
    {
      var regex = new Regex("^JDK(?<familyVersion>[0-9]+?)u(?<updateVersion>[0-9]+?)$");
      var match = regex.Match(version);
      var familyVersion = match.Groups["familyVersion"].Value;
      int oFamilyVersion;
      if (!Int32.TryParse(familyVersion, out oFamilyVersion) || oFamilyVersion == 0)
      {
        throw new ArgumentException();
      }
      var updateVersion = match.Groups["updateVersion"].Value;
      int oUpdateVersion;
      if (!Int32.TryParse(updateVersion, out oUpdateVersion) || oUpdateVersion == 0)
      {
        throw new ArgumentException();
      }
      return new JdkVersion { FamilyNumber = oFamilyVersion, UpdateNumber = oUpdateVersion };
    }
  }
}
