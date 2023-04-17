using System;
using Terraria;
using Terraria.Chat;
using Terraria.Localization;
using Terraria.ID;
using Terraria.ModLoader;

namespace NarrativeIntelligence
{
    public class QuestSystem : GlobalNPC
    {
        public static class QuestJournal
        {
            public static int requirement = 10;
            public static int current = 0;
        }

        public override void OnKill(NPC npc)
        {
            base.OnKill(npc);

            if (npc.friendly)
                return;

            if (npc.netID == NPCID.BlueSlime || npc.netID == NPCID.GreenSlime || npc.netID == NPCID.RedSlime || npc.netID == NPCID.BabySlime || npc.netID == NPCID.BlackSlime || npc.netID == NPCID.YellowSlime)
            {
                if (QuestJournal.current < QuestJournal.requirement)
                {
                    QuestJournal.current++;
                }
            }
        }

        public override void OnChatButtonClicked(NPC npc, bool firstButton)
        {
            base.OnChatButtonClicked(npc, firstButton);

            if (npc.netID == NPCID.Guide)
            {
                QuestJournal.current = 0;
            }
        }
    }
}
