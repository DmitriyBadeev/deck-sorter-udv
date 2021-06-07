using System;
using DeckSorter.Core.Entities;
using DeckSorter.Core.Interfaces;
using DeckSorter.Core.ShuffleAlgorithms;
using Microsoft.Extensions.DependencyInjection;

namespace DeckSorter.Core
{
    public static class ServicesCollectionExtension
    {
        public static IServiceCollection AddDeckServices(this IServiceCollection services, string shuffleAlgorithm)
        {
            services.AddSingleton<IRepository<Deck>, DeckRepository>();

            switch (shuffleAlgorithm)
            {
                case ManuallyShuffleAlgorithm.Name:
                    services.AddScoped<IShuffleAlgorithm, ManuallyShuffleAlgorithm>();
                    break;
                case CommonShuffleAlgorithm.Name:
                    services.AddScoped<IShuffleAlgorithm, CommonShuffleAlgorithm>();
                    break;
                default:
                    throw new Exception("Wrong algorithm");
            };

            return services;
        }
    }
}