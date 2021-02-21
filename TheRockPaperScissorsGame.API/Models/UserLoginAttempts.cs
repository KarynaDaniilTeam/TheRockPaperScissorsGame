﻿using System;
namespace TheRockPaperScissorsGame.API.Models
{
    internal class UserLoginAttempts
    {
        private TimeSpan _blockingTime = TimeSpan.FromMinutes(10);

        // if we will have the file of this model we need use JsonPropertyName attribute or all models will be deserialized as null

        public string UserLogin { get; private set; }

        public int AttemptsCount { get; private set; }

        public DateTime LastAttempt { get; private set; }

        public bool IsBlocked => AttemptsCount >= 3 && DateTime.UtcNow - LastAttempt < _blockingTime;

        public UserLoginAttempts(string login)
        {
            UserLogin = login;
            AttemptsCount = 1;
            LastAttempt = DateTime.UtcNow;
        }

        public void AddAttempt()
        {
            AttemptsCount++;
            LastAttempt = DateTime.UtcNow;
        }
    }
}
