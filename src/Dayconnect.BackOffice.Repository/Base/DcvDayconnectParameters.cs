using DayFw.DataAccess.Interfaces;

namespace Dayconnect.backoffice.Repository.Base;

public class DcvDayconnectParameters : IConnectionParameters
{
    public bool UseDayFwConfigurationFile => true;
    public string SistemaDaycoval => "DAYSYSTEM_353";
    public string ConnectionName => "DCV_DAYCONNECT";
    public int? TimeOut { get; set; }
}