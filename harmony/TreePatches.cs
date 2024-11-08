using System.Reflection.Emit;
using Microsoft.Xna.Framework;
using StardewValley;
using StardewValley.Tools;
using StardewValley.TerrainFeatures;

namespace DwarvishMattock
{
	public class TreePatches
	{
		public static DynamicMethod performToolActionOriginal = null;
		public static bool performToolAction_Prefix(ref Tree __instance, Tool t, int explosion, Vector2 tileLocation, ref bool __result)
		{
			// Gotta have the original method available for mattock stand-ins.
			if (performToolActionOriginal == null)
			{
				return true;
			}

			// If the tool is a mattock and this object is one that requires a specific type of tool that is supported,
			// run the function with a stand-in tool instead.
			if (t is Mattock mattock && !mattock.struckFeatures.Contains(__instance))
			{ 
				// Treat the mattock as an axe for stumps.
				Axe standinAxe = mattock.AsAxe();
				mattock.struckFeatures.Add(__instance);
				__result = (bool) performToolActionOriginal.Invoke(__instance, new object[] { __instance, standinAxe, explosion, tileLocation });
				return false;
			}

			// Otherwise, just do the default functionality.
			return true;
		}
	}
}