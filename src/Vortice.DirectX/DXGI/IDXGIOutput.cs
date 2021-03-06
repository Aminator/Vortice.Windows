// Copyright (c) Amer Koleci and contributors.
// Distributed under the MIT license. See the LICENSE file in the project root for more information.

using SharpGen.Runtime;

namespace Vortice.DirectX.DXGI
{
    public partial class IDXGIOutput
    {
        public void FindClosestMatchingMode(ComObject concernedDevice, ModeDescription modeToMatch, out ModeDescription closestMatch)
        {
            FindClosestMatchingMode(ref modeToMatch, out closestMatch, concernedDevice);
        }

        public ModeDescription[] GetDisplayModeList(Format format, DisplayModeEnumerationFlags flags)
        {
            int count = 0;
            GetDisplayModeList(format, (int)flags, ref count, null);
            var result = new ModeDescription[count];
            if (count > 0)
            {
                GetDisplayModeList(format, (int)flags, ref count, result);
            }
            return result;
        }
    }
}
