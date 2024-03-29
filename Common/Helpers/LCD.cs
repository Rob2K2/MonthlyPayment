﻿using System.Collections.Generic;

namespace Common.Helpers
{
    public class LCD
    {
        public string[] Rows { get; set; }

        public static readonly Dictionary<int, string> Leds =
            new Dictionary<int, string>
               {
                   {0, "   "},
                   {1, " _ "},
                   {2, "| |"},
                   {3, "|_|"},
                   {5, " _|"},
                   {6, "|_ "},
                   {7, "  |"},
               };

        public static readonly Dictionary<char, LCD> Digits =
            new Dictionary<char, LCD>
               {
                   {'0', new LCD(1, 2, 3)},
                   {'1', new LCD(0, 7, 7)},
                   {'2', new LCD(1, 5, 6)},
                   {'3', new LCD(1, 5, 5)},
                   {'4', new LCD(0, 3, 7)},
                   {'5', new LCD(1, 6, 5)},
                   {'6', new LCD(1, 6, 3)},
                   {'7', new LCD(1, 7, 7)},
                   {'8', new LCD(1, 3, 3)},
                   {'9', new LCD(1, 3, 5)}
               };


        public LCD(int top, int mid, int bot) :
            this(new[] { Leds[top], Leds[mid], Leds[bot] })
        { }

        public LCD(string[] rows)
        {
            Rows = rows;
        }

        public override string ToString()
        {
            var s = string.Join("\n", Rows);
            return s;
        }
    }
}
