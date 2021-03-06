﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;

internal static partial class Interop
{
    private static class Libraries
    {
        internal const string SystemPrivateCoreLibNative = "System.Private.CoreLib.Native";
    }

    internal unsafe partial class Sys
    {
        [DllImport(Libraries.SystemPrivateCoreLibNative)]
        internal static unsafe extern int GetEnvironmentVariable(byte* name, out IntPtr result);
    }
}
