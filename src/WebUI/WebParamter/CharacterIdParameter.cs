using WebExpress.WebCore.WebParameter;

namespace WebExpress.Tutorial.WebUI.WebParamter
{
    /// <summary>
    /// Represents a parameter that specifies a character value for 
    /// use in URL-based requests.
    /// </summary>
    public class CharacterIdParameter : Parameter
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public CharacterIdParameter()
            : base("Character", null, ParameterScope.Url)
        {
        }

        /// <summary>
        /// Initializes a new instance of the class with a specified value.
        /// </summary>
        /// <param name="value">The value of the parameter.</param>
        public CharacterIdParameter(string value)
            : base("Character", value, ParameterScope.Url)
        {
        }
    }
}
