using System;
using System.Linq;
using System.Net.Http;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebData;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the file view control for the tutorial.
    /// </summary>
    [WebIcon<IconControlFileList>]
    [Title("DataFileView")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class DataFileView : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="pageContext">The context of the page where the file view control is used.</param>
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>
        public DataFileView(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.AddEvent(Event.UPLOAD_SUCCESS_EVENT, Event.CHANGE_VISIBILITY_EVENT, Event.CHANGE_VALUE_EVENT);

            Stage.Description = @"A `DataFileView` control shows one set of files in several interchangeable presentations. Besides the tabular `FileList` it always offers a tile board, and further presentations are added by the page. All presentations render the same files, so switching between them never re-queries the endpoint. The description of a file is edited in place through the `SmartEdit` control, and an `Upload` control bound to the view makes a finished upload show up without a page reload. Uploading a name that is already there is a new version of that file: the entries of one name are folded into one row that unfolds to its earlier versions.";

            // the upload posts to this page, which files the new document in the sample
            // archive; the view then reloads and shows it with the record the server made
            var upload = new ControlUpload("myUpload")
            {
                Uri = _ => pageContext.Route.ToUri(),
                AutoUpload = _ => true
            }
                .Process(x => Archive(x.Value));

            Stage.Controls =
            [
                upload,
                new ControlDataFileView("myFileView")
                {
                    EditableDescription = _ => true,
                    Bind = _ => new Binding().Add(new BindUpload { Source = "myUpload" })
                }
                    .Service("data", svc => svc
                        .Endpoint<MonkeyIslandFiles>()
                        .Method(HttpMethod.Get)
                        .UpdateMethod(HttpMethod.Put)
                        .Query(q => q.Search().Wql().Filter().Page().PageSize())
                        .Response(r => r.Items().Total()))
            ];

            Stage.DarkControls = null;

            Stage.Code = @"
            var upload = new ControlUpload(""myUpload"")
            {
                Uri = _ => pageContext.Route.ToUri(),
                AutoUpload = _ => true
            };

            new ControlDataFileView(""myFileView"")
            {
                EditableDescription = _ => true,
                Bind = _ => new Binding().Add(new BindUpload { Source = ""myUpload"" })
            }
                .Service(""data"", svc => svc
                    .Endpoint<MonkeyIslandFiles>()
                    .Method(HttpMethod.Get)
                    .UpdateMethod(HttpMethod.Put)
                    .Query(q => q.Search().Wql().Filter().Page().PageSize())
                    .Response(r => r.Items().Total()));";

            Stage.AddProperty
            (
                "Presentations",
                "The `Presentations` property lists the built-in presentations the switcher offers, in the order they are switched through. The first one is shown until the user picks another. The tile board alone turns the control into a gallery.",
                @"Presentations = _ => [TypeFileView.Tile]",
                new ControlDataFileView()
                {
                    Presentations = _ => [TypeFileView.Tile]
                }
                    .Add(Sample())
            );

            Stage.AddProperty
            (
                "Layout",
                "The `Layout` property decides what stands beside the presentation switch - not what the switch is, which is the framework-wide one. `TypeLayoutView.ToggleGroup` (the default) leaves it alone in the toolbar, `TypeLayoutView.Default` names the active presentation beside it, exactly like the `View` control.",
                @"Layout = _ => TypeLayoutView.Default",
                new ControlDataFileView()
                {
                    Layout = _ => TypeLayoutView.Default
                }
                    .Add(Sample())
            );

            Stage.AddProperty
            (
                "EditableDescription",
                "The `EditableDescription` property turns the description of a file into an inline editor. The edit is offered by the `SmartEdit` control and persisted through the update operation of the data service; a view without a service keeps the change on the client.",
                @"EditableDescription = _ => true",
                new ControlDataFileView()
                {
                    EditableDescription = _ => true
                }
                    .Add(Sample())
            );

            Stage.AddProperty
            (
                "Files",
                "The files a view declares are shown before the first response arrives, and are the whole content of a view that has no service at all. They are rendered through a real `ControlFileList`, so an entry looks the same here as it does in a standalone list.",
                @"new ControlDataFileView().Add(new ControlFileListItem(""1"") { Name = _ => ""TreasureMap.pdf"" })",
                new ControlDataFileView().Add(Sample())
            );

            Stage.AddProperty
            (
                "Views",
                "Besides the built-in presentations a page contributes its own, which join the switcher after them. A view carries its label and an optional icon, exactly like a view of the `View` control.",
                @"new ControlDataFileView().Add(new ControlViewItem(""notes"") { Title = _ => ""Notes"" })",
                new ControlDataFileView()
                    .Add(Sample())
                    .Add(new ControlViewItem("notes")
                    {
                        Title = _ => "Notes",
                        Icon = _ => new IconControlText()
                    }
                        .Add(new ControlText() { Text = _ => "Everything the archive knows that is not a file." }))
            );
        }

        /// <summary>
        /// Files an uploaded document in the sample archive, so the reload the view
        /// triggers answers with the record the server made rather than with nothing.
        /// A name that is already in the archive is filed as the next version of that
        /// document rather than as a second one.
        /// </summary>
        /// <param name="value">The uploaded file.</param>
        private static void Archive(ControlFormInputValueFile value)
        {
            if (value is null || string.IsNullOrWhiteSpace(value.Name))
            {
                return;
            }

            var latest = ViewModel.MonkeyIslandDocuments
                .Where(x => string.Equals(x.Name, value.Name, StringComparison.OrdinalIgnoreCase))
                .Select(x => x.Version)
                .DefaultIfEmpty(0)
                .Max();

            ViewModel.MonkeyIslandDocuments.Add(new Document
            {
                Name = value.Name,
                Version = latest + 1,
                Size = value.Data?.LongLength ?? 0,
                Date = DateTime.Now
            });
        }

        /// <summary>
        /// Returns the files the property samples are shown with, so every sample below
        /// shows the same archive.
        /// </summary>
        /// <returns>The sample files.</returns>
        private static IControlFileListItem[] Sample()
        {
            return [.. ViewModel.MonkeyIslandDocuments
                .Take(3)
                .Select(x => new ControlFileListItem(x.Id.ToString())
                {
                    Name = _ => x.Name,
                    Version = _ => x.Version,
                    Size = _ => x.Size,
                    Date = _ => x.Date,
                    Description = _ => x.Description
                })];
        }
    }
}
