using System;
using System.Linq;
using System.Runtime.InteropServices;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal class NativeSyncEventDispatcher<TNative, TEvent> : SyncEventDispatcher<TEvent> where TEvent : System.EventArgs
    {
        private readonly EventType _type;
        private readonly TNative _nativeCallback;
        private readonly bool _forceRegistration;

        internal NativeSyncEventDispatcher(Plugin plugin, EventType type, TNative nativeCallback, bool forceRegistration = false) : base(plugin, type.ToString())
        {
            _type = type;
            _nativeCallback = nativeCallback;
            _forceRegistration = forceRegistration;

            if (_forceRegistration)
            {
                Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));
            }
        }

        public override bool Subscribe(EventHandler<TEvent> callback, out bool isFirstSubscriber)
        {
            var wasAdded = base.Subscribe(callback, out isFirstSubscriber);

            if (_forceRegistration || wasAdded == false || isFirstSubscriber == false)
            {
                return wasAdded;
            }

            Rage.Events.RegisterEventHandler((int) _type, Marshal.GetFunctionPointerForDelegate(_nativeCallback));

            return true;
        }

        public override bool Unsubscribe(EventHandler<TEvent> callback, out bool wasLastSubscriber)
        {
            var wasRemoved = base.Unsubscribe(callback, out wasLastSubscriber);

            if (_forceRegistration || wasRemoved == false || wasLastSubscriber == false)
            {
                return wasRemoved;
            }

            Rage.Events.UnregisterEventHandler((int) _type);

            return true;
        }
    }
}
