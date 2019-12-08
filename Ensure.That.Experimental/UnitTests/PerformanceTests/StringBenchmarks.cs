namespace UnitTests.PerformanceTests
{
    using System;
    using System.Diagnostics;

    using DelMe.NBench.Demo.PerfAssert.Library;

    using Ensure.That.Experimental;

    using EnsureThat;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using NBench;

    [TestClass]
    public class StringBenchmarks_StartsWith
    {
        private readonly string testString = "foobar";
        private readonly string maybePrefix = "foo";
        private const int iterations = 1000;

        [TestMethod]
        public void StartsWithIsNoMoreThanTwiceAsSlow()
        {
            Trace.Listeners.Add(new ConsoleTraceListener());

            using (PerfAssert.Context.UsingAssertionViolatedMethod((string message) => Assert.Fail(message)))
            using (PerfAssert.Context.UsingBenchmarkRunner(BenchmarkRunCache.Instance))
            {
                PerfAssert.That<StringBenchmarks_StartsWith>(t => t.ThisLibrary())
                    .Is()
                    .FasterThan(t => t.BuiltInTwice());
            }
        }

        [PerfBenchmark]
        [ElapsedTimeAssertion]
        public void ThisLibrary()
        {
            // TODO: Would be nice for the runner to be able to do the loop for us for super fast code
            for (int i = 0; i < iterations; i++)
            {
                Strings.StartsWith(
                    Ensure.That(this.testString),
                    this.maybePrefix);
            }
        }

        [PerfBenchmark]
        [ElapsedTimeAssertion]
        public void BuiltInTwice()
        {
            for (int i = 0; i < iterations; i++)
            {
                const int multiplier = 2;
                for (int j = 0; j < multiplier; j++)
                {
                    if (!this.testString.StartsWith(this.maybePrefix))
                    {
                        throw new ArgumentException();
                    }
                }
            }
        }
    }
}