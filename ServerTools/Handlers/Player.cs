﻿using Exiled.API.Features;
using Exiled.Events.EventArgs.Scp079;
using System;
using System.Collections.Generic;

namespace ServerTools.Handlers
{
    public class SPlayer
    {
        public List<string> Nametocheck = new List<string>();
        public List<string> Nametocheck2 = new List<string>();

        public void SCPLevel(GainingLevelEventArgs ev)
        {
            Log.Info(ev.NewLevel);
            if (ev.NewLevel == 2)
            {
                Nametocheck2.Add($"{ev.Player.Nickname}");
                ev.Player.Broadcast(10, $"{ServerTools.Instance.Config.Level2}");
            }
            if (ev.NewLevel == 5)
            {
                Nametocheck.Add($"{ev.Player.Nickname}");
                ev.Player.Broadcast(10, $"{ServerTools.Instance.Config.Level5}");
            }
        }

        public void MTFAnnoucments()
        {
            Random rand = new Random();
            int randomNATO = rand.Next(ServerTools.Instance.Config.MTFNATO.Count);
            string randomWord = ServerTools.Instance.Config.MTFNATO[randomNATO];
            int randomNATOnum = rand.Next(ServerTools.Instance.Config.MTFNumber.Count);
            string randomWordnum = ServerTools.Instance.Config.MTFNumber[randomNATOnum];

            Cassie.Message($"MtfUnit Epsilon 11 designated {randomWord} {randomWordnum} HasEntered AllRemaining AwaitingRecontainment pitch_0.1 .g6");
        }

        public void SpookyScream()
        {
            Cassie.Message("pitch_0.1 .g7", isNoisy: false, isSubtitles: false);
        }
    }
}