// ReSharper disable once CheckNamespace
namespace FluentAssertions.Common
{
  internal class AppSettingsConfigurationStore : IConfigurationStore
  {
    public string GetSetting(string name)
    {
      return ""; // TODO: This is basically the same as the NullConfigurationProvider. Let's see, if we need to wire this up in Unity somehow.
    }
  }
}
