using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SSLand
{
    public class Common
    {
        public class Account
        {
            public string email;
            public string password;
            public string fril_auth_token;
            public string nickname;
            public string userId;
            public DateTime expirationDate;
            public Account(string email, string password, string auth_token, string nickname, string userid, DateTime expirationDate)
            {
                this.email = email;
                this.password = password;
                this.fril_auth_token = auth_token;
                this.nickname = nickname;
                this.userId = userid;
                this.expirationDate = expirationDate;
            }
            public Account()
            {

            }
        }
        public static DateTime UNIX_EPOCH = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc); //UnixTimeの開始時刻
        static public DateTime getDateFromUnixTimeStamp(long timestamp)
        {
            try
            {
                return UNIX_EPOCH.AddSeconds(timestamp).ToLocalTime();
            }
            catch
            {
                return UNIX_EPOCH.ToLocalTime();
            }
        }
        static public DateTime getDateFromUnixTimeStamp(string timestamp)
        {
            try
            {
                return getDateFromUnixTimeStamp(long.Parse(timestamp));
            }
            catch
            {
                return UNIX_EPOCH.ToLocalTime();
            }
        }
        //static public SecondStreetAPI getFrilAPIFromDB()
        //{
        //    var settingsDBHelper = new SettingsDBHelper();
        //    string email = settingsDBHelper.getSettingValue("email");
        //    string password = settingsDBHelper.getSettingValue("password");
        //    string expiration_date_str = settingsDBHelper.getSettingValue("expiration_date");
        //    string auth_token = settingsDBHelper.getSettingValue("auth_token");
        //    string nickname = settingsDBHelper.getSettingValue("nickname");
        //    string userid = settingsDBHelper.getSettingValue("userid");
        //    if (email == null || password == null || expiration_date_str == null || auth_token == null || nickname == null || userid == null) return null;
        //    DateTime expiration_date = DateTime.Parse(expiration_date_str);
        //    Account account = new Account(email, password, auth_token, nickname, userid, expiration_date);
        //    return checkFrilAPI(new FrilAPI(account));
        //}

        //public static FrilAPI checkFrilAPI(FrilAPI api)
        //{
        //    //有効期限が切れていたら更新する
        //    FrilAPI rst = api;
        //    if (api.account.expirationDate < DateTime.Now)
        //    {
        //        Log.Logger.Info("トークン更新開始");
        //        try
        //        {
        //            FrilAPI newapi = new FrilAPI(api.account.email, api.account.password);
        //            bool loginres = newapi.tryFrilLogin();
        //            if (!loginres) throw new Exception("fril login exception");
        //            var settingsDBHelper = new SettingsDBHelper();
        //            settingsDBHelper.updateSettings("auth_token", newapi.account.fril_auth_token);
        //            settingsDBHelper.updateSettings("expiration_date", newapi.account.expirationDate.ToString());
        //            Log.Logger.Info("トークン更新成功");
        //            return newapi;
        //        }
        //        catch (Exception ex)
        //        {
        //            Log.Logger.Error("トークン更新中エラー : " + ex.Message);
        //            return api;
        //        }
        //    }
        //    else
        //    {
        //        return api;
        //    }
        //}
        // Base64エンコード
        public static string Base64Encode(string str)
        {
            try
            {
                var enc = new UTF8Encoding();
                byte[] bytes = enc.GetBytes(str);
                return Convert.ToBase64String(bytes);
            }
            catch (Exception ex)
            {
                //Log.Logger.Error("Base64EncodeError");
                return "";
            }
        }

        // Base64デコード
        public static string Base64Decode(string str)
        {
            try
            {
                var enc = new UTF8Encoding();
                byte[] bytes = Convert.FromBase64String(str);
                return enc.GetString(bytes);
            }
            catch (Exception ex)
            {
                // Log.Logger.Error("Base64DecodeError");
                return "";
            }
        }



    }



}
