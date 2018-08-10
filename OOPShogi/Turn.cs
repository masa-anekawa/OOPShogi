namespace OOPShogi
{
    public class Turn
    {
        public bool White { get; private set; }

        public Turn(bool isWhite = true){
            White = isWhite;
        }

        public void Switch(){
            White = !White;
        }

        public override string ToString()
        {
            return $"[Turn: {(White ? "White" : "Black")}]";
        }
    }
}