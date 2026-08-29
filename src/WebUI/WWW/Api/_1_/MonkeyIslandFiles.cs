using System;
using System.Collections.Generic;
using System.Linq;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;
using WebExpress.WebIndex.Wql;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Represents a REST API serving the documents of the Monkey Island archive to the
    /// file view demo, including the in place edit of a description.
    /// </summary>
    [Title("Monkey Island Archive")]
    public sealed class MonkeyIslandFiles : RestApiFile<Document>
    {
        /// <summary>
        /// Retrieves the documents that match the specified query criteria.
        /// </summary>
        /// <param name="query">
        /// An object containing the query parameters used to filter and select index items.
        /// </param>
        /// <param name="context">
        /// The context in which the query is executed.
        /// </param>
        /// <param name="request">
        /// The request that provides the operational context.
        /// </param>
        /// <returns>The files that satisfy the query criteria.</returns>
        protected override IEnumerable<RestApiFileItem> RetrieveItems(IQuery<Document> query, IQueryContext context, IRequest request)
        {
            return query.Apply(ViewModel.MonkeyIslandDocuments.AsQueryable())
                .Select(x => new RestApiFileItem()
                {
                    Id = x.Id.ToString(),
                    Name = x.Name,
                    Version = x.Version,
                    // the sample archive holds no bytes, so a file has no address to
                    // download it from and the client renders it as a dead link
                    Size = FormatSize(x.Size, request),
                    Date = FormatDate(x.Date, request),
                    Description = x.Description
                });
        }

        /// <summary>
        /// Returns how many documents the archive holds. The sample archive is a list in
        /// memory, so counting it is free and the view can show the real total.
        /// </summary>
        /// <param name="query">The query the page was taken from.</param>
        /// <param name="request">The triggering request.</param>
        /// <returns>The total number of documents.</returns>
        protected override int? RetrieveTotal(IQuery<Document> query, IRequest request)
        {
            return ViewModel.MonkeyIslandDocuments.Count;
        }

        /// <summary>
        /// Persists a description that was edited in place. The demo keeps its documents in
        /// memory, so the edit is written straight to the sample data.
        /// </summary>
        /// <param name="id">The id of the document whose description changed.</param>
        /// <param name="description">The new description.</param>
        /// <param name="request">The triggering request.</param>
        protected override void UpdateDescription(string id, string description, IRequest request)
        {
            var document = ViewModel.MonkeyIslandDocuments
                .FirstOrDefault(x => x.Id.ToString().Equals(id, StringComparison.OrdinalIgnoreCase));

            if (document is not null)
            {
                document.Description = description;
            }
        }

        /// <summary>
        /// Applies filtering criteria to the specified query based on the provided WQL statement.
        /// </summary>
        /// <param name="wqlStatement">The WQL statement that defines the filtering conditions.</param>
        /// <param name="query">The query object to which the filtering criteria will be applied.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The filtered query.</returns>
        protected override IQuery<Document> Filter(IWqlStatement<Document> wqlStatement, IQuery<Document> query, IRequest request)
        {
            if (wqlStatement is null || wqlStatement.HasErrors)
            {
                return query;
            }

            return wqlStatement.ToQuery();
        }

        /// <summary>
        /// Applies the specified search term to the given query object.
        /// </summary>
        /// <param name="search">The search term.</param>
        /// <param name="query">The query object to which the filter will be applied.</param>
        /// <param name="request">The request that provides the operational context.</param>
        /// <returns>The filtered query.</returns>
        protected override IQuery<Document> Filter(string search, IQuery<Document> query, IRequest request)
        {
            if (string.IsNullOrEmpty(search) || search == "null")
            {
                return query;
            }

            return query.Where(x => x.Name.Contains(search));
        }
    }
}
