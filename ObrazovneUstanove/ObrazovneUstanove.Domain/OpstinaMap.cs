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

    // Opstina
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.20.1.0")]
    public partial class OpstinaMap : System.Data.Entity.ModelConfiguration.EntityTypeConfiguration<Opstina>
    {
        public OpstinaMap()
            : this("dbo")
        {
        }

        public OpstinaMap(string schema)
        {
		            ToTable(schema + ".Opstina");
            HasKey(x => x.OpstinaId);

            Property(x => x.OpstinaId).HasColumnName(@"OpstinaId").IsRequired().HasColumnType("int").HasDatabaseGeneratedOption(System.ComponentModel.DataAnnotations.Schema.DatabaseGeneratedOption.None);
            Property(x => x.Naziv).HasColumnName(@"Naziv").IsRequired().HasColumnType("nvarchar").HasMaxLength(200);
            InitializePartial();
        }
        partial void InitializePartial();
    }

}
// </auto-generated>
