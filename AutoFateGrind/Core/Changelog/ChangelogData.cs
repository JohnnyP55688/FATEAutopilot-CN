using System;
using AutoFateGrind.Core.Localization;

namespace AutoFateGrind.Core.Changelog;

internal static class ChangelogData
{
    public static readonly ChangelogEntry[] Entries = new ChangelogEntry[]
    {
        new ChangelogEntry("2.22.0.2", "2026-11-16", L.Changelog.ReleaseCN22202)
    };

    public static string LatestVersion => Entries[0].Version;

    public static int UnseenCount(string lastSeenVersion)
    {
        for (var i = 0; i < Entries.Length; i++)
        {
            if (string.Equals(Entries[i].Version, lastSeenVersion, StringComparison.Ordinal))
            {
                return i;
            }
        }
        return Entries.Length;
    }
}
