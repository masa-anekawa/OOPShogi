namespace OOPShogi
{
    /// <summary>
    /// 局面を取得するためのinterface.
    /// </summary>
    public interface IPosition
    {
        Board GetBoard();
        Pool GetPool(bool isWhite);
        Turn GetTurn();
    }
}