using System;
using System.Collections.Generic;

namespace ObserverPattern
{
    public class UnSubscriber(List<IObserver<Application>> observers, IObserver<Application> observer) : IDisposable
    {
        private readonly List<IObserver<Application>> _observers = observers;
        private readonly IObserver<Application> _observer = observer;

        public void Dispose()
        {
            _observers.Remove(_observer);
            GC.SuppressFinalize(this);
        }
    }
}
