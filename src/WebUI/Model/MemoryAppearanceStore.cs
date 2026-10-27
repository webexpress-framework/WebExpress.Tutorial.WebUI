using System.Collections.Concurrent;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Keeps appearance records in memory, which is enough for the tutorial and loses every
    /// choice on restart - the reason a real application implements
    /// <see cref="IAppearanceStore"/> over its database instead.
    /// </summary>
    public sealed class MemoryAppearanceStore : IAppearanceStore
    {
        private readonly ConcurrentDictionary<string, AppearancePreference> _records = new();

        /// <summary>
        /// Reads the record of an owner.
        /// </summary>
        /// <param name="owner">The owner key.</param>
        /// <returns>The stored choices, or <see langword="null"/>.</returns>
        public AppearancePreference Get(string owner)
        {
            return owner is not null && _records.TryGetValue(owner, out var preference) ? preference : null;
        }

        /// <summary>
        /// Writes the record of an owner, removing it once it holds no choice.
        /// </summary>
        /// <param name="owner">The owner key.</param>
        /// <param name="preference">The complete record.</param>
        public void Save(string owner, AppearancePreference preference)
        {
            if (owner is null)
            {
                return;
            }

            if (preference is null || preference.IsEmpty)
            {
                _records.TryRemove(owner, out _);
            }
            else
            {
                _records[owner] = preference;
            }
        }
    }
}
