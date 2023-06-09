﻿using Ga.Core.NeuralLayerNs.Input;
using Ga.Core.NeuralLayerNs.Output;
using Ga.Core.NeuronNs.Hidden;

namespace Ga.Core.NeuralLayerNs.Hidden
{
    /// <summary>
    /// Represents interface of hidden layer of Neural Network
    /// </summary>
    public interface IHiddenLayer
    {
        /// <summary>
        /// Connects input layer to hidden layer
        /// </summary>
        /// <param name="inputLayer"></param>
        public void ConnectInput(IInputLayer inputLayer);

        /// <summary>
        /// Connects output layer to hidden layer
        /// </summary>
        /// <param name="inputLayer"></param>
        public void ConnectOutput(IOutputLayer outputLayer);

        /// <summary>
        /// Returns all neurons of a layer
        /// </summary>
        public IList<IHiddenNeuron> HiddenNeurons { get; }

        /// <summary>
        /// Resets connections of neurons in layer
        /// </summary>
        public void ResetConnections();
    }
}
