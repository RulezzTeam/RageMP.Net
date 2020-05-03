using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using AlternateLife.RageMP.Net.Native;

namespace AlternateLife.RageMP.Net.Helpers
{
    internal class StringConverter : IDisposable
    {
        private readonly List<IntPtr> _convertedStrings = new List<IntPtr>();

        public static string PointerToString(IntPtr pointer, bool freePointer = true)
        {
            if (pointer == IntPtr.Zero)
            {
                return null;
            }

            var length = 0;

            while (Marshal.ReadByte(pointer, length) != 0)
            {
                ++length;
            }

            var buffer = new byte[length];
            Marshal.Copy(pointer, buffer, 0, buffer.Length);

            if (freePointer)
            {
                Rage.FreeArray(pointer);
            }

            return Encoding.UTF8.GetString(buffer);
        }

        public static IntPtr StringToPointerUnsafe(string s)
        {
            unsafe
            {
                if (s == null)
                {
                    return IntPtr.Zero;
                }

                int nb = Encoding.UTF8.GetMaxByteCount(s.Length);

                IntPtr pMem = Marshal.AllocHGlobal(nb + 1);

                int nbWritten;
                byte* pbMem = (byte*)pMem;

                fixed (char* firstChar = s)
                {
                    nbWritten = Encoding.UTF8.GetBytes(firstChar, s.Length, pbMem, nb);
                }

                pbMem[nbWritten] = 0;
            
                //var bufferSize = Encoding.UTF8.GetByteCount(text) + 1;
//
                //var buffer = new byte[bufferSize];
                //Encoding.UTF8.GetBytes(text, 0, text.Length, buffer, 0);
//
                //var pointer = Marshal.AllocHGlobal(bufferSize);
//
                //Marshal.Copy(buffer, 0, pointer, bufferSize);
    
                return pMem;
            }
        }

        public IntPtr StringToPointer(string text)
        {
            if (text == null)
            {
                return IntPtr.Zero;
            }

            var pointer = StringToPointerUnsafe(text);

            _convertedStrings.Add(pointer);

            return pointer;
        }

        ~StringConverter()
        {
            Cleanup();
        }

        public void Dispose()
        {
            Cleanup();

            GC.SuppressFinalize(this);
        }

        private void Cleanup()
        {
            foreach (var convertedString in _convertedStrings)
            {
                Marshal.FreeHGlobal(convertedString);
            }
        }
    }
}
