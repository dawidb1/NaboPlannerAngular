using System;
using System.Collections.Generic;

namespace NaboPlannerAngular.Models.DB
{
    public partial class Song
    {
        public Song()
        {
            SongText = new HashSet<SongText>();
        }

        public short PkSongId { get; set; }
        public string SongName { get; set; }
        public string SongAuthor { get; set; }
        public string Tags { get; set; }
        public byte? VerseNumber { get; set; }
        public bool? Chorus { get; set; }
        public string Origin { get; set; }

        public ICollection<SongText> SongText { get; set; }
    }
}
