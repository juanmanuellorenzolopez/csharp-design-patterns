using Microsoft.VisualStudio.TestTools.UnitTesting;
using ObserverPattern;
using System.Linq;

namespace Tests
{
    [TestClass]
    public class ObserverPatternUnitTest
    {
        [TestMethod]
        public void WhenSubscribingToProvider_ThenProviderSendsNotifications()
        {
            var provider = new ApplicationsHandler();
            var subscriber = new HRSpecialist("Bill");
            subscriber.Subscribe(provider);
            provider.AddApplication(new(1, "Sarah"));
            Assert.IsTrue(subscriber.Applications.Any(app => app.JobId == 1 && string.Compare(app.ApplicantName, "Sarah") == 0));
        }

        [TestMethod]
        public void WhenUnSubscribingToProvider_ThenSubscriberShouldHaveNoApplications()
        {
            var provider = new ApplicationsHandler();
            var subscriber = new HRSpecialist("Bill");
            subscriber.Subscribe(provider);
            provider.AddApplication(new(1, "Sarah"));
            subscriber.Unsubscribe();
            Assert.IsFalse(subscriber.Applications.Count != 0);
        }

        [TestMethod]
        public void WhenApplicationsAreClosed_ThenSubscriberShouldReceiveNoMoreNotifications()
        {
            var provider = new ApplicationsHandler();
            var subscriber = new HRSpecialist("Bill");
            subscriber.Subscribe(provider);
            provider.AddApplication(new(1, "Sarah"));
            provider.CloseApplications();
            provider.AddApplication(new(2, "Ahmed"));
            Assert.IsFalse(subscriber.Applications.Any(app => app.JobId == 2 && string.Compare(app.ApplicantName, "Ahmed") == 0));
        }
    }
}
