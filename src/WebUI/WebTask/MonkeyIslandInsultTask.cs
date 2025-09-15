using System.Collections.Generic;
using System.Threading;
using WebExpress.WebCore.WebAttribute;
using WebExpress.WebCore.WebRestApi;
using WebExpress.WebCore.WebTask;


namespace WebExpress.Tutorial.WebUI.WebTask
{
    /// <summary>
    /// A task that simulates progress using Monkey Island sword-fighting insults.
    /// </summary>
    [Title("Monkey Island insult progress")]
    [Method(CrudMethod.GET)]
    public sealed class MonkeyIslandInsultTask : Task
    {
        private int _insultIndex = 0;

        // famous Monkey Island insults used as progress indicators
        private static readonly List<string> Insults =
        [
            "You fight like a dairy farmer!",
            "How appropriate. You fight like a cow.",
            "I've spoken with apes more polite than you!",
            "You have the manners of a beggar.",
            "My sword will put you in your place!",
            "You're no match for my brains, you poor fool.",
            "I’ve seen better fencing in a nursery!",
            "You're as repulsive as a monkey in a negligee.",
            "Your swordplay is as dull as your wit!",
            "You swing like a drunken octopus!",
            "Even a parrot could outwit you!",
            "Your insults are as outdated as floppy disks!",
            "You couldn’t fence your way out of a paper bag!",
            "I’ve met sea slugs with more backbone!",
            "Your breath would sink a ship!",
            "You call that an insult? I've heard better from cabin boys!",
            "Your technique reminds me of a confused jellyfish!",
            "You fight like someone who’s never seen a sword before!",
            "Your mother wears combat boots... and fights better than you!",
            "You're the reason rum was invented!",
            "You duel like a landlubber on roller skates!",
            "Your reflexes are slower than molasses in January!"
        ];

        /// <summary>
        /// Initializes a new instance of the class.
        /// </summary>
        /// <param name="id">The unique identifier for the task.</param>
        /// <param name="args">Optional arguments for the task.</param>
        public MonkeyIslandInsultTask(string id, params object[] args)
            : base(id, args)
        {
        }

        /// <summary>
        /// Overrides the processing logic to simulate insult-based progress.
        /// </summary>
        protected override void OnProcess()
        {
            State = TaskState.Run;

            for (int i = 0; i < Insults.Count; i++)
            {
                if (State == TaskState.Canceled)
                {
                    return;
                }

                Progress = (int)((i + 1) / (float)Insults.Count * 100);
                Message = Insults[_insultIndex];
                _insultIndex = (_insultIndex + 1) % Insults.Count;

                // simulate work
                Thread.Sleep(1000);
            }

            Message = "You’ve survived the duel of wits and emerged victorious... for now.";

            State = TaskState.Finish;
        }
    }
}
