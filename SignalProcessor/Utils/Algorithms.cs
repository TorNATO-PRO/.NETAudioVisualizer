#region PublicDomainLicense

// Distributed under the Public Domain License
// ======================================================================
// 
// Copyright (c) 2021 Nathan "TorNATO" Waltz
// Filename: Algorithms.cs, Project: SignalProcessor, Solution: AudioVisualizer
// 
// The person who associated a work with this deed has dedicated the work to the
// public domain by waiving all of his or her rights to the work worldwide under
// copyright law, including all related and neighboring rights, to the extent allowed by
//  law.
// 
// You can copy, modify, distribute and perform the work, even for commercial
// purposes, all without asking permission.
// ======================================================================

#endregion

#region

using System;
using System.Collections.Generic;
using System.Numerics;

#endregion

namespace SignalProcessor.Utils
{
    /// <summary>
    ///     An algorithms class that contains algorithms
    ///     relevant to signals processing that will need
    ///     for this project later.
    /// </summary>
    public static class Algorithms
    {
        /// <summary>
        ///     A fast fourier transform algorithm
        ///     which has been adapted from CLRS pseudo-code
        ///     into a C# specific implementation.
        /// </summary>
        /// <param name="numbers">An array of numbers whose length is a power of 2.</param>
        /// <returns>An array of complex numbers.</returns>
        /// <exception cref="ArgumentException">Gets thrown if the length of numbers is not a power of 2.</exception>
        public static Complex[] FastFourierTransform(double[] numbers)
        {
            // length of the number array
            var length = numbers.Length;
            
            // check if length is not a power of 2, if so, throw an exception
            if (length > 0 && (length & (length - 1)) != 0)
                throw new ArgumentException("Error: The nameof(numbers) array length is not a power of 2!");

            // now time for the "math" part of the fourier transform
            // this is going to get confusing
            var bitReversedCopy = BitReverseCopy(numbers);

            for (var s = 1; s <= Math.Log2(length); s++)
            {
                var m = (int) Math.Pow(2, s);

                // obtains a complex number for use with the fourier transform
                var omegaM = Complex.Exp(new Complex(0, -Math.Tau / m));
                var k = 0;
                while (k < length)
                {
                    Complex omega = 1;
                    var l = m >> 1;
                    for (var j = 0; j < l; j++)
                    {
                        // do weird math
                        var t = omega * bitReversedCopy[k + j + l];
                        var u = bitReversedCopy[k + j];
                        bitReversedCopy[k + j] = u + t;
                        bitReversedCopy[k + j + l] = u - t;
                        omega *= omegaM;
                    }

                    k += m;
                }
            }

            return bitReversedCopy;
        }

        /// <summary>
        ///     Performs a "bit-reversal permutation" on an input
        ///     array.
        /// </summary>
        /// <param name="input">An array of input integers.</param>
        /// <returns>A new array with updated values.</returns>
        private static Complex[] BitReverseCopy(IReadOnlyList<double> input)
        {
            // get the bit count of the maximal element
            var maxBits = (int) Math.Log2(input.Count);
            var bitPermutationInput = new Complex[input.Count];

            // perform permutation operation
            for (var index = 0; index < input.Count; index++)
            {
                bitPermutationInput[ReverseBits(index, maxBits)] = input[index];
            }

            return bitPermutationInput;
        }

        /// <summary>
        ///     Reverses the input bits of a number, formatted
        ///     to the largest bit in the sequence provided by
        ///     maxBits. (i.e. the sequence [100, 0, 10, 010, 1000]
        ///     will be formatted to 4 bits prior to reversal.
        /// </summary>
        /// <param name="number">A number whose bits are going to be reversed.</param>
        /// <param name="maxBits">The max bits to reverse by.</param>
        /// <returns>The reversal of the number's bits.</returns>
        private static int ReverseBits(int number, int maxBits)
        {
            var reverse = 0;

            // perform reversal operation
            for (var i = 0; i < maxBits; i++)
            {
                reverse <<= 1;
                reverse += number & 1;
                number >>= 1;
            }

            return reverse;
        }
    }
}