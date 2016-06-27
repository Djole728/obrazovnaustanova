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

    // Ispit
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.20.1.0")]
    public partial class Ispit
    {
        public int IspitId { get; set; } // IspitId (Primary key)
        public int KursId { get; set; } // KursId
        public int PolaznikId { get; set; } // PolaznikId
        public int DatumOdržavanjaIspita { get; set; } // DatumOdržavanjaIspita
        public bool? Polozeno { get; set; } // Polozeno
        public decimal? BrojBodova { get; set; } // BrojBodova

        // Foreign keys
        public virtual Kur Kur { get; set; } // FK_Ispit_Kurs
        public virtual Polaznik Polaznik { get; set; } // FK_Ispit_Polaznik

        public Ispit()
        {
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>