using System;
using System.Collections.Generic;
using System.Text;

namespace ResourceManage.Domain
{
    public class Config
    {
        protected virtual string ConfigFormat
        {
            get
            {
                return "<data name=\"{0}\" type=\"System.Resources.ResXFileRef, System.Windows.Forms\"><value>{1};System.Drawing.Bitmap, System.Drawing, Version=2.0.0.0, Culture=neutral, PublicKeyToken={3}</value></data>";
            }
        }

        /// <summary>
        /// 资源命名空间
        /// </summary>
        public string NameSpace { get; set; }
        /// <summary>
        /// 资源文件名称
        /// </summary>
        public string ResName { get; set; }

        public List<string> Files { get; set; }


        public override string ToString()
        {
            throw new NullReferenceException();
        }
    }
}
