﻿namespace Esp.Core.SynapseNs
{
    public interface ISynapse
    {
        public double Weight { get; }

        public double GetOutput();
    }
}