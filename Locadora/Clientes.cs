// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Locadora
{
    public partial class Clientes
    {
        [Key]
        [Column("ID")]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Nome { get; set; }
        [Required]
        [StringLength(50)]
        [Unicode(false)]
        public string Email { get; set; }
        [Required]
        [StringLength(20)]
        [Unicode(false)]
        public string Telefone { get; set; }
    }
}