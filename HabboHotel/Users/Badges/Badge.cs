﻿namespace Plus.HabboHotel.Users.Badges
{
    public class Badge
    {
        public string Code;
        public int Slot;

        public Badge(string code, int slot)
        {
            Code = code;
            Slot = slot;
        }
    }
}