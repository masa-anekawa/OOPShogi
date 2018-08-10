namespace OOPShogi
{
    public struct HistoryEvent
    {
        public Command Command;
        // TODO: add TimeSpan
        public HistoryEvent(Command _command){
            Command = _command;
        }
        public override string ToString()
        {
            return "[HistoryEvent: " + Command + "]";
        }
    }
}