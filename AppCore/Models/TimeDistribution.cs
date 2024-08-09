using AppCore.Models.Configurations;
using Microsoft.EntityFrameworkCore;

namespace AppCore.Models
{
    [EntityTypeConfiguration(typeof(TimeDistributionConfiguration))]
    public class TimeDistribution
    {
        public int? TimeDistributionId { get; set; }
        public int? PairNumber { get; set; }
        public TimeSpan? Begin { get; set; }
        public TimeSpan? End { get; set; }
        public int? EducationalInstitutionId { get; set; }
        public EducationalInstitution? EducationalInstitution { get; set; }
    }
}
