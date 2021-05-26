﻿using System;
using Terraria;
using Terraria.ModLoader.IO;
using ModLibsCore.Classes.Loadable;
using ModLibsCore.Libraries.TModLoader;


namespace ModLibsGeneral.Libraries.World {
	/// @private
	public partial class WorldStateLibraries : ILoadable {
		private bool IsDay;

		private long TicksElapsed;

		internal int HalfDaysElapsed;



		////////////////

		/// @private
		void ILoadable.OnModsLoad() { }

		/// @private
		void ILoadable.OnModsUnload() { }

		/// @private
		void ILoadable.OnPostModsLoad() { }

		internal void Load( TagCompound tags ) {
			string id = ModLibsCore.Libraries.World.WorldLibraries.GetUniqueIdForCurrentWorld( true );

			if( tags.ContainsKey("half_days_elapsed_" + id) ) {
				this.HalfDaysElapsed = tags.GetInt( "half_days_elapsed_" + id );
			}
		}

		internal void Save( TagCompound tags ) {
			string id = ModLibsCore.Libraries.World.WorldLibraries.GetUniqueIdForCurrentWorld( true );

			tags["half_days_elapsed_" + id] = (int)this.HalfDaysElapsed;
		}


		////////////////

		internal void UpdateUponWorldBeingPlayed() {
			if( !LoadLibraries.IsWorldSafelyBeingPlayed() ) {
				this.IsDay = Main.dayTime;
			} else {
				if( this.IsDay != Main.dayTime ) {
					this.HalfDaysElapsed++;
				}

				this.IsDay = Main.dayTime;
			}

			this.TicksElapsed++;
		}
	}
}
