namespace OpenRec_2.API;

using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;

public class ConfigV2Api : IApi
{
    public string Response(HttpContext context)
    {
        var config = new Config2
        {
            MessageOfTheDay = "Welcome to OpenRec-2!",
            CdnBaseUri = "http://localhost:5229/",
            LevelProgressionMaps = GetLevelProgressionMaps(),
            MatchmakingParams = new MatchmakingConfigParams
            {
                PreferEmptyRoomsFrequency = 0f,
                PreferFullRoomsFrequency = 1f
            },
            DailyObjectives = GetDailyObjectives(),
            ConfigTable = new List<ConfigTableEntry>
            {
                new ConfigTableEntry
                {
                    Key = "Gift.DropChance",
                    Value = 0.5f.ToString()
                },
                new ConfigTableEntry
                {
                    Key = "Gift.XP",
                    Value = 0.5f.ToString()
                }
            },
            PhotonConfig = new PhotonConfig
            {
                CloudRegion = "us",
                CrcCheckEnabled = false,
                EnableServerTracingAfterDisconnect = false
            }
        };

        return JsonConvert.SerializeObject(config);
    }

    public string GetUrl()
    {
        return "/api/config/v2";
    }

    public string GetMethod()
    {
        return HttpMethods.Get;
    }

    private List<LevelProgressionEntry> GetLevelProgressionMaps()
    {
        var maps = new List<LevelProgressionEntry>();
        for (int i = 0; i <= 20; i++)
        {
            maps.Add(new LevelProgressionEntry
            {
                Level = i,
                RequiredXp = i + 1
            });
        }
        return maps;
    }

    private Objective[][] GetDailyObjectives()
    {
        var objectives = new Objective[7][];
        for (int i = 0; i < 7; i++)
        {
            objectives[i] = new Objective[]
            {
                new Objective { type = 20, score = 1 },
                new Objective { type = 21, score = 1 },
                new Objective { type = 22, score = 1 }
            };
        }
        return objectives;
    }

    public class Config2
    {
        public string MessageOfTheDay { get; set; }
        public string CdnBaseUri { get; set; }
        public List<LevelProgressionEntry> LevelProgressionMaps { get; set; }
        public MatchmakingConfigParams MatchmakingParams { get; set; }
        public Objective[][] DailyObjectives { get; set; }
        public List<ConfigTableEntry> ConfigTable { get; set; }
        public PhotonConfig PhotonConfig { get; set; }
    }

    public class LevelProgressionEntry
    {
        public int Level { get; set; }
        public int RequiredXp { get; set; }
    }

    public class MatchmakingConfigParams
    {
        public float PreferEmptyRoomsFrequency { get; set; }
        public float PreferFullRoomsFrequency { get; set; }
    }

    public class Objective
    {
        public int type { get; set; }
        public int score { get; set; }
    }

    public class ConfigTableEntry
    {
        public string Key { get; set; }
        public string Value { get; set; }
    }

    public class PhotonConfig
    {
        public string CloudRegion { get; set; }
        public bool CrcCheckEnabled { get; set; }
        public bool EnableServerTracingAfterDisconnect { get; set; }
    }
}