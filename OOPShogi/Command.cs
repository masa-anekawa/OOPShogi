namespace OOPShogi
{
    public enum ECommandSort{
        kMoveRequest,
        kMoveRetraction,
        kSurrender,
        kDrawProposal,
        kDrawAcceptance,
        kDrawRejection,
    }

    public class Command
    {
        public ECommandSort Sort { get; private set; }

        public Command(ECommandSort sort){
            Sort = sort;
        }

        public override string ToString()
        {
            return $"[Command: {Sort}]";
        }
    }
}