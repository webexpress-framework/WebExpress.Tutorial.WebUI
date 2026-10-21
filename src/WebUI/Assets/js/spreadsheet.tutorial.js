/**
 * The scripts of the spreadsheet tutorial: the custom functions of the step that registers
 * functions, and the hub that shares the spreadsheets of the collaboration step inside the page.
 * A spreadsheet created before a function is registered recalculates its formulas on its own,
 * so the order in which the page loads its scripts does not matter.
 */
(() => {
    const register = () => {
        const Functions = webexpress.webui.SpreadsheetFunctions;

        // the value added tax of an amount, with the German standard rate as default
        Functions.register("VAT", {
            fn: ([amount, rate], api) => {
                const value = api.values.toNumber(amount);
                if (api.values.isError(value)) return value;
                const percent = rate === undefined || rate === null ? 0.19 : api.values.toNumber(rate);
                if (api.values.isError(percent)) return percent;
                return Math.round(value * percent * 100) / 100;
            },
            minArgs: 1,
            maxArgs: 2,
            category: "finance",
            syntax: "VAT(amount, [rate])",
            description: "Returns the value added tax of an amount."
        });

        // the hours worked between a start and an end time, without the break in minutes
        Functions.register("WORKHOURS", {
            fn: ([start, end, pause], api) => {
                const values = [start, end, pause ?? 0].map(v => api.values.toNumber(v));
                const failure = values.find(v => api.values.isError(v));
                if (failure) return failure;
                const [from, to, minutes] = values;
                return Math.max(0, (to - from) * 24 - minutes / 60);
            },
            minArgs: 2,
            maxArgs: 3,
            category: "time",
            syntax: "WORKHOURS(start, end, [break])",
            description: "Returns the worked hours between two times without the break."
        });
    };

    // the spreadsheets marked for sharing are paired per sample card, each pair through its own hub
    const share = (attempt = 0) => {
        const hosts = [...document.querySelectorAll(".tutorial-spreadsheet-share")];
        const instances = hosts.map(host => webexpress.webui.Controller.getInstanceByElement(host));
        if (instances.some(instance => !instance)) {
            if (attempt < 50) setTimeout(() => share(attempt + 1), 100);
            return;
        }
        const groups = new Map();
        hosts.forEach((host, index) => {
            const group = host.closest(".card") ?? document.body;
            if (!groups.has(group)) groups.set(group, []);
            groups.get(group).push(instances[index]);
        });
        const users = [{ id: "anna", name: "Anna", color: "#1a73e8" }, { id: "ben", name: "Ben", color: "#e8710a" }, { id: "clara", name: "Clara", color: "#188038" }];
        for (const members of groups.values()) {
            const hub = new webexpress.webui.SpreadsheetMemoryHub({ latency: 120 });
            members.reduce((previous, ctrl, index) => previous.then(() => ctrl.connect(new webexpress.webui.SpreadsheetMemoryProvider(hub), { user: users[index % users.length] })), Promise.resolve());
        }
    };

    const start = () => { register(); share(); };
    if (document.readyState === "loading" || typeof webexpress === "undefined" || !webexpress.webui?.SpreadsheetFunctions) {
        document.addEventListener("DOMContentLoaded", start);
    } else {
        start();
    }
})();
