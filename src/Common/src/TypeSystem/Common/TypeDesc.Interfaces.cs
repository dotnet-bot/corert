// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Threading;
using Debug = System.Diagnostics.Debug;

namespace Internal.TypeSystem
{
    // Api surface for TypeDesc that relates to interfaces

    public partial class TypeDesc
    {
        DefType[] _runtimeInterfaces;

        /// <summary>
        /// The interfaces implemented by this type at runtime. There may be duplicates in this list.
        /// </summary>
        /// 
        public DefType[] RuntimeInterfaces
        {
            get
            {
                if (_runtimeInterfaces == null)
                {
                    return InitializeRuntimeInterfaces();
                }

                return _runtimeInterfaces;
            }
        }

        private DefType[] InitializeRuntimeInterfaces()
        {
            RuntimeInterfacesAlgorithm algorithm = this.Context.GetRuntimeInterfacesAlgorithmForType(this);
            DefType[] computedInterfaces = algorithm != null ? algorithm.ComputeRuntimeInterfaces(this) : Array.Empty<DefType>();
            Interlocked.CompareExchange(ref _runtimeInterfaces, computedInterfaces, null);
            return _runtimeInterfaces;
        }
    }
}
