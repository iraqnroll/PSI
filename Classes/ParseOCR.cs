using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime;
using Tesseract;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PSIShoppingEngine.Classes
{
    class ParseOCR
    {
        public void Parse(Page page, Receipt rec)
        {
            using (var iter = page.GetIterator())
            {
                
                iter.Begin();
                do
                {
                    Item item = new Item();
                    do
                    {
                        var word = iter.GetText(PageIteratorLevel.Word);  
                        
                        if (!double.TryParse(word, out _))
                        {
                            item.ItemName =item.ItemName + " " + word;
                        }
                        else
                        {
                            item.ItemPrice = word;
                            item.Type = Item.ItemType.Other;
                            rec.Groceries.Add(item);
                        }
                        do
                        {



                        } while (iter.Next(PageIteratorLevel.Word, PageIteratorLevel.Symbol));
                    } while (iter.Next(PageIteratorLevel.TextLine, PageIteratorLevel.Word));
                } while (iter.Next(PageIteratorLevel.Para, PageIteratorLevel.TextLine));
            }
        }
    }
}
