using WebExpress.WebApp.WebData;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// The type-safe identities of the ViewState resources used by the WebApp control
    /// demo pages. A ViewState declares a resource with Resource&lt;TResource&gt;() and
    /// a control binds to it with Resource&lt;TResource&gt;(), so the resource is
    /// referenced by its type and never by a string name.
    /// </summary>
    public sealed class GamesResource : IDataResource { }

    /// <summary>The tile panel resource.</summary>
    public sealed class TilesResource : IDataResource { }

    /// <summary>The kanban board resource.</summary>
    public sealed class BoardResource : IDataResource { }

    /// <summary>The dashboard layout resource.</summary>
    public sealed class LayoutResource : IDataResource { }

    /// <summary>The tab set resource.</summary>
    public sealed class TabsResource : IDataResource { }

    /// <summary>The comments resource.</summary>
    public sealed class CommentsResource : IDataResource { }

    /// <summary>The scrum backlog resource.</summary>
    public sealed class BacklogResource : IDataResource { }

    /// <summary>The traffic light status resource.</summary>
    public sealed class StatusResource : IDataResource { }
}
