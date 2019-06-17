using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PriceApp
{
    public partial class NewGoods
    {
        #region поля
        //идитификатор товара
        private int _idGoods;
        // идитификатор склада
        private int _idSklad;
        // название товара
        private string _nameGods;
        // вид товара
        private string _viewGoods;
        //описание товара
        private string _descript;
        //количество товара на складе
        private int _countGoods;
        #endregion
        #region свойства
        public int IdGoods
        {
            get
            {
                return _idGoods;
            }
            set
            {
                _idGoods = value;
            }
        }
        public int IdSklad
        {
            get
            {
                return _idSklad;
            }
            set
            {
                _idSklad = value;
            }
        }
        public string NameGoods
        {
            get
            {
                return _nameGods;
            }
            set
            {
                _nameGods = value;
            }
        }
        public string ViewGoods
        {
            get
            {
                return _viewGoods;
            }
            set
            {
                _viewGoods = value;
            }
        }
        public string Descript
        {
            get
            {
                return _descript;
            }
            set
            {
                _descript = value;
            }
        }
        public int CountGoods
        {
            get
            {
                return _countGoods;
            }
            set
            {
                _countGoods = value;
            }
        }
        #endregion
    }
}
