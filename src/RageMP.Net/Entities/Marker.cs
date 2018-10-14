using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices;
using RageMP.Net.Data;
using RageMP.Net.Enums;
using RageMP.Net.Interfaces;
using RageMP.Net.Native;

namespace RageMP.Net.Entities
{
    internal class Marker : Entity, IMarker
    {
        public ColorRgba Color
        {
            get => Marshal.PtrToStructure<ColorRgba>(Rage.Marker.Marker_GetColor(NativePointer));
            set => Rage.Marker.Marker_SetColor(NativePointer, value.GetRed(), value.GetGreen(), value.GetBlue(), value.GetAlpha());
        }

        public Vector3 Direction
        {
            get => Marshal.PtrToStructure<Vector3>(Rage.Marker.Marker_GetDirection(NativePointer));
            set => Rage.Marker.Marker_SetDirection(NativePointer, value);
        }

        public float Scale
        {
            get => Rage.Marker.Marker_GetScale(NativePointer);
            set => Rage.Marker.Marker_SetScale(NativePointer, value);
        }

        public bool Visible
        {
            get => Rage.Marker.Marker_IsVisible(NativePointer);
            set => Rage.Marker.Marker_SetVisible(NativePointer, value);
        }

        internal Marker(IntPtr nativePointer) : base(nativePointer, EntityType.Marker)
        {
        }

        public void ShowFor(ICollection<IPlayer> players)
        {
            var pointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Marker.Marker_ShowFor(NativePointer, pointers, (ulong) pointers.Length);
        }

        public void HideFor(ICollection<IPlayer> players)
        {
            var pointers = players.Select(x => x.NativePointer).ToArray();

            Rage.Marker.Marker_HideFor(NativePointer, pointers, (ulong) pointers.Length);
        }
    }
}