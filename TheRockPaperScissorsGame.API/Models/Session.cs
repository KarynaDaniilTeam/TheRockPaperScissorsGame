﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;
using TheRockPaperScissorsGame.API.Enums;
using TheRockPaperScissorsGame.API.Exceptions;

namespace TheRockPaperScissorsGame.API.Models
{
    public class Session
    {
        private TimeSpan _connectionTimeOut = TimeSpan.FromMinutes(5);

        public Session(GameOptions options, string login)
        {
            SessionStart = DateTime.UtcNow;
            Player1Login = login;
            RoomNumber = Guid.NewGuid().ToString();
            Rounds = new List<Round>();
            //IsBot = options....
        }

        [JsonPropertyName("roomNumber")]
        public string RoomNumber { get; set; }

        [JsonPropertyName("roomType")]
        public RoomType RoomType { get; set; }

        [JsonPropertyName("rounds")]
        public List<Round> Rounds { get; set; }

        public bool IsFinished { get; set; }

        public DateTime SessionStart { get; set; }

        public string Player1Login { get; set; }

        public string Player2Login { get; set; }

        public bool IsBot { get; set; }

        public bool RivalFound
        {
            get
            {
                var result =  IsBot || Player2Login != null;
                if(!result && DateTime.UtcNow - SessionStart >= _connectionTimeOut)
                {
                    throw new GameFinishedException(GameEndReason.ConnectionTimeOut);
                }
                return result;
            }
        }
    }
}
