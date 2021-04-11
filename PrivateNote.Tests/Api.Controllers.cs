using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using PrivateNote.Controllers;
using PrivateNote.EntityFramework;

namespace PrivateNote.Tests
{
    public class ApiControllers
    {
        private IConfiguration _config;
        private string dataBaseConnection;
        private Dictionary<string, string> dataBaseConfiguration = new Dictionary<string, string>
        {
            { "ConnectionStrings:NoteDatabase", "Server=localhost\\SQLEXPRESS;Database=notestestdb;User Id=noteadmin; Password=123qwe;" }
        };

        [SetUp]
        public void SetUp()
        {
            _config = new ConfigurationBuilder()
                      .AddInMemoryCollection(dataBaseConfiguration)
                      .Build();
            
            dataBaseConnection = _config["ConnectionStrings:NoteDatabase"];
        }

        [TestCase("very private note")]
        [TestCase("extra private note")]
        public void AddNote(string noteString)
        {
            var addNoteController = new AddNoteController(_config);
            string hash = addNoteController.Add(noteString);
            
            using (var db = new NoteContext(dataBaseConnection))
            {
                var note = db.Notes.FirstOrDefault(x => x.Hash == hash);
                
                if (note != null)
                {
                    Assert.AreEqual(note.NoteString, noteString);

                    db.Notes.Remove(note);
                    db.SaveChanges();
                }
            }
        }
        
        [TestCase("very private note")]
        [TestCase("extra private note")]
        public void GetNote(string noteString)
        {
            var addNoteController = new AddNoteController(_config);
            var getNodeController = new GetNoteController(_config);
            string hash = addNoteController.Add(noteString);

            using (var db = new NoteContext(dataBaseConnection))
            {
                var note = db.Notes.FirstOrDefault(x => x.Hash == hash);
                
                if (note != null)
                {
                    Assert.AreEqual(note.NoteString, noteString);
                    string getNote = getNodeController.Get(hash);
                    Assert.AreEqual(note.NoteString, getNote);
                    
                    var noteAfterGet = db.Notes.FirstOrDefault(x => x.Hash == hash);
                    Assert.AreEqual(noteAfterGet, null);
                }
            }
        }
    }
}