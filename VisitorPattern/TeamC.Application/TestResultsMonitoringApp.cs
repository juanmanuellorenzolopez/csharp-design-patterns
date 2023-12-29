using System;
using System.Collections.Generic;
using System.Xml.Linq;
using TeamA.TestResults;
using TeamA.TestResults.ExtensibilityContract;
using TeamA.TestResults.Results;

namespace TeamC.Application.Visitor
{
    public class TestResultsMonitoringApp
    {
        private readonly List<ISicknessAlertVisitor> _detectors;

        public TestResultsMonitoringApp(List<ISicknessAlertVisitor> detectors)
        {
            _detectors = detectors;
        }

        public List<AlertReport> AnalyzeResultsBatch(IEnumerable<ISicknessAlertVisitable> testResults)
        {
            var alertReports = new List<AlertReport>();

            foreach (var sample in testResults)
            {
                foreach (var detector in _detectors)
                {                    
                    // This creates a sort of a ‘single dispatch’ visitor (not a real thing!). There are several drawbacks to this:
                    //  The switch block has to specify cases for all the types of visitable elements.
                    //  The C# compiler will not warn us about a type that is not covered.
                    //  That’s because it does not know about all the possible types derived from IVisitableElement.
                    //  Additionally, when we add a new type of visitable element, we have to remember both about adding a new method in the Visitor and about updating all the type-checking code. 
                    /*
                    switch (sample)
                    {
                        case BloodSample blood: alertReports.Add(detector.Visit(blood)); break;
                        case XRayImage rtg: alertReports.Add(detector.Visit(rtg)); break;
                        case EcgReading ecg: alertReports.Add(detector.Visit(ecg)); break;
                    }
                    */

                    // Taking advantage of the double dispatch of the Visitor pattern (GOOD SOLUTION)
                    alertReports.Add(sample.Accept(detector));
                }
            }
            return alertReports;
        }
    }
}