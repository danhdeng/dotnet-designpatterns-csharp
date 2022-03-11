using RealisticDependencies.Logger;

namespace BehavioralPatterns.Visitor {
    public abstract class Report {
        private readonly IApplicationLogger _logger;

        public Report(IApplicationLogger logger) {
            _logger = logger;
        }

        public DateTime CreatedOn { get; set; }

        public string CreatedBy { get; set; }

        public abstract void Print();
    }
}