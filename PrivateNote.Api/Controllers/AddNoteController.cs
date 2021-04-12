using System;
using System.ComponentModel.DataAnnotations;
using Ganss.XSS;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrivateNote.Core;
using PrivateNote.Core.Models;
using PrivateNote.EntityFramework;

namespace PrivateNote.Controllers
{
    [ApiController]
    // TODO: fix routes
    [Route("[controller]")]
    public class AddNoteController : ControllerBase
    {
        private string _dbConnectionString;

        public AddNoteController(IConfiguration config)
        {
            _dbConnectionString = config["ConnectionStrings:NoteDatabase"];
        }
        
        [HttpPost]
        public string Add([Required][FromForm] string noteString)
        {
            string noteStringSanitized = new HtmlSanitizer().Sanitize(noteString);
            
            using (var db = new NoteContext(_dbConnectionString))
            {
                var note = new Note(Guid.NewGuid().ToHashString(), noteStringSanitized);
                
                db.Notes.Add(note);
                db.SaveChanges();

                return note.Hash;
            }
        }
    }
}