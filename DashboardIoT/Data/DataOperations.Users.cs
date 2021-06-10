using DashboardIoT.Models;
using System.Linq;

namespace DashboardIoT.Data
{
	public partial class DataOperations
	{
		public MqttUser GetMqttUserByClientId(string clientId)
		{
			return DB.MqttUsers.Where(u => u.ClientId == clientId).FirstOrDefault();
		}
    }
}
