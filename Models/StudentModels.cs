using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace D10.Models
{
    public class StudentViewModel
    {
        public int Id { get; set; }
        public string? FullName { get; set; }
        public string? City { get; set; }
    }

    public class StudentCreateModel
    {
        [Required, MaxLength(35)]
        public string? FirstName { get; set; }

        [Required, MaxLength(35)]
        public string? LastName { get; set; }

        [MaxLength(25)]
        public string? City { get; set; }
        public string? State { get; set; }
    }

    public class StudentUpdateModel
    {
        [Required, MaxLength(35)]
        public string? FirstName { get; set; }

        [Required, MaxLength(35)]
        public string? LastName { get; set; }

        [MaxLength(25)]
        public string? City { get; set; }
    }


}