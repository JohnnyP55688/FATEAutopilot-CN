using clib.Utils;
using Lumina.Excel.Exceptions;

namespace AutoFateGrind.Core.Game.Fates;

/// <summary>
/// Reads the display name exposed by clib without allowing an unsupported
/// Lumina language (notably Language.None on some CN clients) to stop FATE
/// automation. The name is presentation-only; the FATE id remains stable.
/// </summary>
internal static class FateNames
{
    public static string Of(PublicEvent fate)
    {
        try
        {
            string? name = fate.Name;
            return string.IsNullOrWhiteSpace(name) ? Fallback(fate.Id) : name;
        }
        catch (UnsupportedLanguageException)
        {
            return Fallback(fate.Id);
        }
    }

    private static string Fallback(uint id) => $"FATE #{id}";
}
