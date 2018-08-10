namespace OOPShogi
{
    public enum ECommandSort{
        kMoveRequest,
        kMoveRetraction,
        kSurrender,
        kDrawProposal,
        kDrawAcceptance,
        kDrawRejection,
        kDeclaration,
        kPass,
    }

    public class Command
    {
        public ECommandSort Sort { get; private set; }
        public bool White { get; }
        public Move? Move { get; }

        public Command(ECommandSort sort, bool _white, Move? move = null)
        {
            Sort = sort;
            White = _white;
            Move = move;
        }

        public override string ToString()
        {
            return $"[Command: {Sort}{(Move.HasValue ? " with " + Move : "")}]";
        }
    }
}