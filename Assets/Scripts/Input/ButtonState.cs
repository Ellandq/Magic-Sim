using System;

namespace Input
{
    public class ButtonState : IEquatable<ButtonState>, IComparable<ButtonState>
    {
        public static readonly ButtonState UP = new ButtonState("UP");
        public static readonly ButtonState DOWN = new ButtonState("DOWN");
        public static readonly ButtonState HELD = new ButtonState("HELD");

        public string Name { get; }
        public int HeldForFrames { get; set; }

        private ButtonState(string name)
        {
            Name = name;
            HeldForFrames = 0;
        }

        public override string ToString() => Name;
        
        public override bool Equals(object obj)
        {
            return Equals(obj as ButtonState);
        }

        public bool Equals(ButtonState other)
        {
            return other != null && Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        
        public int CompareTo(ButtonState other)
        {
            return other == null ? 1 : string.Compare(Name, other.Name, StringComparison.Ordinal);
        }
        
        public static bool operator ==(ButtonState left, ButtonState right)
        {
            if (ReferenceEquals(left, right)) return true;
            if (left is null || right is null) return false;
            return left.Equals(right);
        }

        public static bool operator !=(ButtonState left, ButtonState right)
        {
            return !(left == right);
        }
    }

}