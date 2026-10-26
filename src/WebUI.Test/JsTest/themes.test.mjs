import { test } from "node:test";
import assert from "node:assert/strict";
import { readFileSync } from "node:fs";

/**
 * Reads explicit mode tokens so inherited light values cannot conceal missing dark surfaces.
 * @param {string} css The embedded theme stylesheet.
 * @param {string} mode The color mode to inspect.
 * @returns {Map<string, string>} The mode's declared tokens.
 */
function tokens(css, mode) {
    const block = css.match(new RegExp(`\\[data-wx-theme="${mode}"\\]\\s*\\{([^}]+)`));
    assert.ok(block, `missing ${mode} palette`);
    return new Map([...block[1].matchAll(/--wx-([\w-]+):\s*([^;]+);/g)].map(match => [match[1], match[2].trim()]));
}

/**
 * Computes relative luminance for contrast checks in the sRGB color space.
 * @param {string} hex The six-digit hexadecimal CSS color.
 * @returns {number} Relative luminance between zero and one.
 */
function luminance(hex) {
    assert.match(hex, /^#[0-9a-f]{6}$/i);
    const channels = [1, 3, 5].map(offset => parseInt(hex.slice(offset, offset + 2), 16) / 255);
    const linear = channels.map(value => value <= 0.04045 ? value / 12.92 : ((value + 0.055) / 1.055) ** 2.4);
    return linear[0] * 0.2126 + linear[1] * 0.7152 + linear[2] * 0.0722;
}

for (const name of ["autumn", "spring", "summer", "winter"]) {
    test(`${name} preserves readable text and status colors in both modes`, () => {
        const css = readFileSync(new URL(`../../WebUI/Assets/css/${name}.theme.css`, import.meta.url), "utf8");
        const light = tokens(css, "light");
        const dark = tokens(css, "dark");
        assert.notEqual(dark.get("body-bg"), light.get("body-bg"));
        const pairs = [
            ["body-bg", "body-color"], ["body-bg", "heading-color"], ["body-bg", "link-color"],
            ["secondary-bg", "body-color"], ["tertiary-bg", "secondary-color"]
        ];
        for (const status of ["primary", "secondary", "success", "info", "warning", "danger", "light", "dark"]) {
            pairs.push([status, `${status}-contrast`], [`${status}-bg-subtle`, `${status}-text-emphasis`]);
        }
        for (const palette of [light, dark]) {
            for (const [background, foreground] of pairs) {
                const values = [luminance(palette.get(background)), luminance(palette.get(foreground))].sort((a, b) => a - b);
                assert.ok((values[1] + 0.05) / (values[0] + 0.05) >= 4.5, `${name}: ${foreground} on ${background}`);
            }
            for (const [key, value] of palette) {
                if (!key.endsWith("-rgb")) continue;
                const hex = palette.get(key.slice(0, -4));
                assert.deepEqual(value.split(",").map(Number), [1, 3, 5].map(offset => parseInt(hex.slice(offset, offset + 2), 16)));
            }
        }
    });
}
