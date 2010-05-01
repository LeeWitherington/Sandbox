using System;
using System.Collections.Generic;
using System.Linq;
using MyShop.Events;
using NUnit.Framework;

namespace MyShop.DomainSpecs.SpecFramework
{
    public static class TestExtensions
    {
        public static IEvent Number(this IEnumerable<IEvent> events, int value)
        {
            return events.ToList()[--value];
        }
        public static void CountIs(this IEnumerable<IEvent> events, int value)
        {
            Assert.AreEqual(value, events.ToList().Count());
        }
        public static void WillBeOfType<TType>(this object theEvent)
        {
            Assert.AreEqual(typeof(TType), theEvent.GetType());
        }
        public static void WillBe(this object source, object value)
        {
            Assert.AreEqual(value, source);
        }
        public static void WillNotBe(this object source, object value)
        {
            Assert.AreNotEqual(value, source);
        }
        public static void WillBeSimuliar(this object source, object value)
        {
            Assert.AreEqual(value.ToString(), source.ToString());
        }
        public static void WillNotBeSimuliar(this object source, object value)
        {
            Assert.AreNotEqual(value.ToString(), source.ToString());
        }
        public static void WithMessage(this Exception theException, string message)
        {
            Assert.AreEqual(message, theException.Message);
        }
        public static TDomainEvent Last<TDomainEvent>(this IEnumerable<IEvent> events)
        {
            return (TDomainEvent)events.Last();
        }
        public static TDomainEvent LastMinus<TDomainEvent>(this IEnumerable<IEvent> events, int minus)
        {
            return (TDomainEvent)events.ToList()[events.Count() - minus];
        }
    }
}