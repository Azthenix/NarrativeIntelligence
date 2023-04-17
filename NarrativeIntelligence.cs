using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using Terraria.UI;

namespace NarrativeIntelligence
{
	public class NarrativeIntelligence : ModSystem
    {
        internal QuestUI questUI;
        public UserInterface somethingInterface;

        public override void Load()
        {
            // this makes sure that the UI doesn't get opened on the server
            // the server can't see UI, can it? it's just a command prompt
            if (!Main.dedServ)
            {
                questUI = new QuestUI();
                questUI.Initialize();
                somethingInterface = new UserInterface();
                somethingInterface.SetState(questUI);
            }
        }

        public override void UpdateUI(GameTime gameTime)
        {
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu
                && QuestUI.visible)
            {
                somethingInterface?.Update(gameTime);
            }
        }

        public override void ModifyInterfaceLayers(List<GameInterfaceLayer> layers)
        {
            layers.Add(new LegacyGameInterfaceLayer("Cool Mod: Something UI", DrawQuestUI, InterfaceScaleType.UI));
        }

        private bool DrawQuestUI()
        {
            // it will only draw if the player is not on the main menu
            if (!Main.gameMenu
                && QuestUI.visible)
            {
                somethingInterface.Draw(Main.spriteBatch, new GameTime());
            }
            return true;
        }
    }
}