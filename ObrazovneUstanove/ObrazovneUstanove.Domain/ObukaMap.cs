// <auto-generated>
// ReSharper disable ConvertPropertyToExpressionBody
// ReSharper disable DoNotCallOverridableMethodsInConstructor
// ReSharper disable InconsistentNaming
// ReSharper disable PartialMethodWithSinglePart
// ReSharper disable PartialTypeWithSinglePart
// ReSharper disable RedundantNameQualifier
// ReSharper disable RedundantOverridenMember
// ReSharper disable UseNameofExpression
// TargetFrameworkVersion = 4.52
#pragma warning disable 1591    //  Ignore "Missing XML Comment" warning

namespace ObrazovneUstanove.Domain
{

    // Obuka
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.20.1.0")]
    public partial class ObukaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Obuka>
    {
        public ObukaMap()
            : this("dbo")
        {
        }

        public ObukaMap(string schema)
        {
		            ToTable(schema + ".Obuka");
            HasKey(x => x.ObukaId);

            Property(x => x.ObukaId).HasColumnName(@"ObukaId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.KursId).HasColumnName(@"KursId").IsRequired().HasColumnType("int");
            Property(x => x.DatumOd).HasColumnName(@"DatumOd").IsRequired().HasColumnType("date");
            Property(x => x.DatumDo).HasColumnName(@"DatumDo").IsRequired().HasColumnType("date");
            Property(x => x.Cijena).HasColumnName(@"Cijena").IsRequired().HasColumnType("decimal").HasPrecision(10,2);

            // Foreign keys
            HasRequired(a => a.Kurs).WithMany(b => b.Obukas).HasForeignKey(c => c.KursId).WillCascadeOnDelete(false); // FK_Obuka_Kurs
            HasMany(t => t.Polazniks).WithMany(t => t.Obukas).Map(m =>
            {
                m.ToTable("PolaznikObuka", "dbo");
                m.MapLeftKey("ObukaId");
                m.MapRightKey("PolaznikId");
            });
            HasMany(t => t.KorisnikSkolaUlogas).WithMany(t => t.Obukas).Map(m =>
            {
                m.ToTable("ObukaPredavac", "dbo");
                m.MapLeftKey("ObukaId");
                m.MapRightKey("PredavacId");
            });
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
