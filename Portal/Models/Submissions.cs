using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Portal.Models
{
    public class Answers
    {
        [Key]
        public int RowID { get; set; }
        public int Question { get; set; }
        public int Answer { get; set; }
    }

    public class Submissions
    {
        [Key]
        public int SubmissionID { get; set; }
        public string UniqueID { get; set; }
        public DateTime SubmitedOn { get; set; } = DateTime.Now;
        public List<Answers> Answers { get; set; }
    }
}
