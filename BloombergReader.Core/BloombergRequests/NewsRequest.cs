using BloombergReader.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloombergReader.Core.BloombergRequests
{
    public class NewsRequest
    {
        public List<Story> GetNews()
        {
            return new List<Story>()
            {
                new Story
                {
                    Headline = "Markets Recover After Initial Panic",
                    Text = @"It wasn’t the first roller-coaster ride for markets in 2016, but it’s certainly up there.

    Investors worldwide initially reacted in shock to the victory of Republican Donald Trump over Democratic opponent Hillary Clinton in the 2016 contest for the White House. Global financial markets plummeted in the wake of Donald Trump’s victory in the early hours of Wednesday.

    But as the dust settled, the markets retreated from sharp losses after traders seemingly came to the conclusion that the overnight panic was not warranted. After the initial panic, leading European and U.S. equity indices amazingly ended the day in positive territory...

    "
                },
                new Story
                {
                    Headline = "New Year, New Deutsche Bank",
                    Text = @"The Deutsche Bank board plans to meet in January to revise the current strategy, sources told Handelsblatt.

    The bank wants to move forward, even though it still has not come to an agreement with the U.S. over its trades in Russia.

    The focus on strategy comes days after the bank reached a verbal agreement with the U.S. Justice Department, to pay a penalty of $7.2 billion (€6.9 billion) for its role in miss-selling mortgages...
    "
                }
            };
        }
    }
}
