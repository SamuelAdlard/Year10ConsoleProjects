﻿using System;

namespace _35_APIs
{
    // This 'Result' class was generated by looking at the output of the API
    // I then created a class with similar data to hold what I need

    public class Result
    {
        int position;
        int number;
        string driver;
        string team;
        int grid;
        int laps;
        int points;

        public Result(int position, int number, string driver, string team, int grid, int laps, int points)
        {
            this.position = position;
            this.number = number;
            this.driver = driver;
            this.team = team;
            this.grid = grid;
            this.laps = laps;
            this.points = points;
        }

        public string PrintResult()
        {
            var sb = new System.Text.StringBuilder();
            sb.Append(String.Format("{0,8} {1,8}   {2,-20} {3,-15} {4,8} {5,8} {6,8}\n", position, number, driver, team, grid, laps, points));
            return sb.ToString();
        }
    }
}