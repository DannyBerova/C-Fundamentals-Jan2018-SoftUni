// Use this file for your unit tests.
// When you are ready to submit, REMOVE all using statements to your project (entities/controllers/etc)

using System;
using FestivalManager.Core.Controllers;
using FestivalManager.Entities;
using FestivalManager.Entities.Instruments;
using FestivalManager.Entities.Sets;

namespace FestivalManager.Tests
{
	using NUnit.Framework;

	[TestFixture]
	public class SetControllerTests
	{

		[Test]
	    public void TestControllerDidNotPerformSet()
	    {
            var set1 = new Short("set1");
            var performer = new Performer("Danny", 39);
	        var instrument = new Guitar();
            performer.AddInstrument(instrument);
            var song = new Song("name", new TimeSpan(0, 0, 15,0));

            var stage = new Stage();
            stage.AddSet(set1);
            stage.AddPerformer(performer);
            stage.AddSong(song);

            var controller = new SetController(stage);
	        var expected = "1. set1:" + Environment.NewLine + "-- Did not perform";

            Assert.AreEqual(expected, controller.PerformSets());

	    }

	    [Test]
	    public void TestControllerPerformSetSuccessful()
	    {
	        var set1 = new Short("set1");
	        var performer = new Performer("Danny", 38);
	        var instrument = new Guitar();
	        performer.AddInstrument(instrument);
	        var song = new Song("name", new TimeSpan(0, 0, 5, 0));

	        var stage = new Stage();
            set1.AddPerformer(performer);
            set1.AddSong(song);
	        stage.AddSet(set1);
	        stage.AddPerformer(performer);
	        stage.AddSong(song);

	        var controller = new SetController(stage);
	        var stringOutput = controller.PerformSets();
	        var expected = "1. set1:" + Environment.NewLine + "-- 1. name (05:00)" + Environment.NewLine + "-- Set Successful";

            Assert.AreEqual(expected, stringOutput);

	    }

	    [Test]
	    public void TestControllerDidNotPerformSetWithBrokenInstruments()
	    {
	        var set1 = new Short("set1");
	        var performer = new Performer("Danny", 38);
	        var instrument = new Microphone();
	        performer.AddInstrument(instrument);
	        var song = new Song("name", new TimeSpan(0, 0, 5, 0));

	        var stage = new Stage();
	        set1.AddPerformer(performer);
	        set1.AddSong(song);
	        stage.AddSet(set1);
	        stage.AddPerformer(performer);
	        stage.AddSong(song);

	        var controller = new SetController(stage);
	        controller.PerformSets();
	        controller.PerformSets();
	        var stringOutput = controller.PerformSets();
	        var expected = "1. set1:" + Environment.NewLine + "-- Did not perform";

            Assert.AreEqual(expected, stringOutput);

	    }
    }
}