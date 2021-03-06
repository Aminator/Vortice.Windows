﻿// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using Vortice.Interop;

namespace Vortice.DirectX.ShaderCompiler.D3D12
{
    public partial class ID3D12ShaderReflection
    {
        private ShaderParameterDescription[] _inputParameters;
        private ShaderParameterDescription[] _outputParameters;
        private ID3D12ShaderReflectionConstantBuffer[] _constantBuffers;
        private InputBindingDescription[] _resources;

        public RawInt3 ThreadGroupSize
        {
            get
            {
                GetThreadGroupSize(out var x, out var y, out var z);
                return new RawInt3(x, y, z);
            }
        }

        public ShaderParameterDescription[] InputParameters
        {
            get
            {
                if (_inputParameters == null)
                {
                    _inputParameters = new ShaderParameterDescription[Description.InputParameters];
                    for (var i = 0; i < Description.InputParameters; i++)
                    {
                        _inputParameters[i] = GetInputParameterDesc(i);
                    }
                }

                return _inputParameters;
            }
        }

        public ShaderParameterDescription[] OutputParameters
        {
            get
            {
                if (_outputParameters == null)
                {
                    _outputParameters = new ShaderParameterDescription[Description.OutputParameters];
                    for (var i = 0; i < Description.OutputParameters; i++)
                    {
                        _outputParameters[i] = GetOutputParameterDesc(i);
                    }
                }

                return _outputParameters;
            }
        }

        public ID3D12ShaderReflectionConstantBuffer[] ConstantBuffers
        {
            get
            {
                if (_constantBuffers == null)
                {
                    _constantBuffers = new ID3D12ShaderReflectionConstantBuffer[Description.ConstantBuffers];
                    for (var i = 0; i < Description.ConstantBuffers; i++)
                    {
                        _constantBuffers[i] = GetConstantBufferByIndex(i);
                    }
                }

                return _constantBuffers;
            }
        }

        public InputBindingDescription[] Resources
        {
            get
            {
                if (_resources == null)
                {
                    _resources = new InputBindingDescription[Description.BoundResources];
                    for (var i = 0; i < Description.BoundResources; i++)
                    {
                        _resources[i] = GetResourceBindingDesc(i);
                    }
                }

                return _resources;
            }
        }

        public int GetThreadGroupSize(out RawInt3 size)
        {
            var totalSize = GetThreadGroupSize(out var x, out var y, out var z);
            size = new RawInt3(x, y, z);
            return totalSize;
        }
    }
}
