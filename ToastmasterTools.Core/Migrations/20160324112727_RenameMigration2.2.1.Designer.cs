using System;
using Microsoft.Data.Entity;
using Microsoft.Data.Entity.Infrastructure;
using Microsoft.Data.Entity.Metadata;
using Microsoft.Data.Entity.Migrations;
using ToastmasterTools.Core.Features.Storage;

namespace ToastmasterTools.Core.Migrations
{
    [DbContext(typeof(ToastmasterContext))]
    [Migration("20160324112727_RenameMigration2.2.1")]
    partial class RenameMigration221
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

                    b.Property<int?>("SpeechSpeechId");

                    b.HasKey("CounterId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.CardTime", b =>
                {
                    b.Property<int>("CardTimeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Minutes");

                    b.Property<int>("Seconds");

                    b.HasKey("CardTimeId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Member", b =>
                {
                    b.Property<int>("MemberId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Club");

                    b.Property<int?>("CurrentLessonSpeechTypeId");

                    b.Property<string>("Function");

                    b.Property<string>("ImageUrl");

                    b.Property<string>("Name");

                    b.HasKey("MemberId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Speech", b =>
                {
                    b.Property<int>("SpeechId")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("Date");

                    b.Property<bool>("IsCustom");

                    b.Property<string>("Notes");

                    b.Property<int?>("SpeakerMemberId");

                    b.Property<double>("SpeechTimeInSeconds");

                    b.Property<int?>("SpeechTypeSpeechTypeId");

                    b.HasKey("SpeechId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.SpeechType", b =>
                {
                    b.Property<int>("SpeechTypeId")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("GreenCardTimeCardTimeId");

                    b.Property<string>("Name");

                    b.Property<int?>("RedCardTimeCardTimeId");

                    b.Property<int?>("YellowCardTimeCardTimeId");

                    b.HasKey("SpeechTypeId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Features.AHCounter.Counter", b =>
                {
                    b.HasOne("ToastmasterTools.Core.Models.Speech")
                        .WithMany()
                        .HasForeignKey("SpeechSpeechId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Member", b =>
                {
                    b.HasOne("ToastmasterTools.Core.Models.SpeechType")
                        .WithMany()
                        .HasForeignKey("CurrentLessonSpeechTypeId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.Speech", b =>
                {
                    b.HasOne("ToastmasterTools.Core.Models.Member")
                        .WithMany()
                        .HasForeignKey("SpeakerMemberId");

                    b.HasOne("ToastmasterTools.Core.Models.SpeechType")
                        .WithMany()
                        .HasForeignKey("SpeechTypeSpeechTypeId");
                });

            modelBuilder.Entity("ToastmasterTools.Core.Models.SpeechType", b =>
                {
                    b.HasOne("ToastmasterTools.Core.Models.CardTime")
                        .WithMany()
                        .HasForeignKey("GreenCardTimeCardTimeId");

                    b.HasOne("ToastmasterTools.Core.Models.CardTime")
                        .WithMany()
                        .HasForeignKey("RedCardTimeCardTimeId");

                    b.HasOne("ToastmasterTools.Core.Models.CardTime")
                        .WithMany()
                        .HasForeignKey("YellowCardTimeCardTimeId");
                });
        }
    }
}
