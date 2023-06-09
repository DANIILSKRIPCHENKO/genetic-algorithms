﻿using Ga.Core.SynapseNs;

namespace Ga.Core.NeuronNs.Input
{
    /// <summary>
    /// Represents interface of neuron in input layer
    /// </summary>
    public interface IInputNeuron : INeuronBase
    {
        /// <summary>
        /// Output connections of neuron
        /// </summary>
        public IList<ISynapse> Outputs { get; }

        /// <summary>
        /// Pushes values in neuron input
        /// </summary>
        /// <param name="value"></param>
        public void PushValueOnInput(double value);
    }
}
