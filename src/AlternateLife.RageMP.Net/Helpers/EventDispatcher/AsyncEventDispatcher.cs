using System;
using System.Linq;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Helpers.EventDispatcher
{
    internal class AsyncEventDispatcher<TEvent> : EventDispatcher<AsyncEventHandler<TEvent>> where TEvent : System.EventArgs
    {
        public AsyncEventDispatcher(Plugin plugin, string eventIdentifier) : base(plugin, eventIdentifier)
        {
        }

        public void CallAsync(object sender, TEvent eventArgs)
        {
            Contract.NotNull(sender, nameof(sender));
            Contract.NotNull(eventArgs, nameof(eventArgs));

            if (TryGetSubscriptions(out var subscriptions) == false)
            {
                return;
            }

            Task.Run(() =>
            {
                foreach (var subscription in subscriptions)
                {
                    ExecuteSubscriptionAsync(sender, subscription, eventArgs);
                }
            });
        }

        public async Task CallAsyncAwaitable(object sender, TEvent eventArgs)
        {
            Contract.NotNull(sender, nameof(sender));
            Contract.NotNull(eventArgs, nameof(eventArgs));

            if (TryGetSubscriptions(out var subscriptions) == false)
            {
                return;
            }

            await Task.Run(async () =>
            {
                foreach (var subscription in subscriptions)
                {
                    await ExecuteSubscriptionAsyncAwaitable(sender, subscription, eventArgs)
                        .ConfigureAwait(false);
                }
            }).ConfigureAwait(false);
        }

        private async void ExecuteSubscriptionAsync(object sender, AsyncEventHandler<TEvent> subscription, TEvent eventArgs)
        {
            try
            {
                var task = subscription(sender, eventArgs);

                if (task == null)
                {
                    throw new NullReferenceException("The subscriber has to return a task.");
                }

                await task.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                var methodInfo = subscription.Method;

                _plugin.Logger.Error($"An error occured during execution of event \"{_eventIdentifier}\" ({methodInfo.DeclaringType}:{methodInfo.Name})", e);
            }
        }

        private async Task ExecuteSubscriptionAsyncAwaitable(object sender, AsyncEventHandler<TEvent> subscription, TEvent eventArgs)
        {
            try
            {
                var task = subscription(sender, eventArgs);

                if (task == null)
                {
                    throw new NullReferenceException("The subscriber has to return a task.");
                }

                await task.ConfigureAwait(false);
            }
            catch (Exception e)
            {
                var methodInfo = subscription.Method;

                _plugin.Logger.Error($"An error occured during execution of event \"{_eventIdentifier}\" ({methodInfo.DeclaringType}:{methodInfo.Name})", e);
            }
        }
    }
}
