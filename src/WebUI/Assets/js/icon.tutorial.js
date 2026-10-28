/**
 * The size slider of the icon gallery. It lives in a file of its own because the content
 * security policy blocks a script that is part of the page's html text.
 */
(function () {
    const apply = (px) => {
        document.documentElement.style.setProperty("--wx-gallery-size", px + "px");
        document.querySelectorAll("[data-wx-gallery-size-out]").forEach((o) => { o.textContent = px + " px"; });
        document.querySelectorAll("[data-wx-gallery-size]").forEach((i) => { i.value = px; });
        try { localStorage.setItem("wx-gallery-size", px); } catch (e) { }
    };

    // delegated, because the stage renders the slider twice - live and as an html listing
    document.addEventListener("input", (e) => {
        if (e.target?.matches?.("[data-wx-gallery-size]")) {
            apply(e.target.value);
        }
    });

    let saved = null;
    try { saved = localStorage.getItem("wx-gallery-size"); } catch (e) { }

    // the script is linked in the head, so the slider may not be parsed yet
    const restore = () => apply(saved || 20);
    if (document.readyState === "loading") {
        document.addEventListener("DOMContentLoaded", restore);
    } else {
        restore();
    }
})();
