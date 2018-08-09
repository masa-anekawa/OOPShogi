namespace OOPShogi
{
    public class Turn
    {
        public bool IsWhite { get; private set; }

        public Turn(bool isWhite = true){
            IsWhite = isWhite;
        }

        public void Switch(){
            IsWhite = !IsWhite;
        }

        public override string ToString()
        {
            return $"[Turn: {(IsWhite ? "White" : "Black")}]";
        }
    }
}