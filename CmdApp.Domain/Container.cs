using Microsoft.Extensions.DependencyInjection;

namespace CmdApp.Domain {
    public static class Container {
        internal static ServiceProvider ServiceProvider = new ServiceCollection()
            .AddSingleton<ISumOfMultiple, SumOfMultiple>()
            .AddSingleton<ISequenceAnalysis, SequenceAnalysis>()
            .BuildServiceProvider();

        public static T GetService<T>() => ServiceProvider.GetService<T>();
    }
}
