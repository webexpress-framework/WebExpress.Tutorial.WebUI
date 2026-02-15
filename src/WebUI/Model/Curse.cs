using System;
using WebExpress.WebApp.WebAttribute;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a curse entity for use in the Monkay Ispland system.
    /// </summary>
    public class Curse : IIndexItem
    {
        /// <summary>
        /// Returns or sets the identifier of the curse.
        /// </summary>
        [RestHidden()]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// Returns or sets the name of the curse.
        /// </summary>
        [RestTableColumnName("Name")]
        public string Name { get; set; }

        /// <summary>
        /// Returns or sets the description of the curse.
        /// </summary>
        [RestTableColumnName("Description")]
        public string Description { get; set; }

        /// <summary>
        /// Returns or sets the origin or source of the curse (e.g. Voodoo, Artifact, Myth).
        /// </summary>
        [RestTableColumnName("Origin")]
        public string Origin { get; set; }

        /// <summary>
        /// Returns or sets the effect or consequence of the curse.
        /// </summary>
        [RestTableColumnName("Effect")]
        public string Effect { get; set; }

        /// <summary>
        /// Returns or sets the method to lift or neutralize the curse.
        /// </summary>
        [RestTableColumnName("Cure")]
        public string Cure { get; set; }

        /// <summary>
        /// Returns or sets the context or game part where the curse appears.
        /// </summary>
        [RestTableColumnName("Appears in")]
        public string AppearsIn { get; set; }

        /// <summary>
        /// Returns a string representation of the curse, including its name, origin, effect, and cure.
        /// </summary>
        /// <returns>A formatted string with curse details.</returns>
        public override string ToString()
        {
            return $"Name: {Name}\nOrigin: {Origin}\nEffect: {Effect}\nCure: {Cure}\nAppears in: {AppearsIn}\nDescription: {Description}";
        }
    }
}