using System;

namespace AlternateLife.RageMP.Net.Scripting
{
    public class RageMpConsts
    {
        public static int ConcurrencyLevel { get; } = Environment.ProcessorCount * 2;

        public const uint GlobalDimension = uint.MaxValue;

    }
}