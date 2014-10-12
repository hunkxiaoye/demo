using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace demos
{
    public  partial class Insert
    {
        public int Aid { get; set; }//区域编号
        public int Sid { get; set; }//产地编号
        public int Mid { get; set; }//品牌编号
        public int Rid { get; set; }//所属类别编号
        public int Tops { get; set; }//排序
        public string Description { get; set; }//商品介绍
        public string Comment { get; set; }//备注
        public int Attrid { get; set; }//属性编号
        public string Titles { get; set; }//商品标题
    }
}