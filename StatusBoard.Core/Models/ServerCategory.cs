using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatusBoard.Core.Models
{
    public class ServerCategory
    {
        /// <summary>
        /// The PK and Identfier for this category
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The name of the category
        /// </summary>
        [MaxLength(50)]
        public string CategoryName { get; set; }

        /// <summary>
        /// The color is stored as RGB, ranging from HEX 0x000000 to 0xFFFFFF
        /// </summary>
        public int CategoryColor { get; set; }

    }
}
