using DayFw.DataAccess;

namespace Dayconnect.backoffice.Repository.Base;

public class DcvDayconnect : BaseRepositoryAdo
{
    protected DcvDayconnect() : base(new DcvDayconnectParameters())
    {
    }
}