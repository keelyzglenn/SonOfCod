using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cod.Models
{
        [Table("MarketingPages")]
    public class MarketingPage
    {
            [Key]
            public int Id { get; set; }
            public string Head { get; set; }
            public string HeadImage { get; set; }
            public string AboutTitle { get; set; }
            public string About { get; set; }
            public string FeatureOneTitle { get; set; }
            public string FeatureOneImage { get; set; }
            public string FeatureOneText { get; set; }
            public string FeatureTwoTitle { get; set; }
            public string FeatureTwoImage { get; set; }
            public string FeatureTwoText { get; set; }
            public string ColumnOneTitle { get; set; }
            public string ColumnOneImage { get; set; }
            public string ColumnOneText { get; set; }
            public string ColumnTwoTitle { get; set; }
            public string ColumnTwoImage { get; set; }
            public string ColumnTwoText { get; set; }
            public string ColumnThreeTitle { get; set; }
            public string ColumnThreeImage { get; set; }
            public string ColumnThreeText { get; set; }
            public string PostTitle { get; set; }
            public virtual ICollection<Post> Posts { get; set; }



    }
}
