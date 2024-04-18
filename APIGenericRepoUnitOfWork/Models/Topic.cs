﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace APIGenericRepoUnitOfWork.Models;

[Table("Topic")]
public partial class Topic
{
    [Key]
    public int Top_Id { get; set; }

    [StringLength(50)]
    public string Top_Name { get; set; }

    [InverseProperty("Top")]
    public virtual ICollection<Course> Courses { get; set; } = new List<Course>();
}