namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Persists the appearance a visitor chose, one record per owner.
    /// </summary>
    /// <remarks>
    /// The shape is that of a table row - owner as key, one nullable column per choice - so a
    /// database implementation maps it one to one, for example
    /// <c>Appearance(Owner PRIMARY KEY, ThemeId NULL, IconSetId NULL, ColorScheme NULL, ChangedAt)</c>. The
    /// tutorial keeps the records in memory (<see cref="MemoryAppearanceStore"/>); swapping
    /// <see cref="ThemeStore.Store"/> for a database implementation changes nothing else.
    /// </remarks>
    public interface IAppearanceStore
    {
        /// <summary>
        /// Reads the record of an owner.
        /// </summary>
        /// <param name="owner">The owner key: the identity id, or the client address of an anonymous visitor.</param>
        /// <returns>The stored choices, or <see langword="null"/> when the owner never chose.</returns>
        AppearancePreference Get(string owner);

        /// <summary>
        /// Writes the record of an owner, removing it once it holds no choice any more.
        /// </summary>
        /// <param name="owner">The owner key.</param>
        /// <param name="preference">The complete record; both choices are written together.</param>
        void Save(string owner, AppearancePreference preference);
    }
}
