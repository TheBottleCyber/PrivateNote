using System.ComponentModel.DataAnnotations;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PrivateNote.EntityFramework;

namespace PrivateNote.Controllers
{
    [ApiController]
    // TODO: fix routes
    [Route("[controller]")]
    public class GetNoteController : ControllerBase
    {
        private string _dbConnectionString;

        public GetNoteController(IConfiguration config)
        {
            _dbConnectionString = config["ConnectionStrings:NoteDatabase"];
        }

        [HttpGet]
        public string Get([Required] string hash)
        {
            using (var db = new NoteContext(_dbConnectionString))
            {
                var note = db.Notes.FirstOrDefault(x => x.Hash == hash);

                if (note != null)
                {
                    db.Notes.Remove(note);
                    db.SaveChanges();

                    return note.NoteString;
                }

                return string.Empty;
            }
        }
    }
}