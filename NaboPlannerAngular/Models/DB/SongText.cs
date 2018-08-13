using System;
using System.Collections.Generic;

namespace NaboPlannerAngular.Models.DB
{
    public partial class SongText
    {
        public short FkSongId { get; set; }
        public byte PkVerseId { get; set; }
        public string VerseText { get; set; }
        public string Chorus { get; set; }
        public string Bridge { get; set; }

        public Song FkSong { get; set; }
    }
}
