﻿using System;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ID;
using Terraria.ModLoader;
using Terraria.ModLoader.IO;
using Terraria.DataStructures;

namespace TysYoyoRedux144
{
    public class TysYoyoReduxPlayer : ModPlayer
    {
        //Initialise Special triggers
        public bool YoyoBearings;

        public bool YoyoSideEffects;

        public int ComboCount = 0;

		public int ComboTimer = 0;

		public float ColorNum = 0;

		//Reset Triggers
		public override void ResetEffects()
        {
            this.YoyoBearings = false;

            this.YoyoSideEffects = false;
        }

        public override void PostUpdate()
        {
			//ComboTimer Countdown
			if (ComboTimer > 0)
			{
				ComboTimer--;
			}
			else
			{
				ComboCount = 0;
			}
		}

        //Yoyo Side Effects Combo Effect
        public override void ModifyHitNPCWithProj(Projectile proj, NPC target, ref NPC.HitModifiers modifiers)/* tModPorter If you don't need the Projectile, consider using ModifyHitNPC instead */
        {
			if (YoyoSideEffects && proj.aiStyle == 99)
			{
				//Adds damage
				float ComboDamageMultiplier = ComboCount > 19 ? 0.2f : (ComboCount / 100f);
				target.damage = (int)(target.damage * (1 + ComboDamageMultiplier));

				//Increases Combo Counter
				ComboCount++;
				ComboTimer = 30;

				//Does Pop-up for combo
				string TextPopup = ComboCount + (ComboCount > 19 ? "!" : "");

				Color TextColor = Main.hslToRgb(ColorNum, 1f, 0.5f);
				ColorNum += 0.1f;
				if (ColorNum > 1f)
					ColorNum = 0f;

				int ct = CombatText.NewText(proj.getRect(), TextColor, TextPopup);
				Main.combatText[ct].velocity *= 0.6f;
				Main.combatText[ct].scale *= 1.25f;
				Main.combatText[ct].lifeTime = 30;
			}
		}
    }
}
