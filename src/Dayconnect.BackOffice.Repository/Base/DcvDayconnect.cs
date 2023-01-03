using DayFw.DataAccess;

namespace DevSecOps.backoffice.Repository.Base;

public class DcvDayconnect : BaseRepositoryAdo
{
    protected DcvDayconnect() : base(new DcvDayconnectParameters())
    {
    }
}