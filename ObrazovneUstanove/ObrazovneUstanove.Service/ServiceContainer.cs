namespace ObrazovneUstanove.Service
{
    public class ServiceContainer : IServiceContainer
    {
        public ServiceContainer(IKorisnikService KorisnikService, INaseljenoMjestoService NaseljenoMjestoService, IOpstinaService OpstinaService, IStrucnaSpremaService StrucnaSpremaService,
            IPolaznikService PolaznikService)
        {
            this.KorisnikService = KorisnikService;
            this.NaseljenoMjestoService = NaseljenoMjestoService;
            this.OpstinaService = OpstinaService;
            this.StrucnaSpremaService = StrucnaSpremaService;
            this.PolaznikService = PolaznikService;
        }

        public IKorisnikService KorisnikService { get; set; }
        public INaseljenoMjestoService NaseljenoMjestoService { get; set; }
        public IOpstinaService OpstinaService { get; set; }
        public IStrucnaSpremaService StrucnaSpremaService { get; set; }
        public IPolaznikService PolaznikService { get; set; }
    }

    public interface IServiceContainer
    {
        IKorisnikService KorisnikService { get; set; }
        INaseljenoMjestoService NaseljenoMjestoService { get; set; }
        IOpstinaService OpstinaService { get; set; }
        IStrucnaSpremaService StrucnaSpremaService { get; set; }
        IPolaznikService PolaznikService { get; set; }
    }
}
