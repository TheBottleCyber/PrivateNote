using System.ComponentModel.DataAnnotations;

namespace PrivateNote.Core.Models
{
    public class Note
    {
        [Key] 
        public int Id { get; set; }
        public string Hash { get; set; }
        public string NoteString { get; set; }
        
        public Note(string hash, string noteString)
        {
            Hash = hash;
            NoteString = noteString;
        }
    }
}