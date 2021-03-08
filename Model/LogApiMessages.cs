using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class LogApiMessages
    {
        // In deze tabel loggen we alleen de logging-niveau Error 
        public int Id { get; set; }  // [Required niet nodig] 

        [Required]
        public string Application { get; set; }

        [Required]
        public DateTime Logged { get; set; }

        [Required]
        public string Level { get; set; }

        [Required]
        public string Message { get; set; }

        [Required]
        public string Logger { get; set; }

        [Required]
        public string Callsite { get; set; }

        [Required]
        public string Exception { get; set; }


    }
}
