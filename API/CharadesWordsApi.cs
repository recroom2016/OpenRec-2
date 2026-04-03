namespace OpenRec_2.API;

using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

public class CharadesWordsApi : IApi
{
    public string Response(HttpContext context)
    {
        List<Word> value = new List<Word>
        {
            new Word { EN_US = "talking ben", Difficulty = 0 },
            new Word { EN_US = "lemon", Difficulty = 0 },
            new Word { EN_US = "grape", Difficulty = 0 },
            new Word { EN_US = "roblox", Difficulty = 0 },
            new Word { EN_US = "tree", Difficulty = 0 },
            new Word { EN_US = "cloud", Difficulty = 0 },
            new Word { EN_US = "iphone", Difficulty = 0 },
            new Word { EN_US = "your house", Difficulty = 0 },
            new Word { EN_US = "spaghetti", Difficulty = 0 },
            new Word { EN_US = "lean", Difficulty = 0 },
            new Word { EN_US = "bitcoin", Difficulty = 0 },
            new Word { EN_US = "nft", Difficulty = 0 },
            new Word { EN_US = "grass", Difficulty = 0 },
            new Word { EN_US = "recroom2016", Difficulty = 0 },
            new Word { EN_US = "joker", Difficulty = 0 },
            new Word { EN_US = "fortnite", Difficulty = 0 },
            new Word { EN_US = "woman", Difficulty = 0 },
            new Word { EN_US = "spiderman", Difficulty = 0 },
            new Word { EN_US = "vr", Difficulty = 0 },
            new Word { EN_US = "among us", Difficulty = 0 },
            new Word { EN_US = "coach", Difficulty = 0 },
            new Word { EN_US = "coach with a gun", Difficulty = 0 },
            new Word { EN_US = "funny fish", Difficulty = 0 },
            new Word { EN_US = "skinwalker", Difficulty = 0 },
            new Word { EN_US = "christmas tree", Difficulty = 0 },
            new Word { EN_US = "ur mom", Difficulty = 0 },
            new Word { EN_US = "stick of ram", Difficulty = 0 },
            new Word { EN_US = "big mac", Difficulty = 0 },
            new Word { EN_US = "ninetndo switch", Difficulty = 0 },
            new Word { EN_US = "crescendo", Difficulty = 0 },
            new Word { EN_US = "boxing", Difficulty = 0 },
            new Word { EN_US = "angry birds", Difficulty = 0 }
        };
        
        return JsonConvert.SerializeObject(value);
    }

    public string GetUrl()
    {
        return "/api/activities/charades/v1/words";
    }

    public string GetMethod()
    {
        return HttpMethods.Get;
    }

    private class Word
    {
        public string EN_US { get; set; }
        public int Difficulty { get; set; }
    }
}