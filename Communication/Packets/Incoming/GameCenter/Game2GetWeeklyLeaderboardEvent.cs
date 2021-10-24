﻿using Plus.HabboHotel.GameClients;
using Plus.HabboHotel.Games;

namespace Plus.Communication.Packets.Incoming.GameCenter
{
    class Game2GetWeeklyLeaderboardEvent : IPacketEvent
    {
        public void Parse(GameClient session, ClientPacket packet)
        {
            int gameId = packet.PopInt();

            GameData gameData = null;
            if (PlusEnvironment.GetGame().GetGameDataManager().TryGetGame(gameId, out gameData))
            {
                //Code
            }
        }
    }
}
