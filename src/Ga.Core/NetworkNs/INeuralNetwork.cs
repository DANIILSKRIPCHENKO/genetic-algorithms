﻿using Ga.Core.Common;
using Ga.Core.Task;

namespace Ga.Core.NetworkNs
{
    /// <summary>
    /// Represents interface for Neural Network
    /// </summary>
    public interface INeuralNetwork : IId
    {
        /// <summary>
        /// Calculates and applies fitness to neurons
        /// </summary>
        /// <returns></returns>
        public double ApplyFitness(double fitness);

        /// <summary>
        /// Calculates and returns fitness
        /// </summary>
        /// <returns></returns>
        public double GetFitness();

        /// <summary>
        /// Reset connections of neurons
        /// </summary>
        public void ResetConnection();

        /// <summary>
        /// Pushes expected outpur values in Network
        /// </summary>
        /// <param name="expectedOutputs"></param>
        public void PushExpectedValues(IList<double> expectedOutputs);

        /// <summary>
        /// Pushes input values in Network
        /// </summary>
        /// <param name="inputs"></param>
        public void PushInputValues(IList<double> inputs);

        public void BindLayers();

        public IList<double> GetOutputs();

        public double EvaluateOnDataset(ITask task);
    }
}
