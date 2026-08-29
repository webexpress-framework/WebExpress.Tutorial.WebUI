using System;
using WebExpress.WebIndex;

namespace WebExpress.Tutorial.WebUI.Model
{
    /// <summary>
    /// Represents a document from the Monkey Island archive, used by the file view demo.
    /// </summary>
    public class Document : IIndexItem
    {
        /// <summary>
        /// The unique identifier of the document.
        /// </summary>
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// The file name of the document, including its extension. Several
        /// documents may share a name; they are then versions of one file.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The version of the document among the documents of the same name.
        /// </summary>
        public int Version { get; set; } = 1;

        /// <summary>
        /// The size of the document in bytes.
        /// </summary>
        public long Size { get; set; }

        /// <summary>
        /// The date the document was filed.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// The description of the document, which the file view demo edits in place.
        /// </summary>
        public string Description { get; set; }
    }
}
