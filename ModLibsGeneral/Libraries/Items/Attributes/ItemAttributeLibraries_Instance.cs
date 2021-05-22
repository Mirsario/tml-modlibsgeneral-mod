﻿using System.Collections.Generic;
using Terraria;
using Terraria.ModLoader;
using ModLibsCore.Classes.DataStructures;
using ModLibsCore.Classes.Loadable;

namespace ModLibsGeneral.Libraries.Items.Attributes {
	/// <summary>
	/// Assorted static "helper" functions pertaining to gameplay attributes of items.
	/// </summary>
	public partial class ItemAttributeLibraries : ILoadable {
		private IDictionary<long, ISet<int>> PurchasableItems = new Dictionary<long, ISet<int>>();

		private ReadOnlyDictionaryOfSets<string, int> _DisplayNamesToIds = null;



		////////////////

		internal ItemAttributeLibraries() { }

		/// @private
		void ILoadable.OnModsLoad() { }

		/// @private
		void ILoadable.OnModsUnload() { }

		/// @private
		void ILoadable.OnPostModsLoad() { }



		////////////////

		internal void PopulateNames() {
			var dict = new Dictionary<string, ISet<int>>();

			for( int i = 1; i < ItemLoader.ItemCount; i++ ) {
				string name = Lang.GetItemNameValue( i );

				if( dict.ContainsKey( name ) ) {
					dict[name].Add( i );
				} else {
					dict[name] = new HashSet<int>() { i };
				}
			}

			this._DisplayNamesToIds = new ReadOnlyDictionaryOfSets<string, int>( dict );
		}
	}
}
