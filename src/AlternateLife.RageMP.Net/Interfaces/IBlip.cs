using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface IBlip : IEntity
    {
        /// <summary>
        /// Set the draw distance of the blip.
        /// </summary>
        /// <param name="distance">New draw distance of the blip</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDrawDistance(float distance);
        

        /// <summary>
        /// Get the draw distance of the blip.
        /// </summary>
        /// <returns>Draw distance of the blip</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetDrawDistance();


        /// <summary>
        /// Set the rotation of the blip.
        /// </summary>
        /// <param name="rotation">New rotation of the blip</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetRotation(int rotation);

        /// <summary>
        /// Get the rotation of the blip.
        /// </summary>
        /// <returns>Rotation of the blip</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        new int GetRotation();
        
        /// <summary>
        /// Set the short range flag of the blip.
        /// </summary>
        /// <param name="shortRange">New short range flag of the blip</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetShortRange(bool shortRange);

        /// <summary>
        /// Get the short range flag of the blip.
        /// </summary>
        /// <returns>Short range of the blip</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool GetShortRange();

        /// <summary>
        /// Set the color of the blip.
        /// </summary>
        /// <param name="color">Color of the blip</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetColor(uint color);

        /// <summary>
        /// Get the color of the blip.
        /// </summary>
        /// <returns>Color of the blip</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        uint GetColor();

        /// <summary>
        /// Set the scale of the blip.
        /// </summary>
        /// <param name="scale">New scale of the blip</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetScale(float scale);

        /// <summary>
        /// Get the scale of the blip.
        /// </summary>
        /// <returns>Scale of the blip</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetScale();

        /// <summary>
        /// Set the name of the blip.
        /// </summary>
        /// <param name="name">New name of the blip</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="name"/> is null</exception>
        void SetName(string name);

        /// <summary>
        /// Get the name of the blip.
        /// </summary>
        string GetName();

        /// <summary>
        /// Show route for a list of players with given color and scale.
        ///
        /// The <paramref name="color" /> and <paramref name="scale" /> are used for the route, not the blip.
        /// </summary>
        /// <param name="forPlayers">List of players to show the route for</param>
        /// <param name="color">Color of the route</param>
        /// <param name="scale">Scale of the route</param>
        /// <exception cref="ArgumentNullException"><paramref name="forPlayers" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ShowRoute(IEnumerable<IPlayer> forPlayers, uint color, float scale);

        /// <summary>
        /// Show route for a list of players with given color and scale.
        ///
        /// The <paramref name="color" /> and <paramref name="scale" /> are used for the route, not the blip.
        /// </summary>
        /// <param name="forPlayers">List of players to show the route for</param>
        /// <param name="color">Color of the route</param>
        /// <param name="scale">Scale of the route</param>
        /// <exception cref="ArgumentNullException"><paramref name="forPlayers" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void ShowRoute(IEnumerable<IPlayer> forPlayers, int color, float scale);

        /// <summary>
        /// Hide route for a list of players.
        /// </summary>
        /// <param name="forPlayers">List of players to hide the route for</param>
        /// <exception cref="ArgumentNullException"><paramref name="forPlayers" /> is null</exception>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void HideRoute(IEnumerable<IPlayer> forPlayers);
    }
}
