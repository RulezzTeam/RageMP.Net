using System;
using AlternateLife.RageMP.Net.Scripting;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ICommands
    {
        /// <summary>
        /// Registers a command directly without dedicated handler class.
        /// </summary>
        /// <param name="name">name of the command</param>
        /// <param name="callback">callback to call when command was executed</param>
        /// <returns>true if command was registered, false otherwise</returns>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null or empty or <paramref name="callback"/> is null</exception>
        bool Register(string name, CommandDelegate callback);

        /// <summary>
        /// Registers a new commandhandler with command methods
        /// </summary>
        /// <param name="handler"><see cref="ICommandHandler"/> to register</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is null</exception>
        void RegisterCommandHandler(ICommandHandler handler);

        /// <summary>
        /// Removes an already registered commandhandler
        /// </summary>
        /// <param name="handler"><see cref="ICommandHandler"/> to remove</param>
        /// <exception cref="ArgumentNullException"><paramref name="handler"/> is null</exception>
        void RemoveCommandHandler(ICommandHandler handler);

    }
}