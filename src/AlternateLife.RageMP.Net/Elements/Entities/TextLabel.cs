using System;
using System.Drawing;
using System.Threading.Tasks;
using AlternateLife.RageMP.Net.Data;
using AlternateLife.RageMP.Net.Enums;
using AlternateLife.RageMP.Net.Extensions;
using AlternateLife.RageMP.Net.Helpers;
using AlternateLife.RageMP.Net.Interfaces;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Elements.Entities
{
    internal class TextLabel : Entity, ITextLabel
    {
        internal TextLabel(IntPtr nativePointer, Plugin plugin) : base(nativePointer, plugin, EntityType.TextLabel)
        {
        }

        public void SetColor(Color value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetColor(NativePointer, value.GetNumberValue());
        }

        public Color GetColor()
        {
            CheckExistence();

            return StructConverter.PointerToStruct<ColorRgba>(Rage.TextLabel.TextLabel_GetColor(NativePointer)).FromModColor();
        }

        public void SetText(string value)
        {
            Contract.NotNull(value, nameof(value));

            using (var converter = new StringConverter())
            {
                var text = converter.StringToPointer(value);

                Rage.TextLabel.TextLabel_SetText(NativePointer, text);
            }
        }


        public string GetText()
        {
            CheckExistence();

            return StringConverter.PointerToString(Rage.TextLabel.TextLabel_GetText(NativePointer));
        }

        public void SetLOS(bool value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetLOS(NativePointer, value);
        }

        public bool GetLOS()
        {
            CheckExistence();

            return Rage.TextLabel.TextLabel_GetLOS(NativePointer);
        }

        public void SetDrawDistance(float value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetDrawDistance(NativePointer, value);
        }

        public float GetDrawDistance()
        {
            CheckExistence();

            return Rage.TextLabel.TextLabel_GetDrawDistance(NativePointer);
        }


        public void SetFont(TextFontStyle value)
        {
            CheckExistence();

            Rage.TextLabel.TextLabel_SetFont(NativePointer, (uint) value);
        }


        public TextFontStyle GetFont()
        {
            CheckExistence();

            return (TextFontStyle) Rage.TextLabel.TextLabel_GetFont(NativePointer);
        }
    }
}