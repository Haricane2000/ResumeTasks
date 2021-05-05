using System;
public struct Key : IComparable
{
    private Octave Oct;
    private Note Not;
    private Accidental Accident;

    public Key(Note note, Accidental accidential, Octave octave)
    {
        if (!Enum.IsDefined(typeof(Octave), octave) || !Enum.IsDefined(typeof(Note), note)
            || !Enum.IsDefined(typeof(Accidental), accidential))
            throw new ArgumentException("Wrong arguments");

        if ((((int)octave == (int)Octave.Fifth) && (((int)note + (int)accidential) > (int)Note.C))
            || (((int)octave == (int)Octave.Subcontra) && (((int)note + (int)accidential) < (int)Note.A)))
            throw new ArgumentException("There is no such key");
        Not = note;
        Accident = accidential;
        Oct = octave;
    }

    public override string ToString() => Not.ToString() + " " + Accident.ToString() + " " + Oct.ToString() + " octave";

    public override bool Equals(object obj) => obj is Key m && Oct == m.Oct && (((int)Not + (int)Accident) == ((int)m.Not + (int)m.Accident));

    public override int GetHashCode() => Not.GetHashCode() + ((int)Accident).GetHashCode() + (Oct.GetHashCode() * 10);

    public int CompareTo(object obj)
    {
        if (obj is Key m)
        {
            if (Equals(m))
                return 0;

            else if (((int)Oct > (int)m.Oct) || (((int)Oct) == (int)m.Oct) && ((int)Not + (int)Accident) > ((int)m.Not + (int)m.Accident))
                return 1;

            else
                return -1;
        }

        else
            throw new ArgumentException("Wrong type");
    }
}