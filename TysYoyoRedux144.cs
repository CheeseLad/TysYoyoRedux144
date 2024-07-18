using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria.ModLoader;


namespace TysYoyoRedux144
{
	// Please read https://github.com/tModLoader/tModLoader/wiki/Basic-tModLoader-Modding-Guide#mod-skeleton-contents for more information about the various files in a mod.
	public class TysYoyoRedux144 : Mod
	{
		public override void PostSetupContent()
		{
			if (ModLoader.TryGetMod("BossChecklist", out Mod bossChecklist))
			{
				if (ModContent.GetInstance<TysYoyoReduxConfigServer>().AddNewYoyos)
				{
					bossChecklist.Call("AddToBossLoot", "Terraria", "Blood Moon", ModContent.ItemType<Items.NewYoyos.Ravager>());
					bossChecklist.Call("AddToBossLoot", "Terraria", "HallowBoss", ModContent.ItemType<Items.NewYoyos.Spectrum>());
					bossChecklist.Call("AddToBossLoot", "Terraria", "Martian Madness", ModContent.ItemType<Items.NewYoyos.ExtraterrestrialTaser>());
				}
			}
		}

	}
}
