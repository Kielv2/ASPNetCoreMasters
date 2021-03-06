using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNetCoreMasters.BindingModels
{
    public class ItemCreateBindingModel
    {
        public int Id { get; set; }
        [Required]
        [StringLength(128, MinimumLength = 1)]
        public string Text { get; set; }
    }
}
