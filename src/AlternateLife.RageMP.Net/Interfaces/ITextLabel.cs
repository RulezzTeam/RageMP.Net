using System;
using System.Drawing;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Exceptions;

namespace AlternateLife.RageMP.Net.Interfaces
{
    public interface ITextLabel : IEntity
    {
        /// <summary>
        /// Set the color of the text label.
        /// </summary>
        /// <param name="color">New color of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetColor(Color color);

        /// <summary>
        /// Get the color of the text label.
        /// </summary>
        /// <returns>Color of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        Color GetColor();

        /// <summary>
        /// Set the text of the text label.
        /// </summary>
        /// <param name="text">New text of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        /// <exception cref="ArgumentNullException"><paramref name="text"/> is null</exception>
        void SetText(string text);

        /// <summary>
        /// Get the text of the text label.
        /// </summary>
        /// <returns>Text of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        string GetText();
        
        /// <summary>
        /// Set the line of sight state of the text label.
        /// </summary>
        /// <param name="los">New line of sight state of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetLOS(bool los);

 
        /// <summary>
        /// Get the line of sight state of the text label.
        /// </summary>
        /// <returns>Line of sight state of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        bool GetLOS();
        
        /// <summary>
        /// Set the draw distance of the text label.
        /// </summary>
        /// <param name="drawDistance">New draw distance of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetDrawDistance(float drawDistance);
        
        /// <summary>
        /// Get the draw distance of the text label.
        /// </summary>
        /// <returns>New draw distance of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        float GetDrawDistance();

        /// <summary>
        /// Set the font of the text label.
        /// </summary>
        /// <param name="font">New font of the text label</param>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        void SetFont(TextFontStyle font);

        /// <summary>
        /// Get the font of the text label.
        /// </summary>
        /// <returns>Font of the text label</returns>
        /// <exception cref="EntityDeletedException">This entity was deleted before</exception>
        TextFontStyle GetFont();
    }
}
