#region PublicDomainLicense

// Distributed under the Public Domain License
// ======================================================================
// 
// Copyright (c) 2021 Nathan "TorNATO" Waltz
// Filename: Program.cs, Project: VisualizationRunner, Solution: AudioVisualizer
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
using SignalProcessor.Utils;

#endregion

namespace VisualizationRunner
{
    /// <summary>
    ///     The program class, main program..
    /// </summary>
    public class Program
    {
        /// <summary>
        ///     Main method; necessary for the execution
        ///     of the program.
        /// </summary>
        public static void Main()
        {
            var list = new double[] {1, 1, 1, 1, 0, 0, 0, 0};
            foreach (var c in Algorithms.FastFourierTransform(list))
            {
                Console.WriteLine($"{(int)c.Real} + {c.Imaginary}i");
            }
                        
            Console.ReadKey();
        }
    }
}