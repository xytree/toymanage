using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Wordown = Microsoft.Office.Interop.Word;
using Excel = Microsoft.Office.Interop.Excel;


/*操作office文档*/
namespace officecon
{
    /*操作WORD文档*/
    public class ConWord
    {
        private Wordown.Application G_wa;
        private object G_missing = System.Reflection.Missing.Value;
        private object G_str_path;

        //文件名称属性
        public object FileName 
        {
            get { return G_str_path; }
            set { G_str_path = value; }
        }

	    public ConWord()
	    {
	    }

        public ConWord(object name)
        {
            G_str_path = System.Web.HttpContext.Current.Server.MapPath("./File") + "\\" + name;
        }

        /*创建新文档,objtemple为文档模板*/
        public bool CreateWordFile(object objtemple)
        {
            bool bRet = false;

            if (objtemple == null)
                objtemple = G_missing;

            G_wa = new Wordown.Application();              //创建应用程序
            object pObj = objtemple;                    //定义文档模板

            //想word应用程序中添加文档保存word文件
            Wordown.Document p_wd = G_wa.Documents.Add(ref pObj, ref G_missing, ref G_missing,
                                                    ref G_missing);

            p_wd.SaveAs(ref G_str_path,ref G_missing,ref G_missing,ref G_missing,
                        ref G_missing,ref G_missing,ref G_missing,
                        ref G_missing,ref G_missing,ref G_missing,
                        ref G_missing,ref G_missing,ref G_missing,
                        ref G_missing,ref G_missing,ref G_missing);

            ((Wordown.Application)G_wa.Application).Quit(ref G_missing, ref G_missing, ref G_missing);

            return bRet;
        }

        //打开文件并进行预览
        public void Review()
        {
            Wordown.Document doc = OpenDoc(G_str_path);
            if (doc != null)
                doc.PrintPreview();
        }

        //打开文件函数
        public Wordown.Document OpenDoc(Object OPath)
        {
            G_wa = new Wordown.Application();
            G_wa.Visible = true;
            object PName = OPath;
            Wordown.Document pdocment = null;

            try
            {
                 pdocment = G_wa.Documents.Open(ref PName, ref G_missing,
                                                          ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                                                          ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                                                          ref G_missing, ref G_missing, ref G_missing, ref G_missing,
                                                          ref G_missing, ref G_missing);
            }
            catch (Exception ex)
            {
                return null;
            }

            return pdocment;
        }

        //向word写入数据

    }


    /*操作Excel文档*/
    public class conExcel
    {
        private string excelPath = System.Web.HttpContext.Current.Server.MapPath("./Excel") + "\\";
        private object missing = System.Reflection.Missing.Value;

        //文件名称属性
        public string FileName
        {
            get { return excelPath; }
            set { excelPath = value; }
        }

        public conExcel()
        {
        }

        //自定义构造函数，添加文件名称
        public conExcel(string pName)
        {
            excelPath += pName;
        }

        //打开excel文档
        public Excel.Workbook OpenExcel()
        {
            Excel.Application appexcel = new Excel.ApplicationClass();  //实例化excel对象

            //打开excel文件
            Excel.Workbook eWorkbook = appexcel.Workbooks.Open(excelPath,missing,missing,missing,missing,
                missing,missing,missing,missing,missing,missing,missing,missing,missing,missing);

            return eWorkbook;
        }

        //创建excel文档
        public void CreateExcel()
        {
            Excel.Application mExcel = new Excel.ApplicationClass();
            Excel.Workbook mWorkbook = mExcel.Application.Workbooks.Add(true);

            mWorkbook.Worksheets.Add(missing, missing, missing, missing);

            mWorkbook.SaveCopyAs(excelPath+".xls");

            //进程实例化
            System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
            foreach (System.Diagnostics.Process p in excelProcess)
            {
                p.Kill();
            }
        }

        //取得第一个Sheet的名称
        private string GetExcelSheetName(string pPath)
        {
            #region 获取excel表名

            Excel.Application excelapp = new Excel.ApplicationClass();

            if (excelapp == null)
            {
                throw new Exception("打开Excel应用时发生错误");
            }

            Excel.Workbooks books = excelapp.Workbooks;
            Excel.Workbook book = books.Add(pPath);
            Excel.Sheets sheets = book.Sheets;

            //选择第一个sheet
            string sheetname = sheets.get_Item(1).ToString();

            return sheetname;

            #endregion
        }

    }

}
