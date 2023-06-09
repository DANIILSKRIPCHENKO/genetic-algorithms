﻿namespace Ga.Core.PopulationNs
{
    public interface IPopulationBuilder
    {
        public IList<IPopulation> BuildInitialPopulations();

        public IPopulation BuildPopulation();
    }
}
