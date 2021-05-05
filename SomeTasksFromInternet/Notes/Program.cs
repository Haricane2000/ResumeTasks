using System;

class Program
{
    static void Main(string[] args)
    {
        Key a = new Key(Note.C, Accidental.Sharp, Octave.Second);
        Console.WriteLine(a);

        Key c = new Key(Note.C, Accidental.Sharp, Octave.First);
        Console.WriteLine(c);

        Key d = new Key(Note.D, Accidental.Flat, Octave.First);
        Console.WriteLine(d);

        Console.WriteLine(c.Equals(d));
        Console.WriteLine(c.GetHashCode());
        Console.WriteLine(d.GetHashCode());
        Console.WriteLine(a.CompareTo(d));
        Console.WriteLine(d.CompareTo(a));
        Console.WriteLine(d.CompareTo(c));

        // ошибочная клавиша
        //Key b = new Key(Note.C, Accidental.Flat, Octave.Subcontra);

        // ошибочный аргумент
        //Note note = (Note)30;
        //Key e = new Key(note, Accidental.Sharp, Octave.First);
    }
}