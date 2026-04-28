using System;
using System.Collections.Generic;
using WebExpress.Tutorial.WebUI.Model;
using WebExpress.WebApp.WebRestApi;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebIndex.Queries;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST API for loading and persisting form structures used by the visual
    /// form editor. Responds at <c>/api/1/FormStructure/item/{id}</c>.
    /// GET returns the structure; PUT saves it and increments the version.
    /// </summary>
    [Title("Form structure")]
    public sealed class FormEditor : RestApiFormEditor<Game>
    {
        private static readonly RestApiFormEditorFieldItem[] _fields =
        [
            new RestApiFormEditorFieldItem{ Id = "Name",        Label = "Name",        Type = "string"    },
            new RestApiFormEditorFieldItem{ Id = "Description", Label = "Description", Type = "text"      },
            new RestApiFormEditorFieldItem{ Id = "Email",       Label = "Email",       Type = "string"    },
            new RestApiFormEditorFieldItem{ Id = "AppearsIn",   Label = "AppearsIn",   Type = "ref"       },
            new RestApiFormEditorFieldItem{ Id = "Groups",      Label = "Groups",      Type = "tags"      },
            new RestApiFormEditorFieldItem{ Id = "Icon",        Label = "Icon",        Type = "file"      },
            new RestApiFormEditorFieldItem{ Id = "Status",      Label = "Status",      Type = "enum"      },
            new RestApiFormEditorFieldItem{ Id = "Affiliation", Label = "Affiliation", Type = "enum"      },
            new RestApiFormEditorFieldItem{ Id = "DueDate",     Label = "DueDate",     Type = "timestamp" },
            new RestApiFormEditorFieldItem{ Id = "Weapon",      Label = "Weapon",      Type = "string"    },
            new RestApiFormEditorFieldItem{ Id = "IslandOrigin",Label = "IslandOrigin",Type = "ref"       }
        ];

        private static readonly Dictionary<string, RestApiFormEditorItem> _store = new(StringComparer.OrdinalIgnoreCase)
        {
            ["00000000-0000-0000-0000-000000000001"] = CreateSampleStructure()
        };

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FormEditor()
        {
        }

        /// <summary>
        /// Retrieves a catalog of form editor field items based on the specified query context and request parameters.
        /// </summary>
        /// <param name="context">
        /// The query context that provides information about the current data retrieval operation. Cannot be null.
        /// </param>
        /// <param name="request">
        /// The request containing parameters that influence which catalog items are retrieved. Cannot be null.
        /// </param>
        /// <returns>
        /// An enumerable collection of catalog field items that match the specified context and request. The 
        /// collection may be empty if no items are found.
        /// </returns>
        protected override IEnumerable<RestApiFormEditorFieldItem> RetrieveCatalog(IQueryContext context, IRequest request)
        {
            return _fields;
        }

        /// <summary>
        /// Retrieves the form editor item associated with the specified form identifier.
        /// </summary>
        /// <param name="formId">
        /// The unique identifier of the form to retrieve. Cannot be null.
        /// </param>
        /// <param name="context">
        /// The query context used for retrieving the item. Provides contextual information for 
        /// the operation.
        /// </param>
        /// <param name="request">
        /// The request object containing details about the current API request.
        /// </param>
        /// <returns>
        /// The form editor item associated with the specified form identifier, or null if no 
        /// item is found.
        /// </returns>
        protected override RestApiFormEditorItem RetrieveItem(string formId, IQueryContext context, IRequest request)
        {
            return _store.TryGetValue(formId, out var item) ? item : null;
        }

        /// <summary>
        /// Updates the specified form element in the data store and increments its version number.
        /// </summary>
        /// <param name="formId">
        /// The unique identifier of the form whose element should be updated. Must not be null or empty.
        /// </param>
        /// <param name="item">
        /// The form element to update. Its version number is automatically incremented.
        /// </param>
        /// <param name="context">
        /// The query context used to execute the operation.
        /// </param>
        /// <param name="request">
        /// The current request object containing contextual information about the operation.
        /// </param>
        /// <returns>
        /// The updated form element with the new version number.
        /// </returns>
        protected override RestApiFormEditorItem UpdateItem(string formId, RestApiFormEditorItem item, IQueryContext context, IRequest request)
        {
            item.Version = (_store.TryGetValue(formId, out var existing) ? existing.Version : 0) + 1;
            _store[formId] = item;
            return item;
        }

        /// <summary>
        /// Creates a sample structure for a form editor with predefined fields, groups, and tabs.
        /// </summary>
        /// <returns>
        /// A <see cref="RestApiFormEditorItem"/> object that contains an example configuration
        /// for a form editor.
        /// </returns>
        private static RestApiFormEditorItem CreateSampleStructure()
        {
            return new RestApiFormEditorItem
            {
                FormId = "00000000-0000-0000-0000-000000000001",
                FormName = "Monkey Island Character",
                ClassName = "Character",
                Version = 1,
                Tabs =
                [
                    new RestApiFormEditorTabItem
                    {
                        Id = "t_details",
                        Name = "Details",
                        Children =
                        [
                            new RestApiFormEditorFieldItem
                            {
                                Id = "n_name",
                                Label = "Name",
                                Type = "string",
                                Required = true,
                                Help = "Full pirate name of the character."
                            },
                            new RestApiFormEditorFieldItem
                            {
                                Id = "n_description",
                                Label = "Description",
                                Type = "text",
                                Required = false,
                                Help = "A short characterization of the pirate."
                            },
                            new RestApiFormEditorGroupItem
                            {
                                Id = "n_contact_group",
                                Label = "Contact",
                                Layout = "vertical",
                                Children =
                                [
                                    new RestApiFormEditorFieldItem
                                    {
                                        Id = "n_email",
                                        Label = "Email",
                                        Type = "string",
                                        Required = false
                                    }
                                ]
                            }
                        ]
                    },
                    new RestApiFormEditorTabItem
                    {
                        Id = "t_relations",
                        Name = "Relations",
                        Children =
                        [
                            new RestApiFormEditorFieldItem
                            {
                                Id = "n_appears_in",
                                Label = "AppearsIn",
                                Type = "ref",
                                Required = false,
                                Help = "Games the character appears in."
                            },
                            new RestApiFormEditorFieldItem
                            {
                                Id = "n_groups",
                                Label = "Groups",
                                Type = "tags",
                                Required = false,
                                Help = "Pirate factions this character belongs to."
                            }
                        ]
                    },
                    new RestApiFormEditorTabItem
                    {
                        Id = "t_assets",
                        Name = "Assets",
                        Children =
                        [
                            new RestApiFormEditorFieldItem
                            {
                                Id = "n_icon",
                                Label = "Icon",
                                Type = "file",
                                Required = false,
                                Help = "Portrait image of the character."
                            }
                        ]
                    }
                ]
            };
        }
    }
}
