using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting
{
    public static class MP
    {
        public const uint GlobalDimension = uint.MaxValue;

        private static Plugin _plugin;

        public static IEventScripting Events => _plugin.EventScripting;
        public static IVehiclePool Vehicles => _plugin.VehiclePool;
        public static IPlayerPool Players => _plugin.PlayerPool;
        public static IBlipPool Blips => _plugin.BlipPool;
        public static ICheckpointPool Checkpoints => _plugin.CheckpointPool;
        public static IColshapePool Colshapes => _plugin.ColshapePool;
        public static IMarkerPool Markers => _plugin.MarkerPool;
        public static IObjectPool Objects => _plugin.ObjectPool;
        public static ITextLabelPool TextLabels => _plugin.TextLabelPool;
        public static IConfig Config => _plugin.Config;
        public static IWorld World => _plugin.World;
        public static ICommands Commands => _plugin.Commands;
        public static IUtility Utility => _plugin.Utility;

        public static ILogger Logger => _plugin.Logger;

        internal static void Setup(Plugin plugin)
        {
            _plugin = plugin;
        }
    }
}
