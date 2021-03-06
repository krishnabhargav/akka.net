using System;
using Akka.Actor;
using Akka.Util.Internal;

namespace Akka.TestKit
{
    public static class FSMSpecHelpers
    {
        public static Func<object, object, bool> CurrentStateExpector<TS>()
        {
            return (expected, actual) =>
            {
                var expectedFsmState = expected.AsInstanceOf<FSMBase.CurrentState<TS>>();
                var actualFsmState = actual.AsInstanceOf<FSMBase.CurrentState<TS>>();
                return expectedFsmState.FsmRef.Equals(actualFsmState.FsmRef) &&
                       expectedFsmState.State.Equals(actualFsmState.State);
            };
        }

        public static Func<object, object, bool> TransitionStateExpector<TS>()
        {
            return (expected, actual) =>
            {
                var expectedFsmState = expected.AsInstanceOf<FSMBase.Transition<TS>>();
                var actualFsmState = actual.AsInstanceOf<FSMBase.Transition<TS>>();
                return expectedFsmState.FsmRef.Equals(actualFsmState.FsmRef) &&
                       expectedFsmState.To.Equals(actualFsmState.To) &&
                       expectedFsmState.From.Equals(actualFsmState.From);
            };
        } 
    }
}