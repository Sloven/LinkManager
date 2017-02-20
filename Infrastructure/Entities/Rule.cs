using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class Rule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RuleId { get; set; }

        [Required]
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<ResourceRule> LinkRules { get; set; }

    }
}
