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
| `ControlPanelSplit` | Two resizable panes separated by a draggable splitter. |
| `ControlPanelCenter` | Centers its content horizontally and vertically. |
| `ControlPanelOverflow` | Scrollable region that clips overflowing content. |
| `ControlFrame` | Bordered frame with an optional title around its content. |
| `ControlResponsive` | Shows or hides content based on the viewport breakpoint. |
| `ControlView` | Card-like view with a header, body and footer. |
| `ControlAccordion` | Stack of collapsible sections, one open at a time by default. |
| `ControlOffcanvas` | Drawer panel that slides in from an edge of the viewport. |

## Typography & content

| Control | Description |
| --- | --- |
| `ControlText` | Text with formatting, including inline Markdown. |
| `ControlHtml` | Renders raw, trusted HTML. |
| `ControlCode` | Syntax-highlighted source code block. |
| `ControlLine` | Horizontal divider line. |
| `ControlIcon` | A single icon from the icon set. |
| `ControlImage` | Responsive image with optional link. |
| `ControlLink` | A hyperlink to a route or external URL. |
| `ControlAttribute` | Inline label/value attribute chip. |
| `ControlDescriptionList` | Key/value definition list, vertical or side-by-side. |

## Buttons & actions

| Control | Description |
| --- | --- |
| `ControlButton` | Clickable button that triggers an action or submits a form. |
| `ControlButtonLink` | Link styled as a button. |
| `ControlSplitButton` | Button with an attached dropdown of secondary actions. |
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
| `ControlFormItemInputCombo` | Dropdown selection input. |
| `ControlFormItemInputSlider` | Range slider for numeric input. |
| `ControlFormItemInputRating` | Star rating input. |
| `ControlFormItemInputTrafficLight` | Traffic light status picker (red/yellow/green). |
| `ControlFormItemInputEstimate` | Estimate picked from a configurable scale (e.g. story points). |
| `ControlFormItemInputDate` | Date input with a picker. |
| `ControlFormItemInputCalendar` | Inline calendar selection. |
| `ControlSelection` | Multi-item selection list. |
| `ControlColor` | Color picker. |
| `ControlUpload` | File upload with drag-and-drop. |
| `ControlSmartEdit` | Rich-text (WYSIWYG) editor. |
| `ControlLogin` | Ready-made sign-in form. |

## Data & collections

| Control | Description |
| --- | --- |
| `ControlTable` | Sortable, templated data table. |
| `ControlList` | Vertical list of items. |
| `ControlTile` | Grid of tile cards. |
| `ControlKanban` | Drag-and-drop kanban board. |
| `ControlDashboard` | Configurable widget dashboard. |
| `ControlTree` | Hierarchical, expandable tree. |
| `ControlPagination` | Page navigation for paged data. |
| `ControlCarousel` | Rotating slideshow of items. |
| `ControlChart` | Line, bar and other charts. |
| `ControlGraphViewer` | Interactive node/edge graph viewer. |

## Navigation

| Control | Description |
| --- | --- |
| `ControlBreadcrumb` | Path of links to the current location. |
| `ControlSidebar` | Vertical navigation sidebar. |
| `ControlTab` | Tabbed navigation between panels. |
| `ControlPanelNavbar` | Top navigation bar. |
| `ControlQuickfilter` | Inline filter chips for narrowing a result set. |
| `ControlSearch` | Search box with suggestions. |

## Feedback, status & overlays

| Control | Description |
| --- | --- |
| `ControlAlert` | Prominent, optionally dismissible message box. |
| `ControlPanelCallout` | Bordered note that highlights related information. |
| `ControlBadge` | Small count or status label. |
| `ControlTag` | Compact, colored keyword tag. |
| `ControlProgress` | Determinate progress bar. |
| `ControlTrafficLight` | Read-only red/yellow/green status indicator. |
| `ControlSpinner` | Indeterminate loading spinner. |
| `ControlSkeleton` | Shimmering placeholder shown while content loads. |
| `ControlEmptyState` | Icon, message and action shown when there is no data. |
| `ControlSteps` | Numbered step/progress indicator. |
| `ControlTimeline` | Chronological list of events along a rail. |
| `ControlStat` | Compact metric (KPI) tile with a trend delta. |
| `ControlCardCounter` | Counter card with an icon and a progress bar. |
| `ControlAvatar` | User avatar with image or initials. |
| `ControlAvatarGroup` | Overlapping stack of avatars with a `+N` overflow. |
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
| `ControlDataKanban` | Kanban board persisted through a REST service. |
| `ControlDataDashboard` | Dashboard whose layout is loaded and saved via REST. |
| `ControlDataForm` | Form that loads and submits against a REST endpoint. |
| `ControlDataFormEditor` | Visual editor for building form definitions. |
| `ControlDataWizard` | Multi-step wizard backed by a REST service. |
| `ControlDataWorkflow` | Visual workflow/state-machine editor. |
| `ControlDataDropdown` | Dropdown whose items are queried from a service. |
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
| `ControlDataScrumBacklog` | Scrum backlog with sprints and drag-and-drop ranking. |
| `ControlDataScrumSprint` | Active sprint overview with a burndown chart. |
| `ControlDataScrumTeam` | Sprint team as an avatar group with a story-point modal. |
| `ControlDataScrumVelocity` | Velocity of the last few sprints as a bar chart. |
| `ControlChat` | Real-time chat surface. |
| `ControlCollaborative` | Live presence and collaborative editing indicators. |
| `ControlProgressTask` | Progress of a long-running background task. |
| `ControlMessageQueueStatus` | Live status of the message queue. |
| `ControlPopupNotification` | Toast-style popup notifications. |
