using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;
using WebUI.WebFragment.ControlPage;
using WebUI.WebPage;
using WebUI.WebScope;

namespace WebUI.WWW.Controls
{
    /// <summary>
    /// Represents the carousel control for the tutorial.
    /// </summary>
    [Title("Carousel")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Carousel : PageControl
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="applicationContext">The application context.</param>
        public Carousel(IApplicationContext applicationContext)
        {
            Stage.Description = @"A `Carousel` is an interactive component used to display multiple pieces of content within a single, scrollable container. It is ideal for showcasing image galleries, highlights, testimonials, product sliders, or any content that benefits from sequential, visually engaging presentation.";

            Stage.Control = new ControlCarousel("myCarousel")
            {
                Width = TypeWidth.Fifty
            }
                .Add(new ControlCarouselItem()
                {
                    Headline = "Item 1",
                    Text = "Text for item 1",
                    Control = new ControlImage()
                    {
                        Classes = ["w-100"],
                        Uri = applicationContext.Route.Concat("assets/img/carousel1.png").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = "Item 2",
                    Text = "Text for item 2",
                    Control = new ControlImage()
                    {
                        Classes = ["w-100"],
                        Uri = applicationContext.Route.Concat("assets/img/carousel2.png").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = "Item 3",
                    Text = "Text for item 3",
                    Control = new ControlImage()
                    {
                        Classes = ["w-100"],
                        Uri = applicationContext.Route.Concat("assets/img/carousel3.png").ToUri()
                    }
                });

            Stage.Code = @"
                Stage.Control = new ControlCarousel(""myCarousel"")
                {
                    Width = TypeWidth.Fifty
                }
                .Add(new ControlCarouselItem()
                {
                    Headline = ""Item 1"",
                    Text = ""Text for item 1"",
                    Control = new ControlImage()
                    {
                        Classes = [""w-100""],
                        Uri = applicationContext.Route.Concat(""assets/img/carousel1.png"").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = ""Item 2"",
                    Text = ""Text for item 2"",
                    Control = new ControlImage()
                    {
                        Classes = [""w-100""],
                        Uri = applicationContext.Route.Concat(""assets/img/carousel2.png"").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = ""Item 3"",
                    Text = ""Text for item 3"",
                    Control = new ControlImage()
                    {
                        Classes = [""w-100""],
                        Uri = applicationContext.Route.Concat(""assets/img/carousel3.png"").ToUri()
                    }
                });";

            Stage.DarkControls =
                [
                    new ControlCarousel("myDarkCarousel")
                    {
                        Width = TypeWidth.Fifty
                    }
                        .Add(new ControlCarouselItem()
                        {
                            Headline = "Item 1",
                            Text = "Text for item 1",
                            Control = new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = applicationContext.Route.Concat("assets/img/carousel1.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = "Item 2",
                            Text = "Text for item 2",
                            Control = new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = applicationContext.Route.Concat("assets/img/carousel2.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = "Item 3",
                            Text = "Text for item 3",
                            Control = new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = applicationContext.Route.Concat("assets/img/carousel3.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = "Item 4",
                            Text = "Text for item 4",
                            Control = new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = applicationContext.Route.Concat("assets/img/carousel4.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = "Item 5",
                            Text = "Text for item 5",
                            Control = new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = applicationContext.Route.Concat("assets/img/carousel5.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = "Item 6",
                            Text = "Text for item 6",
                            Control = new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = applicationContext.Route.Concat("assets/img/carousel6.png").ToUri()
                            }
                        })
            ];
        }
    }
}
