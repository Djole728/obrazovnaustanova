namespace ObrazovneUstanove.Service
{
    public class ServiceContainer : IServiceContainer
    {
        public ServiceContainer(IKorisnikService KorisnikService, INaseljenoMjestoService NaseljenoMjestoService, IOpstinaService OpstinaService, IStrucnaSpremaService StrucnaSpremaService)
        {
            this.KorisnikService = KorisnikService;
            this.NaseljenoMjestoService = NaseljenoMjestoService;
            this.OpstinaService = OpstinaService;
            this.StrucnaSpremaService = StrucnaSpremaService;
        }

        public IKorisnikService KorisnikService { get; set; }
        public INaseljenoMjestoService NaseljenoMjestoService { get; set; }
        public IOpstinaService OpstinaService { get; set; }
        public IStrucnaSpremaService StrucnaSpremaService { get; set; }
    }

    public interface IServiceContainer
    {
        IKorisnikService KorisnikService { get; set; }
        INaseljenoMjestoService NaseljenoMjestoService { get; set; }
        IOpstinaService OpstinaService { get; set; }
        IStrucnaSpremaService StrucnaSpremaService { get; set; }
    }
}
