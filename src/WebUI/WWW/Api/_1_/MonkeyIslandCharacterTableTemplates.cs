using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebCore.WebUri;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Demonstrates the "text" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableText : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["Mighty pirate", "Governor of Mêlée Island", "Ghost pirate", "Used-coffin salesman"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Occupation";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateText(true, TypeColorText.Info, "Enter occupation");

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "numeric" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableNumeric : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["42", "7", "13", "99"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Insults known";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateNumeric(true) { Min = 0, Max = 100, Step = 1 };

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "date" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableDate : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["1990-10-15", "1991-12-01", "1997-11-08", "2000-06-22"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "First appearance";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateDate(true);

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "calendar" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableCalendar : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["1990-10-15", "1991-12-01", "1997-11-08", "2000-06-22"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "First appearance";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateCalendar(true);

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "combo" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableCombo : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["pirate", "governor", "ghost", "salesman"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Role";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateCombo(true)
            {
                Items =
                [
                    new RestApiTableColumnTemplateItem() { Id = "pirate", Text = "Pirate" },
                    new RestApiTableColumnTemplateItem() { Id = "governor", Text = "Governor" },
                    new RestApiTableColumnTemplateItem() { Id = "ghost", Text = "Ghost" },
                    new RestApiTableColumnTemplateItem() { Id = "salesman", Text = "Salesman" }
                ]
            };

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "move" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableMove : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["sword;spyglass", "map", "root-beer;sword", "spyglass"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Inventory";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateMove(true)
            {
                Items =
                [
                    new RestApiTableColumnTemplateItem() { Id = "sword", Text = "Sword" },
                    new RestApiTableColumnTemplateItem() { Id = "spyglass", Text = "Spyglass" },
                    new RestApiTableColumnTemplateItem() { Id = "map", Text = "Treasure map" },
                    new RestApiTableColumnTemplateItem() { Id = "root-beer", Text = "Root beer" }
                ]
            };

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "color" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableColor : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["#0d6efd", "#7c3aed", "#047857", "#b45309"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Favorite color";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateColor(true, "The favorite color");

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "editor" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableEditor : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values =
        [
            "<p><b>Guybrush</b> wants to be a <i>mighty pirate</i>.</p>",
            "<p>Elaine governs <i>Mêlée Island</i>.</p>",
            "<p>LeChuck haunts the <i>Caribbean</i>.</p>",
            "<p>Stan sells <i>previously owned</i> coffins.</p>"
        ];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Notes";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateEditor(true);

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "rating" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableRating : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["5", "4", "2", "3"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Sword fighting";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateRating(true);

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "traffic-light" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableTrafficLight : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["green", "yellow", "red"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Reputation";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateTrafficLight(true, horizontal: true, size: "sm");

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "status" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableStatus : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["done", "running", "warning", "error", "pending"];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Quest";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateStatus(true);

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "rest_combo" column template of the REST table. The
    /// selectable locations are loaded from the locations endpoint.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableRestCombo : MonkeyIslandCharacterTableTemplateBase
    {
        private readonly IUri _selectionUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandCharacterTableRestCombo(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            _selectionUri = sitemapManager.GetUri<MonkeyIslandLocationsSelection>(applicationContext);
        }

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Home";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateRestCombo(true)
            {
                Uri = _selectionUri
            };

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) =>
            ViewModel.MonkeyIslandLocations.ElementAt(index % ViewModel.MonkeyIslandLocations.Count()).Id.ToString();
    }

    /// <summary>
    /// Demonstrates the "rest_tag" column template of the REST table. The
    /// autocomplete suggestions come from the tag endpoint.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableRestTag : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values = ["pirate;captain", "governor", "ghost;villain", "salesman"];

        private readonly IUri _tagUri;

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="sitemapManager">
        /// The sitemap manager used to retrieve URIs for the application context.
        /// </param>
        /// <param name="applicationContext">
        /// The application context containing the current state of the application.
        /// </param>
        public MonkeyIslandCharacterTableRestTag(ISitemapManager sitemapManager, IApplicationContext applicationContext)
        {
            _tagUri = sitemapManager.GetUri<MonkeyIslandTag>(applicationContext);
        }

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Tags";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateRestTag(true, "Add tag")
            {
                Uri = _tagUri
            };

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "markdown" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableMarkdown : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values =
        [
            "**Guybrush Threepwood** is a *mighty* pirate.",
            "Elaine governs `Mêlée Island`, see [wiki](https://example.com).",
            "# LeChuck\n- Ghost\n- Zombie\n- Demon",
            "Stan sells ~~new~~ *previously owned* coffins."
        ];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Biography";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateMarkdown();

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }

    /// <summary>
    /// Demonstrates the "html" column template of the REST table.
    /// </summary>
    [Title("Monkey Island characters")]
    public sealed class MonkeyIslandCharacterTableHtml : MonkeyIslandCharacterTableTemplateBase
    {
        private static readonly string[] _values =
        [
            "<b>Guybrush Threepwood</b> &ndash; <i>mighty pirate</i>",
            "<span class=\"badge bg-success\">Mêlée Island</span>",
            "<span class=\"badge bg-danger\">Ghost pirate</span>",
            "<a href=\"https://example.com\" target=\"_blank\" rel=\"noopener\">Used coffins</a>"
        ];

        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected override string ValueColumnLabel => "Card";

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected override IRestApiTableColumnTemplate CreateTemplate(IRequest request) =>
            new RestApiTableColumnTemplateHtml();

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected override string CreateCellContent(Character character, int index) => _values[index % _values.Length];
    }
}
