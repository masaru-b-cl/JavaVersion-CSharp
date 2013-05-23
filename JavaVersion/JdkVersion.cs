using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JavaVersion
{
  public struct JdkVersion
  {
    private readonly int familyNumber;
    public int FamilyNumber
    {
      get
      {
        return familyNumber;
      }
    }

    private readonly int updateNumber;
    public int UpdateNumber
    {
      get
      {
        return updateNumber;
      }
    }

    public JdkVersion(int familyNumber, int updateNumber)
    {
      this.familyNumber = familyNumber;
      this.updateNumber = updateNumber;
    }

    public static bool IsValid(string version)
    {
      JdkVersion jdkVersion;
      return TryParse(version, out jdkVersion);
    }

    public static JdkVersion Parse(string version)
    {
      JdkVersion jdkVersion;
      if (!TryParse(version, out jdkVersion))
      {
        throw new ArgumentException();
      }
      return jdkVersion;
    }

    private static bool TryParse(string version, out JdkVersion oJdkVersion)
    {
      oJdkVersion = new JdkVersion();

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

      oJdkVersion = new JdkVersion(oFamilyVersion, oUpdateVersion);

      return true;
    }
  }
}
