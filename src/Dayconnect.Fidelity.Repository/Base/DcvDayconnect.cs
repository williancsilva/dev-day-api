using DayFw.DataAccess;

namespace Dayconnect.Fidelity.Repository.Base
{
    public class DcvDayconnect : BaseRepositoryAdo
    {
        public DcvDayconnect() : base(new DcvDayconnectParameters())
        {
        }
    }
}
