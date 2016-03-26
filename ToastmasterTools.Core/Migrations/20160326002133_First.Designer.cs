using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ToastmasterTools.Core.Features.Storage;

namespace ToastmasterTools.Core.Migrations
{
    [DbContext(typeof(ToastmasterContext))]
    [Migration("20160326002133_First")]
    partial class First
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0-rc1-16348");

            modelBuilder.Entity("ToastmasterTools.Core.Features.AHCounter.Counter", b =>
                {
                    b.Property<int>("CounterId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Count");

                    b.Property<string>("Name");

                    b.Property<int>("SpeechId");

                    b.HasKey("CounterId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Speaker", b =>
                {
                    b.Property<int>("SpeakerId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Club");

                    b.Property<string>("CurrentLesson");

                    b.Property<string>("Function");

                    b.Property<string>("ImageUrl");

                    b.Property<bool>("IsMember");

                    b.Property<string>("Name");

                    b.HasKey("SpeakerId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Speech", b =>
                {
                    b.Property<int>("SpeechId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsCustom");

                    b.Property<string>("Notes");

                    b.Property<int>("SpeakerId");

                    b.Property<double>("SpeechTimeInSeconds");

                    b.Property<int?>("SpeechTypeSpeechTypeId");

                    b.HasKey("SpeechId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.SpeechType", b =>
                {
                    b.Property<int>("SpeechTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("SpeechTypeId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Features.AHCounter.Counter", b =>
                {
                    b.HasOne("ToastmasterTools.Core.Models.Speech")
                        .WithMany()
                        .HasForeignKey("SpeechId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Speech", b =>
                {
                    b.HasOne("ToastmasterTools.Core.Models.Speaker")
                        .WithMany()
                        .HasForeignKey("SpeakerId");

                    b.HasOne("ToastmasterTools.Core.Models.SpeechType")
                        .WithMany()
                        .HasForeignKey("SpeechTypeSpeechTypeId");
                });
        }
    }
}
