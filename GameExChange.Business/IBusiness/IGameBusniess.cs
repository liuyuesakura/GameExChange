using IB = GameExChange.Business.Input.GameBusniess;
using OB = GameExChange.Business.Output.GameBusniess;


namespace GameExChange.Business
{
    public interface IGameBusniess:IBusinessMark
    {
        OB.GetListOutput GetList(IB.GetListInput input);

        OB.GameAddOutput Add(IB.GameAddInput input);

        OB.GameAuditOutput Audit(IB.GameAduitInput input);

    }
}