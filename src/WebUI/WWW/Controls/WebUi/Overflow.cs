using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.WebFragment.ControlPage;
using WebExpress.Tutorial.WebUI.WebPage;
using WebExpress.Tutorial.WebUI.WebScope;
using WebExpress.WebApp.WebScope;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebPage;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebIcon;

namespace WebExpress.Tutorial.WebUI.WWW.Controls.WebUi
{
    /// <summary>  
    /// Represents the overflow control for the tutorial.  
    /// </summary>  
    [Title("Overflow")]
    [Scope<IScopeGeneral>]
    [Scope<IScopeControl>]
    [Scope<IScopeControlWebUI>]
    public sealed class Overflow : PageControl
    {
        /// <summary>  
        /// Initializes a new instance of the class.  
        /// </summary>
        /// <param name="pageContext">The context of the page where the dropdown control is used.</param>  
        public Overflow(IPageContext pageContext)
        {
            Stage.Description = @"The `Overflow` control is a responsive UI mechanism designed to maintain layout integrity when the available space within a container becomes insufficient to display all child elements. It automatically detects overflow conditions and seamlessly relocates excess elements into a collapsible dropdown menu, preserving both usability and visual hierarchy.";

            Stage.Controls = [
                new ControlPanelOverflow()
                    .Add(CreateControl(30))
            ];

            Stage.Code = @"
            new ControlPanelOverflow()
                .Add(CreateControl(30));";

            Stage.AddProperty
            (
                "BackgroundColor",
                "Sets the background color of the overflow control.",
                "BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)",
                new ControlText()
                {
                    Text = "Default",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Primary",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Primary)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Secondary",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Secondary)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Info",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Info)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Success",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Success)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Warning",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Warning)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Danger",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Danger)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Dark",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Dark)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Light",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground(TypeColorBackground.Light)
                }.Add(CreateControl(30)),
                new ControlText()
                {
                    Text = "Custom",
                    TextColor = new PropertyColorText(TypeColorText.Info)
                },
                new ControlPanelOverflow()
                {
                    BackgroundColor = new PropertyColorBackground("gold")
                }.Add(CreateControl(30))
            );
        }

        /// <summary>
        /// Creates a sequence of control elements with predefined text and spacing.
        /// </summary>
        /// <param name="count">
        /// The number of control elements to create. Must be a non-negative integer.
        /// </param>
        /// <returns>
        /// An enumerable collection of control objects, each initialized with a unique 
        /// text label and a margin of two spaces.
        /// </returns>
        private static IEnumerable<IControl> CreateControl(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                if (i % 2 == 0)
                {
                    yield return new ControlLink()
                    {
                        Text = $"Link {i}",
                        Icon = new IconLink()
                    };
                }
                else
                {
                    yield return new ControlDropdown()
                    {
                        Text = $"Dropdown {i}",
                        Margin = new PropertySpacingMargin(PropertySpacing.Space.One),
                        Icon = new IconSpider()
                    }
                        .AddHeader($"Header {i}")
                        .Add(new ControlDropdownItemLink() { Text = $"Link {i}(1)" })
                        .Add(new ControlDropdownItemLink() { Text = $"Link {i}(2)" })
                        .Add(new ControlDropdownItemLink() { Text = $"Link {i}(3)" })
                        .AddSeperator()
                        .Add(new ControlDropdownItemLink() { Text = $"Link {i}(4)" })
                        .Add(new ControlDropdownItemLink() { Text = $"Link {i}(5)" })
                        .Add(new ControlDropdownItemLink() { Text = $"Link {i}(6)" });
                }
            }
        }
    }
}
