using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLand
{
    class GetItemProcess
    {

        //static string max_id;
        //static public void resetMaxID() { max_id = ""; }
        //static public List<FrilItem> getNewMatchingItems()
        //{
        //    System.Diagnostics.Stopwatch sw = new System.Diagnostics.Stopwatch();
        //    sw.Start();
        //    var conditions = SearchConditionSettingsForm.LoadSearchConditions();
        //    var rst = new List<FrilItem>();
        //    try
        //    {
        //        var searchrst = MainForm.api.getNewItems(60, GetItemProcess.max_id);
        //        if (searchrst.Count == 0) return rst;
        //        GetItemProcess.max_id = searchrst[0].tl_id;
        //        Dictionary<string, FrilItem> detailItemDictionary = new Dictionary<string, FrilItem>();
        //        foreach (var item in searchrst)
        //        {
        //            foreach (var con in conditions)
        //            {
        //                //FrilListItemの時点でまず検索条件にマッチするか調べる
        //                bool isMatch = isMatchConditionLite(item, con);
        //                //FrilListItemの時点でマッチしていなければスキップ
        //                if (isMatch == false) continue;
        //                //検索条件がカテゴリ指定・商品の状態指定の場合のみ詳細情報をふくめて調べる
        //                if (con.usecategory || con.usecondition)
        //                {
        //                    //詳細情報を取得
        //                    if (!detailItemDictionary.ContainsKey(item.item_id)) detailItemDictionary[item.item_id] = MainForm.api.getItemDetailInfo(item.item_id);
        //                    //詳細情報をふくめて検索条件にマッチするか調べる
        //                    FrilItem detailitem = detailItemDictionary[item.item_id];
        //                    isMatch = isMatchCondition(detailitem, con);
        //                }
        //                //マッチしていたら結果にするor自動購入
        //                if (isMatch)
        //                {
        //                    //商品の詳細情報取得
        //                    if (!detailItemDictionary.ContainsKey(item.item_id)) detailItemDictionary[item.item_id] = MainForm.api.getItemDetailInfo(item.item_id);
        //                    FrilItem detailitem = detailItemDictionary[item.item_id];
        //                    if (con.autobuyoption)
        //                    {
        //                        Log.Logger.Info("自動購入呼び出し1:" + item.item_id + " 検索条件:" + con.ToString());
        //                        MainForm.ExecuteBuyItem(detailitem, true);
        //                    }
        //                    else
        //                    {
        //                        rst.Add(detailitem);
        //                    }
        //                    Log.Logger.Info(item.item_id + ": " + "採用");
        //                    break;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Log.Logger.Error("getNewMatchingItemsでエラー" + ex.Message);
        //    }
        //    TimeSpan ts = sw.Elapsed;
        //    Console.WriteLine("　{ts}");
        //    return rst;
        //}








    }


    //static public bool isMatchCondition(FrilItem item, SearchConditionSettingsForm.SearchConditionClass con){
        //    try {
        //        bool ok = true;
        //        //キーワード
        //        if (string.IsNullOrEmpty(con.keyword_text) == false) ok = isKeyWordMatchCondition(con.keyword_text, item.item_name);
        //        //価格
        //        if (con.minprice > item.s_price || con.maxprice < item.s_price) ok = false;
        //        //NGワード
        //        if (string.IsNullOrEmpty(con.ngkeyword_text) == false && isKeyWordMatchCondition(con.ngkeyword_text, item.item_name)) ok = false;
        //        //NGセラー カンマ区切りでどれか1つでもヒットすればアウト
        //        if (string.IsNullOrEmpty(con.ngseller_text) == false) {
        //            string[] ngseller_splitted = con.ngseller_text.Split(',');
        //            foreach (string seller in ngseller_splitted) {
        //                if (seller.Trim() == item.user_id) ok = false;
        //            }
        //        }
        //        //指定セラー カンマ区切りでどれか1もヒットしなければアウト
        //        if (string.IsNullOrEmpty(con.seller_text) == false) {
        //            string[] seller_splitted = con.seller_text.Split(',');
        //            bool tmpflag = false;
        //            foreach (string seller in seller_splitted) {
        //                if (seller.Trim() == item.user_id) tmpflag = true;
        //            }
        //            if (tmpflag == false) ok = false;
        //        }
        //        //カテゴリ
        //        if (con.usecategory && item.category_id >= 0) {
        //            int item_level1_id = FrilMaster.categoryDictionary[item.category_p_id].grand_parent_id;
        //            int item_level2_id = item.category_p_id;
        //            int item_level3_id = item.category_id;
        //            if (con.category_level1 >= 0) {
        //                //カテゴリ1のチェックを行う
        //                if (isKeyWordMatchCondition(con.ngkeyword_text, con.category_level1_name)) ok = false;
        //                else if (con.category_level1 != item_level1_id) ok = false;
        //            }
        //            if (con.category_level2 >= 0) {
        //                //カテゴリ2のチェックを行う
        //                if (isKeyWordMatchCondition(con.ngkeyword_text, con.category_level2_name)) ok = false;
        //                else if (con.category_level2 != item_level2_id) ok = false;
        //            }
        //            if (con.category_level3 >= 0) {
        //                //カテゴリ3のチェックを行う
        //                if (isKeyWordMatchCondition(con.ngkeyword_text, con.category_level3_name)) ok = false;
        //                else if (con.category_level3 != item_level3_id) ok = false;
        //            }
        //        }
        //        //ブランド
        //        if (con.usebrand && item.brand_id < 0) ok = false;
        //        if (con.usebrand) {
        //            if (con.brand_id >= 0 && item.brand_id >= 0) {
        //                if (con.brand_id != item.brand_id) ok = false;
        //            }
        //        }
        //        //商品の状態
        //        if (con.usecondition && con.item_condition_list != null) {
        //            //どれにも引っかからなかったらアウト
        //            bool tmpflag = false;
        //            foreach (int conditionid in con.item_condition_list) {
        //                if (item.status == conditionid) tmpflag = true;
        //            }
        //            if (tmpflag == false) ok = false;
        //        }
        //        //まだOKでかつNGキーワードを商品説明までみる場合
        //        if (ok && con.ischeckdetail_for_ng) {
        //            if (isKeyWordMatchCondition(con.ngkeyword_text, item.detail)) {
        //                ok = false;
        //            }
        //        }
        //        return ok;
        //    } catch (Exception ex) {
        //        Log.Logger.Error(ex.Message);
        //        return false;
        //    }
        //}
}
