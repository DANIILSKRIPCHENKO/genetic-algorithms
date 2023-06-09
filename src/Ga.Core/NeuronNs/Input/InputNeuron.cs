﻿using Ga.Core.ActivationFunction;
using Ga.Core.SynapseNs;
using Newtonsoft.Json;

namespace Ga.Core.NeuronNs.Input
{
    /// <summary>
    /// Implementation of IInputNeuron
    /// </summary>
    public class InputNeuron : IInputNeuron
    {
        private readonly Guid _id = Guid.NewGuid();
        private readonly IList<ISynapse> _outputs = new List<ISynapse>();
        [JsonProperty]
        private readonly IActivationFunction _activationFunction;
        private double _input;

        public InputNeuron(IActivationFunction activationFunction)
        {
            _activationFunction = activationFunction;
        }

        #region IInputNeuron implementation

        public Guid GetId() => _id;

        public IList<ISynapse> Outputs { get => _outputs; }

        public double CalculateOutput() => _activationFunction.CalculateOutput(_input);

        public void PushValueOnInput(double input)
        {
            _input = input;
        }

        #endregion
    }
}
