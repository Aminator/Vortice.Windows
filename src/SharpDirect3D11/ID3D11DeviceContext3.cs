﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using System.Threading;

namespace SharpDirect3D11
{
    public partial class ID3D11DeviceContext3
    {
        public void Flush1(ContextType contextType, EventWaitHandle waitHandle)
        {
            Flush1(contextType, waitHandle.SafeWaitHandle.DangerousGetHandle());
        }
    }
}
