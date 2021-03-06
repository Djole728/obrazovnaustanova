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

    // Kurs
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.20.1.0")]
    public partial class KurMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Kur>
    {
        public KurMap()
            : this("dbo")
        {
        }

        public KurMap(string schema)
        {
            ToTable(schema + ".Kurs");
            HasKey(x => x.KursId);

            Property(x => x.KursId).HasColumnName(@"KursId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.SkolaId).HasColumnName(@"SkolaId").IsRequired().HasColumnType("int");
            Property(x => x.Naziv).HasColumnName(@"Naziv").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            Property(x => x.BrojCasova).HasColumnName(@"BrojCasova").IsRequired().HasColumnType("int");
            Property(x => x.Cijena).HasColumnName(@"Cijena").IsRequired().HasColumnType("decimal").HasPrecision(10,2);

            // Foreign keys
            HasRequired(a => a.Skola).WithMany(b => b.Kurs).HasForeignKey(c => c.SkolaId).WillCascadeOnDelete(false); // FK_Kurs_Skola
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
