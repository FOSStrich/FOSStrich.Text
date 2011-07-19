﻿using System;

namespace SoftwareBotany.Ivy
{
    /// <summary>
    /// Flags used to determine which characters to filter out of a sequence of chars.
    /// </summary>
    [Flags]
    public enum CharFilters
    {
        None = 0,
        RemoveLetters = 1,
        RemoveDigits = 2,
        RemovePunctuation = 4,
        RemoveWhiteSpace = 8,
        RemoveOther = 16,
    }

    public static class CharExtensions
    {
        /// <summary>
        /// Determines whether or not a char can pass through a given set of CharFilters.
        /// </summary>
        /// <param name="filters">Bitwise union of 1 or more CharFilters designating which characters to filter.</param>
        public static bool PassesFilters(this char value, CharFilters filters)
        {
            if (filters == CharFilters.None)
                return true;

            return (!filters.HasFlag(CharFilters.RemoveLetters) || !char.IsLetter(value))
                && (!filters.HasFlag(CharFilters.RemoveDigits) || !char.IsDigit(value))
                && (!filters.HasFlag(CharFilters.RemovePunctuation) || !char.IsPunctuation(value))
                && (!filters.HasFlag(CharFilters.RemoveWhiteSpace) || !char.IsWhiteSpace(value))
                && (!filters.HasFlag(CharFilters.RemoveOther) || char.IsLetter(value) || char.IsDigit(value) || char.IsPunctuation(value) || char.IsWhiteSpace(value));
        }
    }
}