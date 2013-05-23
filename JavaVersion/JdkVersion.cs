using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace JavaVersion
{
  public struct JdkVersion : IComparable<JdkVersion>, IEquatable<JdkVersion>
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

      var regex = new Regex("^JDK(?<familyNumber>[0-9]+?)u(?<updateNumber>[0-9]+?)$");
      var match = regex.Match(version);
      if (!match.Success)
      {
        return false;
      }

      var familyNumber = match.Groups["familyNumber"].Value;
      int oFamilyNumber;
      if (!Int32.TryParse(familyNumber, out oFamilyNumber) || oFamilyNumber <= 0)
      {
        return false;
      }

      var updateNumber = match.Groups["updateNumber"].Value;
      int oUpdateNumber;
      if (!Int32.TryParse(updateNumber, out oUpdateNumber) || oUpdateNumber < 0)
      {
        return false;
      }

      oJdkVersion = new JdkVersion(oFamilyNumber, oUpdateNumber);

      return true;
    }

    public int CompareTo(JdkVersion other)
    {
      var resultOfFamilyNumber = this.familyNumber.CompareTo(other.familyNumber);
      if (resultOfFamilyNumber != 0)
      {
        return resultOfFamilyNumber;
      }
      return this.updateNumber.CompareTo(other.updateNumber);
    }

    public static bool operator <(JdkVersion a, JdkVersion b)
    {
      return a.CompareTo(b) < 0;
    }

    public static bool operator >(JdkVersion a, JdkVersion b)
    {
      return a.CompareTo(b) > 0; ;
    }

    public override bool Equals(object other)
    {
      if (other == null)
      {
        return false;
      }

      if (other is JdkVersion)
      {
        var otherJdkVersion = (JdkVersion)other;
        return this.Equals(otherJdkVersion);
      }
      else
      {
        return false;
      }
    }

    public bool Equals(JdkVersion other)
    {
      return this.CompareTo(other) == 0;
    }

    public override int GetHashCode()
    {
      return familyNumber ^ updateNumber.GetHashCode();
    }

    public static bool operator ==(JdkVersion a, JdkVersion b)
    {
      return a.Equals(b);
    }
    public static bool operator !=(JdkVersion a, JdkVersion b)
    {
      return !a.Equals(b);
    }
  }
}
