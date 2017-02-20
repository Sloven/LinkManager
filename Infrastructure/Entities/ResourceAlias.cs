using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;

namespace Entities
{
    [Table("ResourceAliases")]
    public class ResourceAlias
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Int64 AliasId { get; set; }

        [Required]
        public string Alias { get; set; }

        public string HiPrefix { get; set; }

        public string LowPrefix { get; set; }

        public string Description { get; set; }

        public Resource Resource { get; set; }

        [MaxLength(128), ForeignKey("ApplicationUser")]
        public virtual string UserId { get; set; }

        [JsonIgnore]
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
