using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class Req
    {
        public String Action;

        public int OId;
        public int OUserId;
        public int OProductId;
        public float OPrice;
        public String OTime;

        public int UId;
        public String UStatus;
        public String UName;
        public String ULastName;
        public String UAvatar;

        public int PId;
        public String PName;
        public String PDescription;
        public float PPrice;
        public String PPhoto;

        public Dictionary<String,String> Order()
        {
            return new Dictionary<string, string>() {
                { "Id",this.OId.ToString() },
                { "UserId",this.OUserId.ToString() },
                { "ProductId",this.OProductId.ToString() },
                { "Price",this.OPrice.ToString() },
                { "Time",this.OTime.ToString() },
            };
        }

        public Dictionary<String, String> User()
        {
            return new Dictionary<string, string>() {
                { "Id",this.UId.ToString() },
                { "Status",this.UStatus.ToString() },
                { "Name",this.UName.ToString() },
                { "LastName",this.ULastName.ToString() },
                { "Avatar",this.UAvatar.ToString() },
            };
        }

        public Dictionary<String, String> Product()
        {
            return new Dictionary<string, string>() {
                { "Id",this.PId.ToString() },
                { "Name",this.PName.ToString() },
                { "Description",this.PDescription.ToString() },
                { "Price",this.PPrice.ToString() },
                { "Photo",this.PPhoto.ToString() },
            };
        }
    }
}
