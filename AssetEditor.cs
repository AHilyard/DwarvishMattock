
using StardewModdingAPI;


namespace DwarvishMattock
{
	public class AssetEditor : IAssetEditor
	{
		/// <summary>Get whether this instance can edit the given asset.</summary>
		/// <param name="asset">Basic metadata about the asset being loaded.</param>
		public bool CanEdit<T>(IAssetInfo asset)
		{
			return asset.AssetNameEquals("Data/Events/Blacksmith");
		}

		/// <summary>Edit a matched asset.</summary>
		/// <param name="asset">A helper which encapsulates metadata about an asset and enables changes to it.</param>
		public void Edit<T>(IAssetData asset)
		{
			// Add the new event.
			if (asset.AssetNameEquals("Data/Events/Blacksmith"))
			{
				var editor = asset.AsDictionary<string, string>();
				editor.Data["9684001/r 0"] = AssetLoader.blacksmithEvent;
			}
		}
	}
}