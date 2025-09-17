using System;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebCore.WebSitemap;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls
{
    /// <summary>    
    /// Represents the file list control for the tutorial.    
    /// </summary>    
    [Title("FileList")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class FileList : PageControl
    {
        /// <summary>    
        /// Initializes a new instance of the class.    
        /// </summary>    
        /// <param name="pageContext">The context of the page where the tree control is used.</param>  
        /// <param name="sitemapManager">The sitemap manager for managing site navigation.</param>  
        public FileList(IPageContext pageContext, ISitemapManager sitemapManager)
        {
            Stage.Description = @"The `FileList` control is used to display files in a clear, structured list format. Each file is presented along with its relevant matadata.";

            Stage.Control = new ControlFileList()
            {
            }
                .Add(new ControlFileListItem()
                {
                    Name = "ProjectProposal.pdf",
                    Size = 2172,
                    Date = DateTime.Now,
                    Description = "Initial draft of the project proposal"
                })
                .Add(new ControlFileListItem()
                {
                    Name = "TeamPhoto.jpg",
                    Size = 5120,
                    Date = DateTime.Now.AddDays(-5),
                    Description = "Group photo from the kickoff meeting"
                })
                .Add(new ControlFileListItem()
                {
                    Name = "Budget.xlsx",
                    Size = 3480,
                    Date = DateTime.Now.AddDays(-435),
                    Description = "Estimated budget breakdown for Q4"
                });

            Stage.Code = @"
            new ControlFileList()
            {
            }
                .Add(new ControlFileListItem()
                {
                    Name = ""ProjectProposal.pdf"",
                    Size = 2172,
                    Date = DateTime.Now,
                    Description = ""Initial draft of the project proposal""
                })
                .Add(new ControlFileListItem()
                {
                    Name = ""TeamPhoto.jpg"",
                    Size = 5120,
                    Date = DateTime.Now.AddDays(-5),
                    Description = ""Group photo from the kickoff meeting""
                })
                .Add(new ControlFileListItem()
                {
                    Name = ""Budget.xlsx"",
                    Size = 3480,
                    Date = DateTime.Now.AddDays(-435),
                    Description = ""Estimated budget breakdown for Q4""
                });";

            Stage.AddItem
            (
                "Icon",
                "The `Icon` property defines the visual symbol or graphic representation shown alongside the file for a given `ControlFileListItem`. It helps users quickly identify the file type.",
                @"Icon = new IconFileWord()",
                new ControlFileList()
                {
                }
                    .Add(new ControlFileListItem() { Icon = new IconFileWord() })
            );

            Stage.AddItem
            (
                "Name",
                "The `Name` property represents the filename of an entry within a `ControlFileListItem`. It is used to uniquely identify the file and display it to the user.",
                @"Name = ""ProjectProposal.pdf""",
                new ControlFileList()
                {
                }
                    .Add(new ControlFileListItem() { Name = "ProjectProposal.pdf" })
            );

            Stage.AddItem
            (
                "Name",
                "The `Size` property indicates the file size in bytes for a given `ControlFileListItem`. A value less than 0 means no size information is available.",
                @"Size = 3535",
                new ControlFileList()
                {
                }
                    .Add(new ControlFileListItem() { Size = 3535 })
            );

            Stage.AddItem
            (
                "Date",
                "The `Date` property represents the date associated with a file for a given `ControlFileListItem`, typically indicating when the file was created, modified, or uploaded. If `Date = DateTime.MinValue` (default), no date will be displayed. This is used when the date is intentionally hidden or unavailable.",
                @"Date = DateTime.Now",
                new ControlFileList()
                {
                }
                    .Add(new ControlFileListItem() { Date = DateTime.Now })
            );

            Stage.AddItem
            (
                "Description",
                "The `Description` property provides additional information or context about the file for a given `ControlFileListItem`. It’s typically used to display a short note, label, or comment that helps users understand the file’s purpose or contents.",
                @"Description = ""Initial draft of the project proposal""",
                new ControlFileList()
                {
                }
                    .Add(new ControlFileListItem() { Description = "Initial draft of the project proposal" })
            );
        }
    }
}
