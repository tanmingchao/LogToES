/*******************************************************************
*	命名空间 ：ARD.ESProvider
*	文件名称 ：ESOptions
*	创 建 人 ：m1835
*	创建日期 ：2018/8/9 20:28:16
*   -------------------------------------------------------------
*	Copyright @ m1835 2018. All rights reserved.
*******************************************************************/

namespace ARD.ESProvider
{
    /// <summary>
    /// ES配置 选项
    /// </summary>
    public class ESOptions
    {
        public string Uri { get; set; }
        public string DefaultIndex { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
