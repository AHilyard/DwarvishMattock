using StardewValley;
using StardewValley.Locations;

namespace DwarvishMattock
{
	public class IslandLocationPatches
	{
		public static bool checkForBuriedItem_Prefix(ref IslandLocation __instance, int xLocation, int yLocation, bool explosion, bool detectOnly, Farmer who, ref string __result)
		{
			// If we are in the volcano dungeon, give a chance to dig up a dwarven mattock.
			if (__instance is VolcanoDungeon)
			{
				// If the mattock artifact hasn't already been donated, you have a 2.5% chance to find it whenever digging in the volcano.
				if (!LibraryMuseum.HasDonatedArtifact(ModEntry.MATTOCK_ARTIFACT_ID) && Game1.random.NextDouble() < 0.025)
				{
					Game1.createObjectDebris(ModEntry.MATTOCK_ARTIFACT_ID, xLocation, yLocation, who.UniqueMultiplayerID, __instance);
				}
			}

			// Otherwise, just do the default functionality.
			return true;
		}
	}
}