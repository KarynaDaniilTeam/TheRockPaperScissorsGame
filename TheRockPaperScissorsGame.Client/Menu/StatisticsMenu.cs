﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using TheRockPaperScissorsGame.Client.Clients;

namespace TheRockPaperScissorsGame.Client.Menu
{
    class StatisticsMenu : IMenu
    {
        private UserClient _userClient;
        private GameClient _gameClient;
        private StatisticClient _statisticClient;

        public StatisticsMenu(UserClient userClient, GameClient gameClient, StatisticClient statisticClient)
        {
            _userClient = userClient;
            _gameClient = gameClient;
            _statisticClient = statisticClient;
        }


        public async Task StartAsync()
        {
            while (true)
            {
                Console.Clear();
                IMenu menu;

                var options = new string[] { "Leaderboard", "Player statistics", "Back" };
                var command = MenuLibrary.InputMenuItemNumber("Statistics", options);
                switch (command)
                {
                    case 1:
                        menu = new LeaderboardMenu(_userClient, _gameClient, _statisticClient);
                        await menu.StartAsync();
                        break;
                    case 2:
                        menu = new PlayerStatisticsMenu(_userClient, _gameClient, _statisticClient);
                        await menu.StartAsync();
                        break;
                    case 3:
                    default:
                        return;
                }
            }
        }
    }
}
