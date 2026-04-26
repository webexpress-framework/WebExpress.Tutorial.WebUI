using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST API that serves the field catalog for the visual form editor.
    /// Responds at <c>/api/1/FormFieldCatalog</c> with a JSON object
    /// <c>{ "fields": [ { "id": "...", "type": "..." }, … ] }</c>.
    /// </summary>
    [Title("Form field catalog")]
    public sealed class FormFieldCatalog : IRestApi
    {
        private static readonly JsonSerializerOptions _jsonOptions = new() { WriteIndented = true };
        private static readonly object[] _fields =
        [
            new { id = "Name",        type = "string"    },
            new { id = "Description", type = "text"      },
            new { id = "Email",       type = "string"    },
            new { id = "AppearsIn",   type = "ref"       },
            new { id = "Groups",      type = "tags"      },
            new { id = "Icon",        type = "file"      },
            new { id = "Status",      type = "enum"      },
            new { id = "Affiliation", type = "enum"      },
            new { id = "DueDate",     type = "timestamp" },
            new { id = "Priority",    type = "enum"      },
            new { id = "Weapon",      type = "string"    },
            new { id = "IslandOrigin",type = "ref"       }
        ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public FormFieldCatalog()
        {
        }

        /// <summary>
        /// Returns the field catalog as <c>{ "fields": [ … ] }</c>.
        /// </summary>
        /// <param name="request">The incoming request.</param>
        /// <returns>200 OK with the catalog JSON.</returns>
        [Method(RequestMethod.GET)]
        public IResponse Retrieve(IRequest request)
        {
            var json = JsonSerializer.Serialize(new { fields = _fields }, _jsonOptions);
            var content = Encoding.UTF8.GetBytes(json);

            return new ResponseOK
            {
                Content = content
            }
                .AddHeaderContentType("application/json");
        }
    }
}
