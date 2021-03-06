﻿using Framework.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Framework.Services
{
    public class LocalPlayerService : IPlayerService
    {
        public LocalPlayerService()
        {
            _playerStats = DeserializeLocalJson();
        }

        readonly List<PlayerStats> _playerStats;

        public List<PlayerStats> GetAllPlayerStats()
        {
            return _playerStats;
        }

        public PlayerStats GetPlayerStatsById(int id)
        {
            return _playerStats.FirstOrDefault(p => p.Id == id);
        }

        public PlayerStats GetPlayerStatsByName(string name)
        {
            return _playerStats.FirstOrDefault(p => p.Name == name);
        }

        private List<PlayerStats> DeserializeLocalJson()
        {
            dynamic json = JsonConvert.DeserializeObject(
                File.ReadAllText($"{Environment.CurrentDirectory}/Framework/Data/tournamentPlayerStats.json")
            );

            return json["stats"].ToObject<List<PlayerStats>>();
        }
    }
}
