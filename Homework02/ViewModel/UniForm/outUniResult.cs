using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework02.ViewModel.UniForm
{
    public class outUniResult
    {
        public int StatusCode { get; set; } //統一回傳的狀態碼
        public object Result { get; set; } //回傳的物件
        public object Error { get; set; } //統一回傳的錯誤訊息摘要
    }
}
