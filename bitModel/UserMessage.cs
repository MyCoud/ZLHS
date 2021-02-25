using System;
using System.Collections.Generic;
using System.Text;

namespace bitModel
{
    public class UserMessage   //用户个人信息表
    {
        public int UserId { get; set; }     //主键Id

        public string UserName { get; set; }    //个人姓名

        public string UserPhoto { get; set; }    //照片

        public bool UserSex { get; set; }       //个人性别

        public DateTime UserBirthday { get; set; }      //生日

        public string UserEducation { get; set; }       //学历

        public string UserExperience { get; set; }      //工作经验

        public string UserPhone { get; set; }       //手机号

        public string UserEmail { get; set; }       //邮箱地址

        public string UserLive { get; set; }        //现居地

        public string UserAddress { get; set; }     //详细地址

        public string UserHeight { get; set; }      //身高

        public string UserWeight { get; set; }      //体重

        public string UserNation { get; set; }      //民族

        public bool UserMarriage { get; set; }      //已婚未婚

        public string UserCensus { get; set; }      //户籍所在地

        public string UserLandline { get; set; }    //座机

        public int UserQQ { get; set; }     //QQ号码

        public string UserQR { get; set; }      //二维码

        public string UserBlogs { get; set; }       //博客

        public int Login_id { get; set; }       //个人帐号 外键
    }
}
