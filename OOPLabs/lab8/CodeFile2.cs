using System;

namespace ConsoleApp1
{
    public class SetIsFull : Exception
    {
        public SetIsFull(string msg) : base(msg)
        { }
    }

    public class ElementDoesNotExist : Exception
    {
        public ElementDoesNotExist(string msg) : base(msg)
        { }
    }

    public class LabIsEmpty : Exception
    {
        public LabIsEmpty(string msg) : base(msg)
        { }
    }

    public class WrongSize : Exception
    {
        public WrongSize(string msg) : base(msg)
        { }
    }
}