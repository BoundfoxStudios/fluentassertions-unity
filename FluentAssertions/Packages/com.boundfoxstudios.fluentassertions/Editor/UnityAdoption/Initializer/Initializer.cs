using UnityEditor;
using UnityEngine;

// Thanks to https://forum.unity.com/threads/scripting-define-symbols-access-in-code.174390/#post-3112433
// ReSharper disable once CheckNamespace
namespace FluentAssertions
{
  [InitializeOnLoad]
  public class Initializer
  {
    const string Define = "NETSTANDARD2_0";

    static Initializer()
    {
      AddDefineIfNeeded();
    }

    private static void AddDefineIfNeeded()
    {
      // Get defines.
      var buildTargetGroup = EditorUserBuildSettings.selectedBuildTargetGroup;
      var defines = PlayerSettings.GetScriptingDefineSymbolsForGroup(buildTargetGroup);

      // Append only if not defined already.
      if (!defines.Contains(Define))
      {
        Debug.LogWarning($"Selected build target ({EditorUserBuildSettings.activeBuildTarget}) does not contain <b>{Define}</b> <i>Scripting Define Symbol</i>. " +
                         $"Please add it manually (Edit -> Project Settings -> Player -> Other Settings -> <i>Scripting Define Symbol</i>!");
      }
    }
  }
}
