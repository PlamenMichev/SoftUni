﻿namespace P03_FootballBetting
{
    using P03_FootballBetting.Data;
    using System;

    class StartUp
    {
        static void Main(string[] args)
        {
            var context = new FootballBettingContext();

            context.Database.EnsureDeleted();
            context.Database.EnsureCreated();
        }
    }
}
