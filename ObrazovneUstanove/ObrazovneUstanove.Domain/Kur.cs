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
    public partial class Kur
    {
        public int KursId { get; set; } // KursId (Primary key)
        public int SkolaId { get; set; } // SkolaId
        public string Naziv { get; set; } // Naziv (length: 200)
        public int BrojCasova { get; set; } // BrojCasova
        public decimal Cijena { get; set; } // Cijena

        // Reverse navigation
        public virtual System.Collections.Generic.ICollection<Ispit> Ispits { get; set; } // Ispit.FK_Ispit_Kurs
        public virtual System.Collections.Generic.ICollection<Obuka> Obukas { get; set; } // Obuka.FK_Obuka_Kurs

        // Foreign keys
        public virtual Skola Skola { get; set; } // FK_Kurs_Skola

        public Kur()
        {
            Ispits = new System.Collections.Generic.List<Ispit>();
            Obukas = new System.Collections.Generic.List<Obuka>();
            InitializePartial();
        }

        partial void InitializePartial();
    }

}
// </auto-generated>
