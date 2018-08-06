using IB = GameExChange.Business.Input.ExChangeBusiness;
using OB = GameExChange.Business.Output.ExChangeBusiness;

namespace GameExChange.Business
{
    public interface IExChangeBusiness : IBusinessMark
    {

        /// <summary>
        /// 交换
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        OB.ExChangeOutput ExChange(IB.ExChangeInput input);

        /// <summary>
        /// 仅借入
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        OB.BorrowOutput Borrow(IB.ExChangeInput input);


        //归还

        //预定

        //交换游戏时相互之间的变更

        //单次记录交换多个游戏
    }
}
