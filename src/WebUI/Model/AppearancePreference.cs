namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// The appearance choices of one owner, as a store reads and writes them.
    /// </summary>
    /// <remarks>
    /// The choices are independent and optional: a null value means the default applies, so a
    /// record without any choice is the same as no record at all.
    /// </remarks>
    /// <param name="ThemeId">The chosen color theme, or <see langword="null"/> for the application default.</param>
    /// <param name="IconSetId">The chosen icon set, or <see langword="null"/> for the framework drawings.</param>
    /// <param name="ColorScheme">"light" or "dark", or <see langword="null"/> to follow the theme.</param>
    public sealed record AppearancePreference(string ThemeId, string IconSetId, string ColorScheme = null)
    {
        /// <summary>
        /// Gets whether the record holds no choice, so a store can delete it instead of keeping an empty row.
        /// </summary>
        public bool IsEmpty => string.IsNullOrWhiteSpace(ThemeId) && string.IsNullOrWhiteSpace(IconSetId)
            && string.IsNullOrWhiteSpace(ColorScheme);
    }
}
