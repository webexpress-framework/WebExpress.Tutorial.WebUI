using System.Collections.Generic;

namespace WebUI.Model
{
    /// <summary>
    /// Provides a static view model containing sample table data for demonstration or testing purposes.
    /// </summary>
    public static class ViewModel
    {
        /// <summary>
        /// Returns a collection of sample table data.
        /// </summary>
        public static List<Character> MonkeyIslandCharacters { get; } = [.. GetMonkeyIslandCharacters()];

        /// <summary>
        /// Retrieves a collection of characters from the Monkey Island universe.
        /// </summary>
        /// <returns>An enumerable of objects, each representing a notable character from the Monkey Island series.</returns>
        private static IEnumerable<Character> GetMonkeyIslandCharacters()
        {
            // Monkey Island universe sample data
            yield return new Character
            {
                Name = "Guybrush Threepwood",
                Description = "A determined yet clumsy wannabe pirate with sharp wit.",
                AppearsIn = "The Secret of Monkey Island (1990) and all sequels"
            };

            yield return new Character
            {
                Name = "LeChuck",
                Description = "A vengeful ghost/zombie/demon pirate obsessed with Elaine Marley.",
                AppearsIn = "The Secret of Monkey Island (1990) and all sequels"
            };

            yield return new Character
            {
                Name = "Elaine Marley",
                Description = "The intelligent and fearless governor of Mêlée Island.",
                AppearsIn = "The Secret of Monkey Island (1990) and all sequels"
            };

            yield return new Character
            {
                Name = "Murray",
                Description = "A talking skull with sinister world domination ambitions.",
                AppearsIn = "The Curse of Monkey Island (1997) and later titles"
            };

            yield return new Character
            {
                Name = "Stan S. Stanman",
                Description = "An over-the-top salesman who can sell anything, even used coffins.",
                AppearsIn = "The Secret of Monkey Island (1990) and sequels"
            };

            yield return new Character
            {
                Name = "Herman Toothrot",
                Description = "An eccentric castaway who was stranded on Monkey Island for years.",
                AppearsIn = "The Secret of Monkey Island (1990) and others"
            };

            yield return new Character
            {
                Name = "Carla",
                Description = "A highly skilled swordmaster with an intimidating presence.",
                AppearsIn = "The Secret of Monkey Island (1990) and others"
            };

            yield return new Character
            {
                Name = "Wally",
                Description = "A timid cartographer who often gets caught up in adventures.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991) and others"
            };

            yield return new Character
            {
                Name = "Captain Madison",
                Description = "A cunning member of the pirate council in Mêlée Island.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Otis",
                Description = "A jail inmate with a weakness for mint candies.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "Fester Shinetop",
                Description = "A corrupt sheriff of Mêlée Island secretly working with LeChuck.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "The Voodoo Lady",
                Description = "A mysterious woman with vast knowledge of magic and prophecies.",
                AppearsIn = "The Secret of Monkey Island (1990) and all sequels"
            };

            yield return new Character
            {
                Name = "Meathook",
                Description = "A fearsome pirate with hooks instead of hands.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "Bob the Ghost Pirate",
                Description = "LeChuck’s loyal ghostly henchman.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "Kate Capsize",
                Description = "A sharp businesswoman and boat captain.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Griswold Goodsoup",
                Description = "A hotel owner with a dark family history.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Baron Saturday",
                Description = "A mysterious character with voodoo-like abilities.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Cutthroat Bill",
                Description = "A tough and silent pirate with a menacing presence.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Haggis McMutton",
                Description = "A burly Scottish pirate who prefers caber tossing over sword fights.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Edward Van Helgen",
                Description = "A charismatic pirate who enjoys dueling and playing the banjo.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Charles L. Charles",
                Description = "LeChuck's alter ego as he runs for Governor.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Ignatius Cheese",
                Description = "An eccentric chess player and owner of the pirate museum.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Marco De Pollo",
                Description = "A skilled acrobat and champion of the Ultimate Insult contest.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "King André",
                Description = "A ruthless smuggler who sells valuable loot, including a diamond.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Kenny Falmouth",
                Description = "A young aspiring pirate who sells lemonade for a living.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Mad Marty",
                Description = "The energetic laundry operator who keeps the goods spinning.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Peepwind",
                Description = "A shipwright who specializes in customizing pirate ships.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Deadeye Dave",
                Description = "A blind jeweler who has an uncanny ability to appraise valuables.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Madame Xima",
                Description = "A fortune teller who speaks in riddles and cryptic messages.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "The Pirates of Low Moral Fiber",
                Description = "A trio of dubious pirates with questionable integrity and drinking habits.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "The Cook from Scabb Island",
                Description = "An angry tavern cook who despises Guybrush and protects his stew fiercely.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Hellbeard",
                Description = "A ghostly pirate captain with a sinister reputation.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Lila",
                Description = "A mischievous thief known for stealing valuable artifacts.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Deep Gut",
                Description = "A mysterious informant who helps Guybrush uncover secrets.",
                AppearsIn = "Tales of Monkey Island (2009)"
            };

            yield return new Character
            {
                Name = "Trenchant Caprice",
                Description = "A sharp-tongued pirate known for witty insults and dueling skills.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Gregory Percival",
                Description = "An eccentric historian who collects tales of legendary pirates.",
                AppearsIn = "Tales of Monkey Island (2009)"
            };

            yield return new Character
            {
                Name = "Captain Blondebeard",
                Description = "An eccentric chicken-loving pirate chef.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Lemonhead",
                Description = "A cannibal from Monkey Island with a refined sense of etiquette.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "Franky",
                Description = "A ghost pirate under LeChuck’s command.",
                AppearsIn = "The Secret of Monkey Island (1990)"
            };

            yield return new Character
            {
                Name = "Mr. Fossey",
                Description = "A creepy hotel manager obsessed with his establishment’s prestige.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Horatio Torquemada Marley",
                Description = "Elaine’s ancestor, a famous explorer and treasure hunter.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Brittany",
                Description = "A fierce pirate with ambitions of ruling the seas.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Slappy Cromwell",
                Description = "A playwright known for his terrible scripts.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Little LeChuck",
                Description = "A mischievous young version of LeChuck haunting Guybrush.",
                AppearsIn = "Tales of Monkey Island (2009)"
            };

            yield return new Character
            {
                Name = "Hank Plank",
                Description = "A cursed sailor doomed to sink every ship he boards.",
                AppearsIn = "The Curse of Monkey Island (1997)"
            };

            yield return new Character
            {
                Name = "Miss Rivers",
                Description = "An outspoken bartender with extensive pirate knowledge.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Granny Weatherwax",
                Description = "A fortune teller with a knack for vague predictions.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Horrible Hector",
                Description = "A pirate who specializes in intimidation.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Wicked Wanda",
                Description = "A notorious pirate feared across the Caribbean.",
                AppearsIn = "Return to Monkey Island (2022)"
            };

            yield return new Character
            {
                Name = "Captain Dread",
                Description = "A laid-back Jamaican pirate with a love for reggae.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Largo LaGrande",
                Description = "LeChuck’s thuggish enforcer with a mean streak.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };

            yield return new Character
            {
                Name = "Father Ignacio",
                Description = "A priest turned pirate with questionable morals.",
                AppearsIn = "Tales of Monkey Island (2009)"
            };

            yield return new Character
            {
                Name = "Mad Monty",
                Description = "A pirate entertainer known for dangerous stunts.",
                AppearsIn = "Escape from Monkey Island (2000)"
            };

            yield return new Character
            {
                Name = "Rapp Scallion",
                Description = "A ghost pirate who once ran the best weenie hut in town.",
                AppearsIn = "Monkey Island 2: LeChuck’s Revenge (1991)"
            };
        }
    }
}
