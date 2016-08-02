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

    // Skola
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.20.1.0")]
    public partial class SkolaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Skola>
    {
        public SkolaMap()
            : this("dbo")
        {
        }

        public SkolaMap(string schema)
        {
		            ToTable(schema + ".Skola");
            HasKey(x => x.SkolaId);

            Property(x => x.SkolaId).HasColumnName(@"SkolaId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.Identity);
            Property(x => x.Naziv).HasColumnName(@"Naziv").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
