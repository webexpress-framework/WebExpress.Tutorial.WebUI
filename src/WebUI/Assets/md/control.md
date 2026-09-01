# Controls overview

WebExpress ships a rich set of ready-to-use controls that cover everything from typography and layout to forms, data collections and live, REST-backed surfaces. Controls come in two layers: **WebUI** controls render static, server-side HTML (`ControlButton`, `ControlTable`, …), while **WebApp** controls (the `ControlData*` family) bind to a REST service and hydrate themselves on the client.

The tables below summarize the available controls and what each one is for. Pick a control from the navigation to see it live, together with its properties and code. For the full reference and more examples, visit https://webexpress-framework.github.io/WebExpress.WebUI/.

## Layout & containers

| Control | Description |
| --- | --- |
| `ControlPanel` | Generic container that groups and styles child controls. |
| `ControlPanelCard` | Bordered card surface with optional header and footer. |
| `ControlPanelFlex` | Flexbox container for one-dimensional layouts. |
| `ControlPanelGrid` | Responsive grid container for column-based layouts. |
| `ControlGroup` | Items laid out as fields of one surface, divided by hairlines. For things read as one statement about one subject - a row of metrics, a set of entry paths, the columns of a help area - where separate framed boxes would read as separate claims. Takes any control as a field, divides the width evenly, and keeps the dividers correct when the row wraps. |
| `ControlPanelSplit` | Two resizable panes separated by a draggable splitter. |
| `ControlMasterDetail` | List on the left, detail loaded on demand on the right, with a splitter between them and a sequential single-column mode on narrow screens. |
| `ControlPanelCenter` | Centers its content horizontally and vertically. |
| `ControlPanelOverflow` | Scrollable region that clips overflowing content. |
| `ControlFrame` | Bordered frame with an optional title around its content. |
| `ControlResponsive` | Shows or hides content based on the viewport breakpoint. |
| `ControlView` | Several views of one subject behind one switch, with a shared header and footer around them. The switch is the framework-wide one; the layout decides whether the active view is named beside it. Comes back in the view the user last chose. |
| `ControlAccordion` | Stack of collapsible sections, one open at a time by default. |
| `ControlSection` | Flat, collapsible section: a quiet upper-case label over a body with a vertical guide line, without the frame of a card. Carries an accent color and a badge, and lays out stacked, beside its label or on a rule. For a page that shows one subject from many angles. |
| `ControlOffcanvas` | Drawer panel that slides in from an edge of the viewport. |

## Typography & content

| Control | Description |
| --- | --- |
| `ControlText` | Text with formatting, including inline Markdown. |
| `ControlContent` | Reading view of a value written with the editor. The editor stores its working surface - add-on frames with their headers and handles, framed tables with column resizers, the guard paragraphs around non-editable blocks - which is stripped away so one stored value serves both the author and the reader. `Format` decides the view: the document, or its Markdown source for handing the value on in a portable form. Display only, and the read side of `ControlSmartEdit` and of the editor table template. |
| `ControlHtml` | Renders raw, trusted HTML. |
| `ControlCode` | Syntax-highlighted source code block. |
| `ControlLine` | Horizontal divider line. |
| `ControlIcon` | A single icon from the icon set. |
| `ControlImage` | Responsive image with optional link. |
| `ControlCanvas` | Raw drawing surface painted from JavaScript. |
| `ControlBarcode` | Value encoded as a scannable graphic: Code 128, Code 39, EAN-13, EAN-8 or a QR code, drawn as inline SVG. |
| `ControlLink` | A hyperlink to a route or external URL. |
| `ControlLinkList` | Group of related links under a shared heading and icon. |
| `ControlAttribute` | Inline label/value attribute chip. |
| `ControlDescriptionList` | Key/value definition list, vertical or side-by-side. |
| `ControlDate` | Formatted, read-only date display. |

## Buttons & actions

| Control | Description |
| --- | --- |
| `ControlButton` | Clickable button that triggers an action or submits a form. |
| `ControlButtonLink` | Link styled as a button. |
| `ControlSplitButton` | Button with an attached dropdown of secondary actions. |
| `ControlSplitButtonLink` | Split button whose primary action is a link. |
| `ControlButtonGroup` | Set of buttons joined into a single segmented control. |
| `ControlToolbar` | Bar of buttons, labels, dropdowns and dividers. |
| `ControlDropdown` | Toggleable menu of links and actions. |

## Forms & input

| Control | Description |
| --- | --- |
| `ControlForm` | Form container with validation and submit handling. |
| `ControlFormItemInputText` | Single-line or multi-line text input. |
| `ControlFormItemInputPassword` | Password input with reveal and strength hints. |
| `ControlFormItemInputCheck` | Checkbox or switch. |
| `ControlFormItemInputRadio` | Radio button group. |
| `ControlFormItemInputChoice` | Segmented choice: a few mutually exclusive options as a row of buttons, optionally with an accent dot per option and narrowed to the value of another input. |
| `ControlFormItemInputCombo` | Dropdown selection input. |
| `ControlFormItemInputCascading` | Dependent selection levels where each level's options derive from the previous choice. |
| `ControlFormItemInputSlider` | Range slider for numeric input. |
| `ControlFormItemInputRating` | Star rating input. |
| `ControlFormItemInputBarcode` | Barcode value as text, with a live preview of the symbol it encodes. |
| `ControlFormItemInputTrafficLight` | Traffic light status picker (red/yellow/green). |
| `ControlFormItemInputEstimate` | Estimate picked from a configurable scale (e.g. story points). |
| `ControlFormItemInputDate` | Date input with a picker. |
| `ControlFormItemInputCalendar` | Inline calendar selection. |
| `ControlFormItemInputTile` | Selection from a grid of tile cards, with an optional search box and narrowing to the value of another input. |
| `ControlSelection` | Multi-item selection list. |
| `ControlColor` | Color picker. |
| `ControlUpload` | File upload with drag-and-drop. |
| `ControlSmartEdit` | Inline edit of a single value in place, without leaving the view: a pen on hover opens the configured editor over the value and saves it through a form action or through the host. An unset value reads as the editor's placeholder, so it stays reachable. With a WYSIWYG editor the read view is a `ControlContent`, so the value reads as a document rather than as editor markup. |
| `ControlLogin` | Ready-made sign-in form. |

## Data & collections

| Control | Description |
| --- | --- |
| `ControlTable` | Sortable, templated data table. |
| `ControlList` | Vertical list of items. |
| `ControlFileList` | List of files with icons and metadata. Files that share a name are folded into one row that unfolds to its earlier versions, and a host may take over the description column to offer an inline editor there. |
| `ControlTile` | Grid of tile cards, each laid out as kicker, title, body and footer. |
| `ControlKanban` | Drag-and-drop kanban board. |
| `ControlDashboard` | Configurable widget dashboard. |
| `ControlTree` | Hierarchical, expandable tree. |
| `ControlPagination` | Page navigation for paged data. |
| `ControlCarousel` | Rotating slideshow of items. |
| `ControlSchedule` | Calendar of time-based items in an agenda, week or month view. |
| `ControlChart` | Line, bar and other charts. |
| `ControlHeatMap` | Read-only grid of values coloured on a gradient. |
| `ControlGraphViewer` | Interactive node/edge graph viewer. |

## Navigation

| Control | Description |
| --- | --- |
| `ControlBreadcrumb` | Path of links to the current location. |
| `ControlSidebar` | Vertical navigation sidebar with collapsible tree items, badges, colors and per-item "..." options menus. |
| `ControlTab` | Tabbed navigation between panels. |
| `ControlPanelNavbar` | Top navigation bar. |
| `ControlQuickfilter` | Inline filter chips - buttons, avatars, dropdowns and multi-selects - for narrowing a result set, plus a chip that creates a new filter. |
| `ControlSearch` | Search box with suggestions. |
| `ControlSearchContent` | Search that highlights matches in the page content. |
| `ControlNavigation` | Grouped navigation menu of links and sections. |

## Feedback, status & overlays

| Control | Description |
| --- | --- |
| `ControlAlert` | Prominent, optionally dismissible message box. |
| `ControlPanelDismissible` | Panel the user can dismiss, staying hidden afterwards. |
| `ControlPanelCallout` | Bordered note that highlights related information. |
| `ControlBadge` | Small count or status label. |
| `ControlTag` | Compact, colored keyword tag. |
| `ControlProgress` | Determinate progress bar. |
| `ControlMultipleProgressBar` | Progress bar split into several colored, labelled segments. |
| `ControlSla` | State of a service level agreement: status, consumed budget and remaining time. |
| `ControlTrafficLight` | Read-only red/yellow/green status indicator. |
| `ControlSpinner` | Indeterminate loading spinner. |
| `ControlSkeleton` | Shimmering placeholder shown while content loads. |
| `ControlEmptyState` | Icon, message and action shown when there is no data. |
| `ControlSteps` | Numbered step/progress indicator, in a row, inline beside its labels, or stacked vertically. |
| `ControlTimeline` | Chronological list of events along a rail. |
| `ControlStat` | Compact metric (KPI) tile with a trend delta. |
| `ControlCardCounter` | Counter card with an icon and a progress bar. |
| `ControlAvatar` | User avatar with image or initials. |
| `ControlAvatarGroup` | Overlapping stack of avatars with a `+N` overflow. |
| `ControlAvatarDropdown` | Avatar with an attached dropdown menu. |
| `ControlPopover` | Click/hover overlay with a title and rich content. |
| `ControlTooltip` | Short hint shown on hover or focus. |
| `ControlModalForm` | Modal dialog hosting a form. |
| `ControlPanelToast` | Transient toast notification. |

## WebApp controls (REST-backed)

| Control | Description |
| --- | --- |
| `ControlDataList` | List bound to a REST endpoint. |
| `ControlDataTable` | Table bound to a REST endpoint, with server paging. |
| `ControlDataTab` | Tabs whose content is loaded on demand. |
| `ControlDataTile` | Tile grid bound to a REST endpoint. |
| `ControlDataFileView` | One set of files in several interchangeable presentations: the tabular file list and a tile board are built in, further ones are added by the page, and all of them render the same files, so switching never re-queries. Descriptions are edited in place, an upload control bound to the view makes a finished upload show up without a reload, and a name that is already there becomes a new version of that file rather than a second entry. |
| `ControlDataKanban` | Kanban board persisted through a REST service. |
| `ControlDataGantt` | Interactive gantt chart with drag-and-drop scheduling and dependency links, persisted via REST. |
| `ControlDataDashboard` | Dashboard of widget columns, loaded and saved via REST: add / rename / resize / recolor / reorder / delete columns and add / configure / delete widgets through "…" menus, with the addable widget types supplied by the server. |
| `ControlDataForm` | Form that loads and submits against a REST endpoint. |
| `ControlDataFormEditor` | Visual editor for building form definitions. |
| `ControlDataWizard` | Multi-step wizard backed by a REST service: a step indicator that reads back the answers, per-step validation, and steps that the server renders on demand or skips. |
| `ControlDataWorkflow` | Visual workflow/state-machine editor. |
| `ControlDataDropdown` | Dropdown whose items are queried from a service. |
| `ControlDataSearch` | Search box whose suggestions come from a REST endpoint, each one a link that opens its target; an empty term offers what the endpoint suggests up front. |
| `ControlDataFormItemInputCascading` | Cascading selection whose levels are fetched from a REST endpoint on demand. |
| `ControlDataAvatarDropdown` | User picker that searches a directory service. |
| `ControlDataSelectionTheme` | Theme picker loaded and persisted via REST. |
| `ControlDataTag` | Tag surface with live add, remove and suggestions. |
| `ControlDataTrafficLight` | Traffic light status loaded and persisted via REST. |
| `ControlDataQuickfilter` | Quickfilter whose definitions come from a service. |
| `ControlDataWqlPrompt` | WQL query prompt with suggestions and history. |
| `ControlAdvancedSearch` | Advanced search built on the WQL prompt. |
| `ControlDataLogin` | Sign-in form that submits credentials via REST. |
| `ControlDataComment` | Comment thread loaded from a REST endpoint. |
| `ControlDataWatcher` | Avatar group of an object's watchers, with live add/remove. |
| `ControlDataPermission` | Group-to-policy assignments of a protected resource (identity model) as a table of groups with inline editable policy chips, an add row, paging and revoke. |
| `ControlDataRelationView` | The semantic relations of one object — *blocks*, *causes*, *references*, *duplicate of*, … — grouped by what the relation says and rendered as a list or as a graph, plus web links to addresses outside the application. Both categories share one generic entity. The add dialog lists the registered link systems, so a system or a relation a plugin contributes appears without a change to the page. |
| `ControlDataRelationEditor` | Administers the relation types of a class: both labels of the relation, the classes it accepts, its cardinality, its effect on the workflow, its usage and whether it may still be used, with an editor that previews the relation from either end and drag-and-drop ordering. |
| `ControlDataScrumBacklog` | Scrum backlog with sprints and drag-and-drop ranking. |
| `ControlDataScrumSprint` | Active sprint overview with a burndown chart. |
| `ControlDataScrumTeam` | Sprint team as an avatar group with a story-point modal. |
| `ControlDataScrumVelocity` | Velocity of the last few sprints as a bar chart. |
| `ControlChat` | Real-time chat surface. |
| `ControlCollaborative` | Live presence and collaborative editing indicators. |
| `ControlProgressTask` | Progress of a long-running background task. |
| `ControlStatusTask` | Status of a long-running background task as a single colored dot (red error, green done, yellow warning, blue running). |
| `ControlSystemMetric` | Live gauge for one system metric of the server (CPU load or memory usage) as a bar or a sparkline chart, pushed over the message queue WebSocket. |
| `ControlMessageQueueStatus` | Live status of the message queue. |
| `ControlPopupNotification` | Toast-style popup notifications. |
