using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebApplication;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
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
                Width = _ => TypeWidth.Fifty
            }
                .Add(new ControlCarouselItem()
                {
                    Headline = _ => "Item 1",
                    Text = _ => "Text for item 1",
                    Control = _ => new ControlImage()
                    {
                        Classes = ["w-100"],
                        Uri = _ => applicationContext.Route.Concat("assets/img/carousel1.png").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = _ => "Item 2",
                    Text = _ => "Text for item 2",
                    Control = _ => new ControlImage()
                    {
                        Classes = ["w-100"],
                        Uri = _ => applicationContext.Route.Concat("assets/img/carousel2.png").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = _ => "Item 3",
                    Text = _ => "Text for item 3",
                    Control = _ => new ControlImage()
                    {
                        Classes = ["w-100"],
                        Uri = _ => applicationContext.Route.Concat("assets/img/carousel3.png").ToUri()
                    }
                });

            Stage.Code = @"
                Stage.Control = new ControlCarousel(""myCarousel"")
                {
                    Width = TypeWidth.Fifty
                }
                .Add(new ControlCarouselItem()
                {
                    Headline = _ => ""Item 1"",
                    Text = _ => ""Text for item 1"",
                    Control = new ControlImage()
                    {
                        Classes = [""w-100""],
                        Uri = applicationContext.Route.Concat(""assets/img/carousel1.png"").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline = _ => ""Item 2"",
                    Text = _ => ""Text for item 2"",
                    Control = new ControlImage()
                    {
                        Classes = [""w-100""],
                        Uri = applicationContext.Route.Concat(""assets/img/carousel2.png"").ToUri()
                    }
                })
                .Add(new ControlCarouselItem()
                {
                    Headline =_ =>  _ => ""Item 3"",
                    Text = _ =>  _ => ""Text for item 3"",
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
                        Width = _ => TypeWidth.Fifty
                    }
                        .Add(new ControlCarouselItem()
                        {
                            Headline = _ => "Item 1",
                            Text = _ => "Text for item 1",
                            Control = _ => new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = _ => applicationContext.Route.Concat("assets/img/carousel1.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = _ => "Item 2",
                            Text = _ => "Text for item 2",
                            Control = _ => new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = _ => applicationContext.Route.Concat("assets/img/carousel2.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = _ => "Item 3",
                            Text = _ => "Text for item 3",
                            Control = _ => new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = _ => applicationContext.Route.Concat("assets/img/carousel3.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = _ => "Item 4",
                            Text = _ => "Text for item 4",
                            Control = _ => new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = _ => applicationContext.Route.Concat("assets/img/carousel4.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = _ => "Item 5",
                            Text = _ => "Text for item 5",
                            Control = _ => new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri =_ =>  applicationContext.Route.Concat("assets/img/carousel5.png").ToUri()
                            }
                        })
                        .Add(new ControlCarouselItem()
                        {
                            Headline = _ => "Item 6",
                            Text = _ => "Text for item 6",
                            Control = _ => new ControlImage()
                            {
                                Classes = ["w-100"],
                                Uri = _ => applicationContext.Route.Concat("assets/img/carousel6.png").ToUri()
                            }
                        })
            ];
        }
    }
}
