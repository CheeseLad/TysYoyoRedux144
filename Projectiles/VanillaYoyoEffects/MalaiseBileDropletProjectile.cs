using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using Terraria;
using Terraria.Audio;
using Terraria.GameContent;
using Terraria.ID;
using Terraria.ModLoader;


namespace TysYoyoRedux144.Projectiles.VanillaYoyoEffects
{
	public class MalaiseBileDropletProjectile : ModProjectile
	{
		public override void SetStaticDefaults()
		{
			// DisplayName.SetDefault("Bile Droplet");
		}

		public override void SetDefaults()
		{
			Projectile.width = 8;
			Projectile.height = 8;
			Projectile.friendly = true; 
            Projectile.hostile = false;

            Projectile.DamageType = DamageClass.Melee;
            Projectile.penetrate = 1;
			Projectile.timeLeft = 40;

			Projectile.ignoreWater = true;
			Projectile.tileCollide = true;
			Projectile.scale = 0.75f;
		}

		public override void AI()
		{
			//fall
			Projectile.velocity.Y += 0.6f;

			//fade
			if (Projectile.timeLeft < 10)
			{
				Projectile.alpha += 26;
			}
		}
	}
}