﻿using Ga.Core.ActivationFunction;
using Ga.Core.Extensions;
using Ga.Core.GenotypeNs;
using Ga.Core.InputFunction;
using Ga.Core.NeuronNs.Input;
using Ga.Core.NeuronNs.Output;
using Ga.Core.SynapseNs;
using Newtonsoft.Json;

namespace Ga.Core.NeuronNs.Hidden
{
    /// <summary>
    /// Implementation of IHiddenNeuron
    /// </summary>
    public class HiddenNeuron : IHiddenNeuron
    {
        private readonly Guid _id = Guid.NewGuid();
        [JsonProperty]
        private readonly IActivationFunction _activationFunction;
        [JsonProperty]
        private readonly IInputFunction _inputFunction;
        private readonly IGenotype _genotype;

        private List<ISynapse> _inputs = new();
        private List<ISynapse> _outputs = new();
        private int _trials = 0;
        private double _fitness = 0;

        public HiddenNeuron(
            IActivationFunction activationFunction,
            IInputFunction inputFunction,
            IGenotype genotype)
        {
            _activationFunction = activationFunction;
            _inputFunction = inputFunction;
            _genotype = genotype;
        }

        #region IHiddenNeuron implementation

        public Guid GetId() => _id;

        public IList<ISynapse> Inputs
        {
            get => _inputs;
            set { _inputs = value.ToList(); }
        }

        public IList<ISynapse> Outputs
        {
            get => _outputs;
            set => _outputs = value.ToList();
        }

        public int Trials => _trials;

        public double Fitness =>
            _trials == 0
            ? _fitness
            : _fitness / _trials;

        public IGenotype Genotype => _genotype;

        public void AddFitness(double fit)
        {
            _fitness = +fit;
            _trials++;
        }

        public double CalculateOutput()
        {
            var input = _inputFunction.CalculateInput(_inputs);

            var output = _activationFunction.CalculateOutput(input);

            return output;
        }

        public void AddOutputNeuron(IOutputNeuron outputNeuron)
        {
            var index = _outputs.NextIndex();

            var synapse = new Synapse(
                this,
                outputNeuron,
                _genotype.OutputWeights[index]);

            _outputs.Add(synapse);
            outputNeuron.Inputs.Add(synapse);
        }

        public void AddInputNeuron(IInputNeuron inputNeuron)
        {
            var index = _inputs.NextIndex();

            var synapse = new Synapse(
                inputNeuron,
                this,
                _genotype.InputWeights[index]);

            _inputs.Add(synapse);
            inputNeuron.Outputs.Add(synapse);
        }

        public void ResetConnection()
        {
            _inputs.Clear();
            _outputs.Clear();
        }

        public (IHiddenNeuron, IHiddenNeuron) Recombine(IHiddenNeuron hiddenNeuron)
        {
            var (childGenotype1, childGenotype2) =
                _genotype.Recombine(hiddenNeuron.Genotype);

            var childNeuron1 = new HiddenNeuron(
                _activationFunction,
                _inputFunction,
                childGenotype1);

            var childNeuron2 = new HiddenNeuron(
                _activationFunction,
                _inputFunction,
                childGenotype2);

            return (childNeuron1, childNeuron2);
        }

        public IList<IHiddenNeuron> BurstMutate(int numberOfNeuronsToGrow)
        {
            var newGenotypes = _genotype.BurstMutate(numberOfNeuronsToGrow);

            return newGenotypes
                .Select(genotype => new HiddenNeuron(_activationFunction, _inputFunction, genotype))
                .Cast<IHiddenNeuron>()
                .ToList();
        }

        public void ResetFitness()
        {
            _fitness = 0;
            _trials = 0;
        }

        #endregion
    }
}
