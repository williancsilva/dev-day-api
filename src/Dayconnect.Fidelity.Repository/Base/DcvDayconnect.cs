using DayFw.DataAccess;

namespace Dayconnect.Fidelity.Repository.Base;

public class DcvDayconnect : BaseRepositoryAdo
{
    protected DcvDayconnect() : base(new DcvDayconnectParameters())
    {
    }
}