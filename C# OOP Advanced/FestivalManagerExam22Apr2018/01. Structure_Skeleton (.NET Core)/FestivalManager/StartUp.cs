using FestivalManager.Entities.Factories;
using FestivalManager.Entities.Factories.Contracts;

namespace FestivalManager
{
    using Core;
    using Core.Controllers;
	using Core.Controllers.Contracts;
	using Core.IO;
	using Core.IO.Contracts;
	using Entities;
	using Entities.Contracts;

	public static class StartUp
	{
		public static void Main(string[] args)
		{
            IReader reader = new ConsoleReader();
            IWriter writer = new ConsoleWriter();

            IInstrumentFactory instrumentFactory = new InstrumentFactory();
            IPerformerFactory performerFactory = new PerformerFactory();
            ISetFactory setFactory = new SetFactory();
            ISongFactory songFactory = new SongFactory();
			IStage stage = new Stage();
			IFestivalController festivalController = new FestivalController(stage, instrumentFactory, performerFactory, setFactory, songFactory);
			ISetController setController = new SetController(stage);

			var engine = new Engine(reader, writer, festivalController, setController);

			engine.Run();
		}
	}
}