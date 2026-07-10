using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Base class for the table template demo endpoints. Each derived
    /// endpoint demonstrates one column template of the REST table: it names
    /// the template through <see cref="CreateTemplate"/> and supplies the
    /// demo cell values through <see cref="CreateCellContent"/>, while the
    /// character column, the row shape and the name filter are shared here.
    /// </summary>
    public abstract class MonkeyIslandCharacterTableTemplateBase : RestApiTable<Character>
    {
        /// <summary>
        /// Gets the label of the template column.
        /// </summary>
        protected abstract string ValueColumnLabel { get; }

        /// <summary>
        /// Creates the column template the endpoint demonstrates.
        /// </summary>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The template of the value column.</returns>
        protected abstract IRestApiTableColumnTemplate CreateTemplate(IRequest request);

        /// <summary>
        /// Supplies the demo value of the template column for a character.
        /// </summary>
        /// <param name="character">The character of the row.</param>
        /// <param name="index">The zero-based row index, used to rotate demo values.</param>
        /// <returns>The cell content.</returns>
        protected abstract string CreateCellContent(Character character, int index);

        /// <summary>
        /// Retrieves the collection of columns available for the specified
        /// REST API request: the character name and the templated value column.
        /// </summary>
        /// <param name="request">
        /// The request for which to retrieve the available table columns.
        /// </param>
        /// <returns>
        /// An enumerable collection of columns describing the structure of
        /// the data returned by the REST API for the specified request.
        /// </returns>
        protected override IEnumerable<RestApiTableColumn> RetrieveColums(IRequest request)
        {
            yield return new RestApiTableColumn()
            {
                Id = "name",
                Name = "Name",
                Label = "Name",
                Visible = true
            };

            yield return new RestApiTableColumn()
            {
                Id = "value",
                Name = "Value",
                Label = ValueColumnLabel,
                Visible = true,
                Template = CreateTemplate(request)
            };
        }

        /// <summary>
        /// Retrieves a queryable collection of rows: one row per character
        /// with the rotating demo value in the templated column.
        /// </summary>
        /// <param name="query">
        /// An object containing the query parameters used to filter and select index items.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed.
        /// </param>
        /// <param name="columns">
        /// The collection of columns available for the specified REST API request.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// An enumerable collection of table rows that satisfy the query.
        /// </returns>
        protected override IQueryable<RestApiTableRow> RetrieveRows(IQuery<Character> query, IQueryContext context, IEnumerable<RestApiTableColumn> columns, IRequest request)
        {
            return query.Apply(ViewModel.MonkeyIslandCharacters.AsQueryable())
                .AsEnumerable()
                .Select((x, index) => new RestApiTableRow()
                {
                    Id = x.Id.ToString(),
                    Cells = new[]
                    {
                        new RestApiTableCell()
                        {
                            Content = x.Name
                        },
                        new RestApiTableCell()
                        {
                            Content = CreateCellContent(x, index)
                        }
                    },
                    Image = (x.Icon is ImageIcon)
                        ? x.Icon.Uri.ToString()
                        : null
                })
                .AsQueryable();
        }

        /// <summary>
        /// Applies the name filter to the character query.
        /// </summary>
        /// <param name="filter">
        /// A string representing the filter expression to apply.
        /// </param>
        /// <param name="query">
        /// The query object to which the filter will be applied.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>
        /// A query representing the filtered set of items.
        /// </returns>
        protected override IQuery<Character> Filter(string filter, IQuery<Character> query, IRequest request)
        {
            if (filter is null || filter == "null")
            {
                return query;
            }

            return query.WhereContainsIgnoreCase
            (
                x => x.Name, filter
            );
        }
    }
}
