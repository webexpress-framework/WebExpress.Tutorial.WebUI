using WebExpress.WebUI.WebControl;

namespace WebExpress.Tutorial.WebUI.WebControl
{
    /// <summary>  
    /// Represents an example implementation of a modal control.  
    /// This class inherits from <see cref="ControlModal"/> and can be used to demonstrate or extend modal functionality.  
    /// </summary>  
    public class ControlModalExample : ControlModal
    {
        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the modal control.</param>
        public ControlModalExample(string id)
            : base(id)
        {
            Header = "Modal dialog";

            Add(new ControlText()
            {
                Text = "One point twenty-one gigawatts. One point twenty-one gigawatts. Great Scott. You're gonna break his arm. Biff, leave him alone. Let him go. Let him go. What was it, George, bird watching? Oh, great scott. You get the cable, I'll throw the rope down to you. It's safe now. Everything's lead lined. Don't you lose those tapes now, we'll need a record. Wup, wup, I almost forgot my luggage. Who knows if they've got cotton underwear in the future. I'm allergic to all synthetics."
            },
            new ControlText()
            {
                Text = "Yeah, where does he live? Say that again. Hello. That was the day I invented time travel. I remember it vividly. I was standing on the edge of my toilet hanging a clock, the porces was wet, I slipped, hit my head on the edge of the sink. And when I came to I had a revelation, a picture, a picture in my head, a picture of this. This is what makes time travel possible. The flux capacitor. Yes, yes, I'm George, George McFly, and I'm your density. I mean, I'm your destiny."
            },
            new ControlText()
            {
                Text = "Quiet down, I'm sure the car is fine. Hey, hey, keep rolling, keep rolling there. No, no, no, no, this sucker's electrical. But I need a nuclear reaction to generate the one point twenty-one gigawatts of electricity that I need. The only way we're gonna get those two to successfully meet is if they're alone together. So you've got to get your father and mother to interact at some sort of social- Huh? You guys, take him in back and I'll be right there. Well c'mon, this ain't no peep show."
            });
        }
    }
}
