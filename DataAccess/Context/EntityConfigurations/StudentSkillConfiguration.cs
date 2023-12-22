﻿using Entities.Concretes;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Context.EntityConfigurations
{
    public class StudentSkillConfiguration : IEntityTypeConfiguration<StudentSkill>
    {
        public void Configure(EntityTypeBuilder<StudentSkill> builder)
        {
            builder.ToTable("StudentSkills").HasKey(ss => ss.Id);

            builder.Property(ss => ss.StudentId)
                .IsRequired()
                .HasColumnName("StudentId");

            builder.Property(ss => ss.SkillId)
                .IsRequired()
                .HasColumnName("SkillId");

            builder.HasOne(ss => ss.Student)
                .WithMany(s => s.StudentSkills)
                .HasForeignKey(ss => ss.StudentId)
                .IsRequired();

            builder.HasOne(ss => ss.Skill)
                .WithMany()
                .HasForeignKey(ss => ss.SkillId)
                .IsRequired();

            builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
        }


    }
}