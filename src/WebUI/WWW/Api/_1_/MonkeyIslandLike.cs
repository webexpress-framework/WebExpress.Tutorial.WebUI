using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebMessage;
using WebExpress.WebCore.WebRestApi;

namespace WebExpress.Tutorial.WebUI.WWW.Api._1_
{
    /// <summary>
    /// REST endpoint the <c>ControlLike</c> demo posts to. It keeps the counts in memory - the
    /// tutorial has nothing to persist to - and answers the contract the control expects:
    /// <c>{ "value": "8", "active": true }</c>, the new count and whether the caller is among it.
    /// </summary>
    /// <remarks>
    /// <para>
    /// It toggles rather than taking a state, because the only caller is a figure showing the
    /// current state and a reader clicking it. There is one caller here, so "the caller" is
    /// simply whoever is clicking: a real application resolves an identity and stores a like per
    /// person, which is what makes the withdrawal of a like possible at all.
    /// </para>
    /// <para>
    /// The store is also what the demo page renders its figures from, rather than each figure
    /// carrying a literal of its own. A page that shows six and an endpoint that starts at zero
    /// answer one on the first click, and the figure jumps backwards - the very drift between
    /// the rendered count and the stored one the control exists to avoid.
    /// </para>
    /// </remarks>
    [Segment("like")]
    [Title("Like a Monkey Island subject")]
    public sealed class MonkeyIslandLike : IRestApi
    {
        /// <summary>
        /// The control posts lowercase json and the deserializer matches property names
        /// case-sensitively, so without this every subject reads as null, every figure falls
        /// back to one shared counter, and each one answers the same count no matter which was
        /// clicked.
        /// </summary>
        private static readonly JsonSerializerOptions _jsonOptions = new()
        {
            PropertyNameCaseInsensitive = true
        };

        /// <summary>
        /// The counts and states, by subject. Static because the endpoint is instantiated per
        /// request and the tutorial has no store behind it. Count and state live in one entry so
        /// a toggle moves both under a single atomic update; two dictionaries could be seen
        /// half-updated by a concurrent reader.
        /// </summary>
        /// <remarks>
        /// The seeds are the figures the demo page starts from. They are here rather than on the
        /// page because the endpoint answers with the stored count, so the stored count is what
        /// the page has to render to stay in step with it.
        /// </remarks>
        private static readonly ConcurrentDictionary<string, LikeState> _states = new(
        [
            new KeyValuePair<string, LikeState>("demo", new LikeState(6, false)),
            new KeyValuePair<string, LikeState>("uri", new LikeState(3, false)),
            new KeyValuePair<string, LikeState>("grog", new LikeState(0, false)),
            new KeyValuePair<string, LikeState>("swordfight", new LikeState(0, false)),
            new KeyValuePair<string, LikeState>("active", new LikeState(12, true)),
            new KeyValuePair<string, LikeState>("heart", new LikeState(9, false)),
            new KeyValuePair<string, LikeState>("star", new LikeState(4, false))
        ]);

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        public MonkeyIslandLike()
        {
        }

        /// <summary>
        /// Returns the count the named subject stands at, for the page rendering the figure.
        /// </summary>
        /// <param name="subject">The subject being liked.</param>
        /// <returns>The current count, or zero for a subject nothing has been posted for.</returns>
        public static int Count(string subject)
        {
            return _states.TryGetValue(subject, out var state) ? state.Count : 0;
        }

        /// <summary>
        /// Returns whether the reader is among the count of the named subject, for the page
        /// rendering the figure in its pressed state.
        /// </summary>
        /// <param name="subject">The subject being liked.</param>
        /// <returns>True when the reader has joined the subject.</returns>
        public static bool IsJoined(string subject)
        {
            return _states.TryGetValue(subject, out var state) && state.Joined;
        }

        /// <summary>
        /// Handles <c>POST {base}</c>: flips the like on the named subject.
        /// </summary>
        /// <param name="request">The request carrying <c>{ "subject": "…" }</c>.</param>
        /// <returns>The new count and state as JSON.</returns>
        [Method(RequestMethod.POST)]
        public IResponse Toggle(Request request)
        {
            var subject = ReadSubject(request) ?? "default";

            var state = _states.AddOrUpdate
            (
                subject,
                _ => new LikeState(1, true),
                (_, current) => current.Joined
                    ? new LikeState(current.Count - 1, false)
                    : new LikeState(current.Count + 1, true)
            );

            var json = JsonSerializer.Serialize(new { value = state.Count.ToString(), active = state.Joined });

            return new ResponseOK { Content = Encoding.UTF8.GetBytes(json) }
                .AddHeaderContentType("application/json");
        }

        /// <summary>
        /// Reads the subject out of the posted body.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <returns>The subject, or null when the body names none.</returns>
        private static string ReadSubject(Request request)
        {
            var content = request?.Content;

            if (content is null || content.Length == 0)
            {
                return null;
            }

            try
            {
                var payload = JsonSerializer.Deserialize<LikePayload>(Encoding.UTF8.GetString(content), _jsonOptions);

                return payload?.Subject;
            }
            catch (JsonException)
            {
                return null;
            }
        }

        /// <summary>
        /// What a subject stands at: the count, and whether the reader is among it.
        /// </summary>
        /// <param name="Count">The number of likes.</param>
        /// <param name="Joined">Whether the reader has joined.</param>
        private sealed record LikeState(int Count, bool Joined);

        /// <summary>
        /// The body of a like request.
        /// </summary>
        private sealed class LikePayload
        {
            /// <summary>
            /// Gets or sets the subject being liked.
            /// </summary>
            public string Subject { get; set; }
        }
    }
}
