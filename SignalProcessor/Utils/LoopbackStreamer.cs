#region PublicDomainLicense
// Distributed under the Public Domain License
// ======================================================================
// 
// Copyright (c) 2021 Nathan "TorNATO" Waltz
// Filename: LoopbackStreamer.cs, Project: SignalProcessor, Solution: AudioVisualizer
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

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace SignalProcessor.Utils
{
    /// <summary>
    ///     Obtains loopback audio from device.
    /// </summary>
    public static class LoopbackStreamer
    {
        public static void LoopbackCapture()
        {
            // TODO - Figure out how tf to stream audio since NAudio doesn't work
            // Process.Start("ffmpeg");
        }
    }
}