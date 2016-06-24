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
    public partial class Skola
    {
        public int SkolaId { get; set; } // SkolaId (Primary key)
        public string Naziv { get; set; } // Naziv (length: 200)

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<KorisnikSkolaUloga> KorisnikSkolaUlogas { get; set; } // KorisnikSkolaUloga.FK_KorisnikSkolaUloga_Skola
        public virtual System.Collections.Generic.ICollection<Kur> Kurs { get; set; } // Kurs.FK_Kurs_Skola
        public virtual System.Collections.Generic.ICollection<Polaznik> Polazniks { get; set; } // Polaznik.FK_Polaznik_Skola

        public Skola()
        {
            KorisnikSkolaUlogas = new System.Collections.Generic.List<KorisnikSkolaUloga>();
            Kurs = new System.Collections.Generic.List<Kur>();
            Polazniks = new System.Collections.Generic.List<Polaznik>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
