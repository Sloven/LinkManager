using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class ResourceRule
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ResourceRuleId { get; set; }

        public virtual Resource Resource { get; set; }

        public virtual Rule Rule { get; set; }

    }
}
