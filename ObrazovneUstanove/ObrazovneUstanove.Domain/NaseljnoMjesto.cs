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

    // NaseljnoMjesto
    [System.CodeDom.Compiler.GeneratedCode("EF.Reverse.POCO.Generator", "2.20.1.0")]
    public partial class NaseljnoMjesto
    {
        public int NaseljenoMjestoId { get; set; } // NaseljenoMjestoId (Primary key)
        public string Naziv { get; set; } // Naziv (length: 200)
        public int OpstinaId { get; set; } // OpstinaId

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Korisnik> Korisniks { get; set; } // Korisnik.FK_Korisnik_NaseljnoMjesto
        public virtual System.Collections.Generic.ICollection<Polaznik> Polazniks { get; set; } // Polaznik.FK_Polaznik_NaseljnoMjesto

        // Foreign keys
        public virtual Opstina Opstina { get; set; } // FK_NaseljnoMjesto_Opstina

        public NaseljnoMjesto()
        {
            Korisniks = new System.Collections.Generic.List<Korisnik>();
            Polazniks = new System.Collections.Generic.List<Polaznik>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
