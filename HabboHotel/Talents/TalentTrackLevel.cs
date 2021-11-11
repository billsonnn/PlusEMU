﻿using System;
using System.Collections.Generic;
using System.Data;
using Plus.Database.Interfaces;

namespace Plus.HabboHotel.Talents
{
    public class TalentTrackLevel
    {
        public string Type { get; set; }
        public int Level { get; set; }

        private Dictionary<int, TalentTrackSubLevel> _subLevels;

        public TalentTrackLevel(string Type, int Level, string DataActions, string DataGifts)
        {
            this.Type = Type;
            this.Level = Level;

            foreach (string Str in DataActions.Split('|'))
            {
                if (Actions == null) { Actions = new List<string>(); }
                Actions.Add(Str);
            }

            foreach (string Str in DataGifts.Split('|'))
            {
                if (Gifts == null) { Gifts = new List<string>(); }
                Gifts.Add(Str);
            }

            _subLevels = new Dictionary<int, TalentTrackSubLevel>();

            Init();
        }

        public List<string> Actions { get; private set; }

        public List<string> Gifts { get; private set; }

        public void Init()
        {
            DataTable GetTable = null;
            using (IQueryAdapter dbClient = PlusEnvironment.GetDatabaseManager().GetQueryReactor())
            {
                dbClient.SetQuery("SELECT `sub_level`,`badge_code`,`required_progress` FROM `talents_sub_levels` WHERE `talent_level` = @TalentLevel");
                dbClient.AddParameter("TalentLevel", Level);
                GetTable = dbClient.GetTable();
            }

            if (GetTable != null)
            {
                foreach (DataRow Row in GetTable.Rows)
                {
                    _subLevels.Add(Convert.ToInt32(Row["sub_level"]), new TalentTrackSubLevel(Convert.ToInt32(Row["sub_level"]), Convert.ToString(Row["badge_code"]), Convert.ToInt32(Row["required_progress"])));
                }
            }
        }

        public ICollection<TalentTrackSubLevel> GetSubLevels()
        {
            return _subLevels.Values;
        }
    }
}
