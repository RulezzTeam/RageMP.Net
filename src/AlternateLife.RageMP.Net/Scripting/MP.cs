using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Interfaces;

namespace AlternateLife.RageMP.Net.Scripting
{
    public interface IRageMp
    {
        IEventScripting Events { get; }
        IVehiclePool Vehicles { get; }
        IPlayerPool Players { get; }
        IBlipPool Blips { get; }
        ICheckpointPool Checkpoints { get; }
        IColshapePool Colshapes { get; }
        IMarkerPool Markers { get; }
        IObjectPool Objects { get; }
        ITextLabelPool TextLabels { get; }
        IConfig Config { get; }
        IWorld World { get; }
        IRageMpUtility Utility { get; }

        ILogger Logger { get; }
    }
    
    internal class RageMp : IRageMp
    {
        public RageMp(Plugin plugin)
        {
            Plugin = plugin;
            
            Events = Plugin.EventScripting;
            World = Plugin.World;

            Vehicles = Plugin.VehiclePool;
            Players = Plugin.PlayerPool;
            
            Blips = Plugin.BlipPool;
            Markers = Plugin.MarkerPool;
            TextLabels = Plugin.TextLabelPool;

            Checkpoints = Plugin.CheckpointPool;
            Colshapes = Plugin.ColshapePool;
            Objects = Plugin.ObjectPool;
            
            Config = Plugin.Config;
            Utility = Plugin.Utility;
            Logger = Plugin.Logger;
        }

        private Plugin Plugin { get; }

        public IEventScripting Events { get; }
        public IVehiclePool Vehicles { get; }
        public IPlayerPool Players { get; }
        public IBlipPool Blips { get; }
        public ICheckpointPool Checkpoints { get; }
        public IColshapePool Colshapes { get; }
        public IMarkerPool Markers { get; }
        public IObjectPool Objects { get; }
        public ITextLabelPool TextLabels { get; }
        public IConfig Config { get; }
        public IWorld World { get; }
        public IRageMpUtility Utility { get; }
        public ILogger Logger { get; }
    }

    public static class MP
    {

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
        public static IRageMpUtility Utility => _plugin.Utility;

        public static ILogger Logger => _plugin.Logger;

        internal static void Setup(Plugin plugin)
        {
            _plugin = plugin;
        }
    }
}