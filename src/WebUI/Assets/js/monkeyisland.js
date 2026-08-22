/**
 * Switches the Monkey Island icon set on and off from the user menu.
 *
 * An icon set is a stylesheet of mask rules, so switching one on is adding a link element -
 * no page reload and no server round trip. The choice is remembered per browser, which is
 * the right scope here: it is a display preference, not application state.
 *
 * The theme route does the same thing server-side through MonkeyIslandTheme; both share
 * monkeyisland.icons.css so the drawings are declared in exactly one place.
 */
(function () {
    const KEY = "wx-tutorial-iconset";
    const LINK_ID = "wx-monkeyisland-sheet";

    // the dropdown rebuilds its items from the server markup and carries over only data
    // attributes, so the hook has to be one - a class would not survive the rebuild
    const TOGGLE = "[data-wx-iconset='monkeyisland']";
    const HREF = "[data-wx-iconset-href]";

    /**
     * Returns the stylesheet address the server put on the menu item.
     *
     * The sheet is an asset of the application while this script is an asset of the plugin,
     * so the two live under different mount points and the url cannot be derived from
     * document.currentScript.
     * @returns {string|null} The address, or null while the menu item is not in the dom yet.
     */
    const sheetHref = function () {
        const carrier = document.querySelector(HREF);
        return carrier ? carrier.getAttribute("data-wx-iconset-href") : null;
    };

    /**
     * Returns whether the set is currently chosen.
     * @returns {boolean} True when the set is on.
     */
    const enabled = function () {
        try {
            return localStorage.getItem(KEY) === "monkeyisland";
        } catch (e) {
            return false;
        }
    };

    /**
     * Adds or removes the stylesheet and reflects the state on every toggle.
     * @param {boolean} on - Whether the set should be active.
     * @param {string} [href] - The stylesheet address, when it is already known.
     */
    const apply = function (on, href) {
        let link = document.getElementById(LINK_ID);
        const address = href || sheetHref();

        if (on && !link && address) {
            link = document.createElement("link");
            link.id = LINK_ID;
            link.rel = "stylesheet";
            link.href = address;
            document.head.appendChild(link);
        } else if (!on && link) {
            link.remove();
        }

        for (const item of document.querySelectorAll(TOGGLE)) {
            item.setAttribute("aria-pressed", String(!!on));
        }

        try {
            localStorage.setItem(KEY, on ? "monkeyisland" : "");
        } catch (e) { }
    };

    // delegated, because the menu item is rendered per page and is replaced by the dropdown
    document.addEventListener("click", function (e) {
        const hit = e.target && e.target.closest && e.target.closest(TOGGLE);
        if (!hit) {
            return;
        }

        e.preventDefault();
        apply(!enabled(), hit.getAttribute("data-wx-iconset-href"));
    });

    // the toggles only exist once the body is parsed, and the address comes with them
    document.addEventListener("DOMContentLoaded", function () {
        apply(enabled());
    });
})();
