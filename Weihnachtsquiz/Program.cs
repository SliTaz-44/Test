using System;
using System.Collections.Generic;

public class Weihnachtsquiz_203
{
    // globale Deklarationen und Definitionen für die Klasse Quiz
    
    static Dictionary<string, int> notes_frequency_lut;

    public struct Note
    {
        public Note(string name, int quarters)
        {
            this.name = name;
            this.quarters = quarters;
        }

        public string name { get; }
        public int quarters { get; }
    }

    public class Song : IEnumerable<Note>
    {
        private List<Note> noteList = new List<Note>();
        public IEnumerator<Note> GetEnumerator() => noteList.GetEnumerator();

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator() => noteList.GetEnumerator();

        public void Add(string note, int quarters) => noteList.Add(new Note(note, quarters));
    }


    // Methoden der Klasse Quiz

    public static void Main(string[] args)
    {
        // Deklaration
        int bpm = 40;   // bpm = beats per minute

        // setup lookup table for frequencies belonging to notes
        notes_frequency_lut = new Dictionary<string, int>()
        {
            {"P",   0}, // Pause
            {"C4",  262},
            {"C#4", 277},
            {"D4",  294},
            {"D#4", 311},
            {"E4",  330},
            {"F4",  349},
            {"F#4", 370},
            {"G4",  392},
            {"G#4", 415},
            {"A4",  440},
            {"A#4", 466},
            {"B4",  494},
            {"C5",  523},
            {"D5",  587},
            {"E5",  659},
            {"F5",  698},
            {"G5",  783},
            {"A5",  880},
            {"B5",  987},
            {"C6",  1046},
            {"D6",  1175},
            {"E6",  1318},
            {"F6",  1397},
            {"F#6", 1480},
            {"G6",  1568},
            {"G#6", 1661},
            {"A6",  1760},
            {"B6",  1975},
            {"C7",  2093}
        };

        while (bpm < 150)
        {
            playSong(song2(), bpm);
            Console.WriteLine("...und von vorne und schneller");
            bpm += 5;
        }
    }

    // welcher Song verbirgt sich hier?
    public static Song song1()
    {
        return new Song()
        {
            {"E6", 1}, {"E6", 1}, {"E6", 2},
            {"E6", 1}, {"E6", 1}, {"E6", 2},
            {"E6", 1}, {"G6", 1}, {"C6", 1}, {"D6", 1},
            {"E6", 4},
            {"F6", 1}, {"F6", 1}, {"F6", 1}, {"F6", 1},
            {"F6", 1}, {"E6", 1}, {"E6", 1}, {"E6", 1},
            {"E6", 1}, {"D6", 1}, {"D6", 1}, {"E6", 1},
            {"D6", 2}, {"G6", 2},
            {"E6", 1}, {"E6", 1}, {"E6", 2},
            {"E6", 1}, {"E6", 1}, {"E6", 2},
            {"E6", 1}, {"G6", 1}, {"C6", 1}, {"D6", 1},
            {"E6", 4},
            {"F6", 1}, {"F6", 1}, {"F6", 1}, {"F6", 1},
            {"F6", 1}, {"E6", 1}, {"E6", 1}, {"E6", 1},
            {"G6", 1}, {"G6", 1}, {"F6", 1}, {"D6", 1},
            {"C6", 4}
        };
    }

    // welcher Song verbirgt sich hier?
    public static Song song2()
    {
        return new Song()
        {
            {"B6", 2}, {"B6", 1}, {"A6", 1}, {"B6", 1}, {"A6", 1},
            {"G6", 4}, {"P", 1},

            {"G6", 2}, {"E6", 1}, {"G6", 1}, {"F#6", 1}, {"E6", 1},
            {"D6", 4}, {"P", 1},

            {"A6", 1}, {"G#6", 1}, {"A6", 1}, {"C7", 1}, {"B6", 1}, {"A6", 1},
            {"G6", 4}, {"P", 1},

            {"A6", 3}, {"E6", 1}, {"E6", 1}, {"F#6", 1}, {"E6", 1}, {"F#6", 1},
            {"G6", 4}, {"P", 1}
        };
    }

    public static void playSong(Song song, int bpm)
    {
        foreach (Note note in song)
            playNote(note, bpm);
    }

    public static void playNote(Note note, int bpm)
    {
        int frequency = notes_frequency_lut[note.name];
        // duration[ms] = 60000 ms/m / (x beats per minute * 4 quarters per note or beat) * quarters of note
        int duration = (60000 / (bpm * 4)) * note.quarters;

        if (note.name == "P")
        {
            Console.WriteLine("Pause, Duration: {0} ms", duration);
            Thread.Sleep(duration);
        }
        else
        {
            Console.WriteLine("Note: {0}, Frequency: {1} Hz, Duration: {2} ms", note.name, frequency, duration);
            Console.Beep(frequency, duration);
        }
    }
}
