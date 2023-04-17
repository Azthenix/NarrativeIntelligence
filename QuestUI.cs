using Microsoft.Xna.Framework;
using Terraria;
using Terraria.UI;
using Terraria.GameContent.UI.Elements;

namespace NarrativeIntelligence
{
    public class QuestUI : UIState
    {
        public static bool visible;
        public UIPanel panel;
        public float oldScale;
        public UIText quest;

        public override void OnInitialize()
        {
            // if you set this to true, it will show up in game
            visible = true;

            panel = new UIPanel(); //initialize the panel
            // ignore these extra 0s
            panel.Left.Set(600, 0); //this makes the distance between the left of the screen and the left of the panel 500 pixels (somewhere by the middle)
            panel.Top.Set(100, 0); //this is the distance between the top of the screen and the top of the panel
            panel.Width.Set(150, 0);
            panel.Height.Set(200, 0);

            quest = new UIText("Slimes 0/10"); // 1
            panel.Append(quest);

            Append(panel); //appends the panel to the UIState
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            quest.SetText($"Slimes {QuestSystem.QuestJournal.current}/{QuestSystem.QuestJournal.requirement}");

            if (oldScale != Main.inventoryScale)
            {
                oldScale = Main.inventoryScale;
                Recalculate();
            }
        }
    }
}
