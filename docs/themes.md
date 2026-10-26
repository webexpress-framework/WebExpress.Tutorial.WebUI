# Tutorial themes

Theme selection is available to administrators under Settings, System, General, Designs at `/webui/webexpress.webapp/settings/system/theme`. Select Autumn pastel to use cream surfaces, apricot buttons, sage green success states and muted autumn accents. Select Summer for light sandy surfaces, turquoise navigation, sky blue accents, sunshine yellow warnings and coral danger states. Select Spring for blossom pink, lilac and fresh green, or Winter for snowy surfaces, ice blue and muted berry accents. The public DataSelectionTheme example uses the same selector and endpoint.

Theme registration uses `AutumnTheme`, `SummerTheme`, `SpringTheme` and `WinterTheme`, the `IThemeWebApp` marker and a `ThemeStyle` attribute. The stylesheet imports the framework application theme before overriding shared `--wx-*` tokens. This retains the application layout and propagates the palette to controls. Dark theme remains the explicitly declared application default.

Preference handling uses the existing `ThemeStore`, keyed by client IP address in memory. Tutorial pages and the shared settings pages apply the registered selection before rendering. Clients sharing an IP address share the preference, and restarting the server clears it. The application registers its preference resolver and selector through `ThemePreferences`, so every settings page applies the same selection. Production applications should store preferences against a user profile or session.

Validation includes a DebugLocal host build and browser checks for theme selection, stylesheet loading and navigation to other tutorial pages. Filled palette colors use text contrast ratios above 4.5:1. The Designs page retains the framework system access policy and requires an authenticated administrator.

Color modes use explicit light and dark token palettes, including nested control previews. Text, links, status surfaces and borders retain seasonal colors in either mode.
