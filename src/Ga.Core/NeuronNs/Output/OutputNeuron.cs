﻿using Ga.Core.ActivationFunction;
using Ga.Core.InputFunction;
using Ga.Core.SynapseNs;
using Newtonsoft.Json;

namespace Ga.Core.NeuronNs.Output
{
    /// <summary>
    /// Implementation of IOutputNeuron interface
    /// </summary>
    public class OutputNeuron : IOutputNeuron
    {
        private readonly Guid _id = Guid.NewGuid();
        private readonly IList<ISynapse> _inputs = new List<ISynapse>();
        [JsonProperty]
        private readonly IInputFunction _inputFunction;
        [JsonProperty]
        private readonly IActivationFunction _activationFunction;

        public OutputNeuron(
            IActivationFunction activationFunction,
            IInputFunction inputFunction)
        {
            _inputFunction = inputFunction;
            _activationFunction = activationFunction;
        }

        #region implementation of IOutputNeuron

        public Guid GetId() => _id;

        public IList<ISynapse> Inputs { get => _inputs; }

        public double CalculateOutput()
        {
            var input = _inputFunction.CalculateInput(_inputs);

            var output = _activationFunction.CalculateOutput(input);

            return output;
        }

        #endregion
    }
}
