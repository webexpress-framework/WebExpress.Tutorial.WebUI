using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.Tutorial.WebUI.WWW.Api._1_;
using WebExpress.WebApp.WebControl;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebApp
{
    /// <summary>
    /// Represents the like control demo for the tutorial.
    /// </summary>
    [WebIcon<IconThumbsUp>]
    [Title("Like")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebApp>]
    public sealed class Like : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public Like()
        {
            Stage.Description = @"`ControlLike` is a like: how many have joined it, and a way for the reader to join it too. It posts to the address it is given and repaints itself from the answer - `{ ""value"": ""8"", ""active"": true }`, the new count and whether the caller is among it.

The count comes back from the server rather than being counted up in the browser: two readers clicking at once would otherwise each see their own click and neither the other's, and the number would drift from the one the next page load shows.

Unlike most controls of this assembly the value is rendered by the **server**, not fetched by the client - the page already knows the count, and asking for it a second time would cost a round trip and show a figure that flickers into place. The client adds the one thing markup cannot express: the toggle. The same figure appears under the entries of a `ControlDataFeed`, which builds it from json and attaches the same control to it.";

            Stage.Controls =
            [
                new ControlLike("like-demo")
                {
                    Value = _ => MonkeyIslandLike.Count("demo"),
                    Active = _ => MonkeyIslandLike.IsJoined("demo"),
                    Label = _ => "Likes",
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""demo""}"
                }
            ];

            Stage.Code = @"
            new ControlLike(""like-demo"")
            {
                Value = _ => 6,
                Label = _ => ""Likes"",
                Uri = _ => new UriEndpoint(""/api/1/like""),
                Payload = _ => @""{""""subject"""":""""demo""""}""
            }";

            Stage.AddProperty
            (
                "Value",
                "The `Value` property is the count the figure shows. It is rendered by the server, so the number is on the page before any script runs.",
                "Value = _ => 42",
                new ControlLike("like-value")
                {
                    Value = _ => 42,
                    Label = _ => "Likes"
                }
            );

            Stage.AddProperty
            (
                "Uri",
                "The `Uri` property is the address the toggle is posted to. **Without one the figure is not a button**: that is the case for a reader who is not signed in - a like belongs to somebody - and offering the click only to answer `401` is worse than not offering it. The same control serves both, so a surface does not have to choose between two of them depending on who is looking.",
                "Uri = _ => new UriEndpoint(\"/api/1/like\")",
                new ControlLike("like-plain")
                {
                    Value = _ => 3,
                    Label = _ => "Likes, read only"
                },
                new ControlLike("like-joinable")
                {
                    Value = _ => MonkeyIslandLike.Count("uri"),
                    Active = _ => MonkeyIslandLike.IsJoined("uri"),
                    Label = _ => "Likes, joinable",
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""uri""}"
                }
            );

            Stage.AddProperty
            (
                "Payload",
                "The `Payload` property is the json body naming what is being liked. It is sent verbatim; the control does not know what the endpoint on the other end calls its subject. Two figures with different payloads count separately.",
                "Payload = _ => @\"{\"\"subject\"\":\"\"grog\"\"}\"",
                new ControlLike("like-grog")
                {
                    Value = _ => MonkeyIslandLike.Count("grog"),
                    Active = _ => MonkeyIslandLike.IsJoined("grog"),
                    Label = _ => "Grog",
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""grog""}"
                },
                new ControlLike("like-swordfight")
                {
                    Value = _ => MonkeyIslandLike.Count("swordfight"),
                    Active = _ => MonkeyIslandLike.IsJoined("swordfight"),
                    Label = _ => "Sword fighting",
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""swordfight""}"
                }
            );

            Stage.AddProperty
            (
                "Active",
                "The `Active` property says whether the reader is among the count, which the figure shows as its pressed state. It is ignored without an address: a figure nobody can join must not look joined.",
                "Active = _ => true",
                new ControlLike("like-active")
                {
                    Value = _ => MonkeyIslandLike.Count("active"),
                    Label = _ => "Already liked",
                    Active = _ => MonkeyIslandLike.IsJoined("active"),
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""active""}"
                }
            );

            Stage.AddProperty
            (
                "Icon",
                "The `Icon` property replaces the thumbs-up, so a surface that likes something other than a post can say so with a different glyph.",
                "Icon = _ => new IconHeart()",
                new ControlLike("like-heart")
                {
                    Value = _ => MonkeyIslandLike.Count("heart"),
                    Active = _ => MonkeyIslandLike.IsJoined("heart"),
                    Label = _ => "Hearts",
                    Icon = _ => new IconHeart(),
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""heart""}"
                },
                new ControlLike("like-star")
                {
                    Value = _ => MonkeyIslandLike.Count("star"),
                    Active = _ => MonkeyIslandLike.IsJoined("star"),
                    Label = _ => "Stars",
                    Icon = _ => new IconStar(),
                    Uri = renderContext => WebEx.ComponentHub.SitemapManager.GetUri<MonkeyIslandLike>(renderContext?.PageContext?.ApplicationContext),
                    Payload = _ => @"{""subject"":""star""}"
                }
            );
        }
    }
}
