using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// Answers the registered link systems the add dialog fills its sidebar
    /// from. The whole answer is derived from the link registry, so the endpoint
    /// carries nothing but its route - a system a plugin registers appears here
    /// on its own.
    /// </summary>
    [Segment("link-systems")]
    [Title("Monkey Island Relation Systems")]
    public sealed class MonkeyIslandRelationSystem : RestApiRelationSystem
    {
    }
}
