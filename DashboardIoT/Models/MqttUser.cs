using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DashboardIoT.Models
{
	public class MqttUser
	{
		public MqttUser() { }
		public MqttUser(uint id, string clientId, string username, string password, string passwordSalt)
		{
			Id = id;
			ClientId = clientId;
			Username = username;
			Password = password;
			PasswordSalt = passwordSalt;
		}

		[Key]
		[Required]
		[Column("id")]
		public uint Id { get; set; }

		[Required]
		[Column("clientId")]
		public string ClientId { get; set; }

		[Required]
		[Column("username")]
		public string Username { get; set; }

		[Required]
		[Column("password")]
		public string Password { get; set; }

		[Required]
		[Column("salt")]
		public string PasswordSalt { get; set; }
	}
}
