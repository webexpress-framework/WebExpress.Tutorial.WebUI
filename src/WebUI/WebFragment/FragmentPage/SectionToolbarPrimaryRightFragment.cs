﻿using WebExpress.WebApp.WebSection;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebFragment;
using WebExpress.WebUI.WebControl;
using WebExpress.WebUI.WebFragment;

namespace WebExpress.Tutorial.WebUI.WebFragment.FragmentPage
{
    /// <summary>
    /// Represents a fragment control for the tutorial.
    /// </summary>
    [Section<SectionToolbarPrimary>]
    [Scope<IScopeFragment>]
    [Cache]
    public sealed class SectionToolbarPrimaryRightFragment : FragmentControlToolbarItemButton
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="fragmentContext">The context in which the fragment is used.</param>
        public SectionToolbarPrimaryRightFragment(IFragmentContext fragmentContext)
            : base(fragmentContext)
        {
            Text = "SectionToolbarPrimary (Right)";
            Alignment = TypeToolbarItemAlignment.Right;
        }
    }
}
